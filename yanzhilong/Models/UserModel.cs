using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace yanzhilong.Models
{
    public class UserModel
    {
        public string Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [DisplayName("用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [DisplayName("邮箱")]
        public string Email { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [DisplayName("手机号码")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [DisplayName("昵称")]
        public string DisplayName { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        [DisplayName("注册时间")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 最后登陆时间
        /// </summary>
        [DisplayName("最近一次登陆")]
        public DateTime LastLoginDateUtc { get; set; }
    }
}