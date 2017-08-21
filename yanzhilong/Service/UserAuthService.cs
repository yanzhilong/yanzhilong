using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using yanzhilong.Domain;

namespace yanzhilong.Service
{

    public class UserAuthService
    {
        private readonly ICacheService _CacheService;
        private readonly UserService _UserService;

        private User _CachedUser;

        public UserAuthService(ICacheService cacheService, UserService userService)
        {
            this._CacheService = cacheService;
            this._UserService = userService;
            
        }

        public User CurrentUser
        {
            get
            {
                return GetAuthenticatedUser();
            }
        }

        /// <summary>
        /// Forms验证操作登陆
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="createPersistentCookie">是否保存登陆，将cookie信息写到客户端</param>
        public virtual void SignIn(User user, bool createPersistentCookie)
        {
            var now = DateTime.Now;

            var ticket = new FormsAuthenticationTicket(
                1,
                user.UserName,
                now,
                now.Add(FormsAuthentication.Timeout),
                createPersistentCookie,
                user.Id,
                FormsAuthentication.FormsCookiePath);

            //加密票据
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;
            //设置过期时间
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }

            //写入Cookie
            HttpContext.Current.Response.Cookies.Add(cookie);
            _CachedUser = user;
            _CacheService.Set(user.Id, user, 60);//缓存
        }

        /// <summary>
        /// 注销 
        /// </summary>
        public virtual void SignOut()
        {
            if (_CachedUser != null)
            {
                _CacheService.Remove(_CachedUser.Id);
                _CachedUser = null;
            }

            FormsAuthentication.SignOut();
        }

        /// <summary>
        /// 得到已经验证过的User
        /// </summary>
        /// <returns>用户</returns>
        public virtual User GetAuthenticatedUser()
        {
            if (_CachedUser != null)
                return _CachedUser;

            if (HttpContext.Current == null ||
                HttpContext.Current.Request == null ||
                !HttpContext.Current.Request.IsAuthenticated ||
                !(HttpContext.Current.User.Identity is FormsIdentity))
            {
                return null;
            }

            var formsIdentity = (FormsIdentity)HttpContext.Current.User.Identity;
            var user = GetAuthenticatedCustomerFromTicket(formsIdentity.Ticket);
            if (user != null)
                _CachedUser = user;
            return _CachedUser;
        }

        /// <summary>
        /// Get authenticated customer
        /// </summary>
        /// <param name="ticket">Ticket</param>
        /// <returns>Customer</returns>
        protected virtual User GetAuthenticatedCustomerFromTicket(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");

            var userId = ticket.UserData;
            User user = null;
            if (!String.IsNullOrWhiteSpace(userId))
            {
                user = _CacheService.Get<User>(user.Id);
            }

            if (user == null)
            {
                user = _UserService.GetEntry(new User { Id = user.Id });
                _CacheService.Set(user.Id, user, 60);
            }
            return user;
        }

    }
}