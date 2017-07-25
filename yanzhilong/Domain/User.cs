using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yanzhilong.Domain
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User
    {
        public string Id { get; set; }
        
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// 密码哈希
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// 密码加盐
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 登陆失败次数
        /// </summary>
        public int FailedLoginAttempts { get; set; }

        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public DateTime LastLoginDateUtc { get; set; }

        /// <summary>
        /// 不能登陆截止时间
        /// </summary>
        public DateTime? CannotLoginUntilDateUtc { get; set; }
        
    }
}