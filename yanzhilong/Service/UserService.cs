using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public UserLoginResultEnum ValidateUser(string UserNameOrEmailOrPhoneNumber, string Password)
        {
            var user = this.GetEntry(new User { UserName = UserNameOrEmailOrPhoneNumber });
            if (user == null)
                user = this.GetEntry(new User { Email = UserNameOrEmailOrPhoneNumber });
            if (user == null)
                user = this.GetEntry(new User { PhoneNumber = UserNameOrEmailOrPhoneNumber });

            if (user == null)
                return UserLoginResultEnum.UserNotExist;
            if (user.CannotLoginUntilDateUtc.HasValue && user.CannotLoginUntilDateUtc.Value > DateTime.Now)
                return UserLoginResultEnum.LockedOut;

            if (!PasswordsMatch(user, Password))
            {
                //密码错误，最多重试5次,锁定时间五分钟
                user.FailedLoginAttempts++;
                //if (_customerSettings.FailedPasswordAllowedAttempts > 0 &&
                //    customer.FailedLoginAttempts >= _customerSettings.FailedPasswordAllowedAttempts)
                if (user.FailedLoginAttempts >= 5)
                {
                    //锁定
                    user.CannotLoginUntilDateUtc = DateTime.Now.AddMinutes(5);
                    //重置计数器
                    user.FailedLoginAttempts = 0;
                }
                this.UpdateEntry(user);

                return UserLoginResultEnum.WrongPassword;
            }

            //更新登陆信息
            user.FailedLoginAttempts = 0;
            user.CannotLoginUntilDateUtc = null;
            user.LastLoginDateUtc = DateTime.Now;
            this.UpdateEntry(user);

            return UserLoginResultEnum.Successful;
        }
        
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserRegistResult RegisterUser(User user,string Password)
        {
            var result = new UserRegistResult();

            if (user == null)
                throw new ArgumentNullException("request");

            var mUser = this.GetEntry( user );

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

            if (String.IsNullOrWhiteSpace(Password))
            {
                result.AddError("密码不能为空");
                return result;
            }

            if (String.IsNullOrEmpty(user.UserName) && String.IsNullOrEmpty(user.Email) && String.IsNullOrEmpty(user.PhoneNumber))
            {
                result.AddError("用户名或手机或邮箱不能为空");
                return result;
            }
            
            user.CreateDate = DateTime.Now;
            
            //保存历史密码暂不实现
            //var customerPassword = new CustomerPassword
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    CustomerId = request.Customer.Id,
            //    Customer = request.Customer,
            //    PasswordFormat = PasswordFormat.MD5,
            //    CreatedOnUtc = DateTime.Now
            //};

            string salt;
            string hash;
            saltedHash.GetHashAndSaltString(Password, out hash, out salt);
            user.PasswordHash = hash;
            user.Salt = salt;

            //customerPassword.PasswordSalt = salt;
            //customerPassword.Password = hash;
            //customerPassword.DigestHa1Hash = digestHash;

            //_customerService.InsertCustomerPassword(customerPassword);

            //request.Customer.Active = request.IsApproved;

            //add to 'Registered' role

            this.AddEntry(user);
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