using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yanzhilong.Models
{
    public class UserRegisterModel
    {
        public string Id { get; set; }

        [DisplayName("用户名")] //显示在Label上的名字
        public string UserName { get; set; }

        [DisplayName("邮箱")] //显示在Label上的名字
        public string Email { get; set; }

        [DisplayName("手机")] //显示在Label上的名字
        public string PhoneNumber { get; set; }

        [Required] //必填项
        [DisplayName("密码")] //显示在Label上的名字
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("确认密码")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "密码必须一致")]
        [DataType(DataType.Password)]
        public string RepPassword { get; set; }

        /// <summary>
        /// 注册类型
        /// </summary>
        public int RegisterType { get; set; }

        /// <summary>
        /// 注册类型列表
        /// </summary>
        public List<SelectListItem> RegisterTypeItems { get; set; }
    }
}