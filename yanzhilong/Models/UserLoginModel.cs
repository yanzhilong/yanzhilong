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

        [Required] //必填项
        [DisplayName("用户名邮箱或手机")] //显示在Label上的名字
        public string UserNameOrEmailOrPhoneNumber { get; set; }

        [Required] //必填项
        [DisplayName("密码")] //显示在Label上的名字
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "密码长度不能小于6位", MinimumLength = 6)]
        public string Password { get; set; }
    }
}