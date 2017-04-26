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
        public string UserID { get; set; }
        [Required] //必填项
        [DisplayName("用户名")] //显示在Label上的名字
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        [Required] //必填项
        [DisplayName("密码")] //显示在Label上的名字
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public DateTime CreateAt { get; set; }
    }
}