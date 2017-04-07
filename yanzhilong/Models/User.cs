using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Models
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public DateTime CreateAt { get; set; }
    }
}