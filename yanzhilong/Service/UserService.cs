using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using yanzhilong.Domain;
using yanzhilong.Helper;
using yanzhilong.Repository;
using yanzhilong.Security;

namespace yanzhilong.Service
{
    public class UserService : IBaseService<User>
    {
        private readonly IRepository<User> repository = new MbRepository<User>();
        private readonly SaltedHash saltedHash = new SaltedHash();
        private readonly ICacheService _CacheService;

        public UserService(ICacheService cacheService)
        {
            this._CacheService = cacheService;
        }
        
        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="UserNameOrEmailOrPhoneNumber">用户名，邮箱，电话</param>
        /// <param name="Password">密码</param>
        /// <returns></returns>
        public UserLoginResult ValidateUser(string UserNameOrEmailOrPhoneNumber, string Password)
        {
            UserLoginResult ulr = new UserLoginResult();
            var user = this.GetEntry(new User { UserName = UserNameOrEmailOrPhoneNumber });
            if (user == null)
                user = this.GetEntry(new User { Email = UserNameOrEmailOrPhoneNumber });
            if (user == null)
                user = this.GetEntry(new User { PhoneNumber = UserNameOrEmailOrPhoneNumber });

            if (user == null)
            {
                ulr.UserLoginResultEnum = UserLoginResultEnum.UserNotExist;
                return ulr;
            }
                
            if (user.CannotLoginUntilDateUtc.HasValue && user.CannotLoginUntilDateUtc.Value > DateTime.Now)
            {
                ulr.UserLoginResultEnum = UserLoginResultEnum.LockedOut;
                return ulr;
            }

            if (!PasswordsMatch(user, Password))
            {
                if (user.LastFailedLoginDateUtc != null)
                {
                    //判断最后一次错误时间和现在的间隔
                    TimeSpan ts = DateTime.Now - user.LastFailedLoginDateUtc.Value;
                    if (ts.TotalSeconds > 5 * 60)
                    {
                        //重置计数器
                        user.FailedLoginAttempts = 1;
                        user.LastFailedLoginDateUtc = DateTime.Now;
                        this.UpdateEntry(user);
                        ulr.TryCount = 5 - user.FailedLoginAttempts;
                        ulr.UserLoginResultEnum = UserLoginResultEnum.WrongPassword;
                        return ulr;
                    }
                }

                //密码错误，最多重试5次,锁定时间五分钟
                user.FailedLoginAttempts++;
                //if (_customerSettings.FailedPasswordAllowedAttempts > 0 &&
                //    customer.FailedLoginAttempts >= _customerSettings.FailedPasswordAllowedAttempts)
                if (user.FailedLoginAttempts >= 5)
                {
                    //锁定
                    user.CannotLoginUntilDateUtc = DateTime.Now.AddMinutes(5);
                    user.LastFailedLoginDateUtc = DateTime.Now;
                    //重置计数器
                    user.FailedLoginAttempts = 0;
                    this.UpdateEntry(user);
                    ulr.UserLoginResultEnum = UserLoginResultEnum.LockedOut;
                    return ulr;
                }

                user.CannotLoginUntilDateUtc = null;
                user.LastFailedLoginDateUtc = DateTime.Now;
                this.UpdateEntry(user);
                ulr.TryCount = 5 - user.FailedLoginAttempts;
                ulr.UserLoginResultEnum = UserLoginResultEnum.WrongPassword;
                return ulr;
            }

            //更新登陆信息
            user.FailedLoginAttempts = 0;
            user.LastFailedLoginDateUtc = null;
            user.CannotLoginUntilDateUtc = null;
            user.LastLoginDateUtc = DateTime.Now;
            this.UpdateEntry(user);

            ulr.UserLoginResultEnum = UserLoginResultEnum.Successful;
            return ulr;
        }
        
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserRegistResult RegisterUser(User user,string Password,UserRegisterTypeEnum urt)
        {
            var result = new UserRegistResult();

            if (user == null)
                throw new ArgumentNullException("request");
            User mUser = null;
            switch (urt)
            {
                case UserRegisterTypeEnum.UserName:
                    mUser = this.GetEntry(new User { UserName = user.UserName });
                    break;
                case UserRegisterTypeEnum.Email:
                    mUser = this.GetEntry(new User { Email = user.Email });
                    break;
                case UserRegisterTypeEnum.PhoneNumber:
                    mUser = this.GetEntry(new User { PhoneNumber = user.PhoneNumber });
                    break;
            }
            if (mUser != null)
            {
                result.AddError("当前用户已经注册");
                return result;
            }
           
            if (!string.IsNullOrEmpty(user.Email))
            {
                if (!CommonHelper.IsValidEmail(user.Email))
                {
                    result.AddError("邮箱格式不正确");
                    return result;
                }
            }

            user.Id = Guid.NewGuid().ToString();
            user.CreateDate = DateTime.Now;
            user.LastLoginDateUtc = DateTime.Now;

            string salt;
            string hash;
            saltedHash.GetHashAndSaltString(Password, out hash, out salt);
            user.PasswordHash = hash;
            user.Salt = salt;

            this.AddEntry(user);
            return result;
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UseUpdateResult UpdateUserInfo(User user)
        {

            User mUser = this.GetEntry(new User { Id = user.Id });
            User mUserName = this.GetEntry(new User { UserName = user.UserName });
            User mUserEmail = this.GetEntry(new User { Email = user.Email });
            User mUserPhoneNumber = this.GetEntry(new User { PhoneNumber = user.PhoneNumber });

            var result = new UseUpdateResult();

            if (!string.IsNullOrEmpty(user.UserName) && !mUser.Id.Equals(mUserName.Id))
            {
                result.AddError("用户名已经被占用");
            }

            if (!string.IsNullOrEmpty(user.Email) && !mUser.Id.Equals(mUserEmail.Id))
            {
                result.AddError("邮箱已经被占用");
            }

            if (!string.IsNullOrEmpty(user.PhoneNumber) && !mUser.Id.Equals(mUserPhoneNumber.Id))
            {
                result.AddError("手机已经被占用");
            }

            if(string.IsNullOrEmpty(user.UserName) && string.IsNullOrEmpty(user.Email) && string.IsNullOrEmpty(user.PhoneNumber))
            {
                result.AddError("邮箱和手机必须保留一项");
            }

            if (!result.Success)
            {
                return result;
            }

            this.UpdateEntry(user);
            return result;
        }


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UseModifyPasswordResult ModifyPassword(string UserId, string PasswordOld, string PasswordNew)
        {
            User user = this.GetEntry(new User { Id = UserId});
            var result = new UseModifyPasswordResult();

            string salt;
            string hash;

            if (!PasswordsMatch(user, PasswordOld))
            {
                result.AddError("旧密码不正确");
            }
            else
            {
               
                saltedHash.GetHashAndSaltString(PasswordNew, out hash, out salt);
                user.PasswordHash = hash;
                user.Salt = salt;
                this.UpdateEntry(user);
            }
            return result;
        }

        
        /// <summary>
        /// 密码验证
        /// </summary>
        /// <param name="user"></param>
        /// <param name="enteredPassword"></param>
        /// <returns></returns>
        protected bool PasswordsMatch(User user, string enteredPassword)
        {
            if (user == null || string.IsNullOrEmpty(enteredPassword))
                return false;

            if (saltedHash.VerifyHashString(enteredPassword, user.PasswordHash, user.Salt))
            {
                return true;
            }
            return false;
        }

        public void AddEntry(User entry)
        {
            repository.Insert("InsertUser", entry);
        }

        public void AddEntrys(IList<User> entrys)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntry(User entry)
        {
            repository.Delete("DeleteUser", entry );
        }

        public void DeleteEntrys(IList<User> entrys)
        {
            throw new NotImplementedException();
        }

        public int GetCount(User entry)
        {
            throw new NotImplementedException();
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public User GetEntry(User entry)
        {
            User user = repository.GetByCondition("SelectUserByCondition", entry);
            return user;
        }

        public User GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetEntrys(User entry)
        {
            IList<User> users = repository.GetList("SelectUserByCondition", entry);
            return users;
        }

        public IEnumerable<User> GetEntrys(User entry, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetEntrys(int skip, int take, User entry)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntry(User entry)
        {
            repository.Update("UpdateUser", entry);
        }

        public void UpdateEntrys(IList<User> entrys)
        {
            throw new NotImplementedException();
        }
    }
}