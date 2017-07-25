using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yanzhilong.Models
{
    public class UserLoginModel
    {
        public string Id { get; set; }

        [Required] //必填项
        [DisplayName("用户名")] //显示在Label上的名字
        public string UserName { get; set; }

        [Required] //必填项
        [DisplayName("密码")] //显示在Label上的名字
        public string PasswordHash { get; set; }
    }
}