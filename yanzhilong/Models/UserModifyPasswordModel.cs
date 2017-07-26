using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yanzhilong.Models
{
    public class UserModifyPasswordModel
    {
        public string Id { get; set; }

        /// <summary>
        /// 原密码
        /// </summary>
        [DataType(DataType.Password)]
        [Required] //必填项
        [DisplayName("原密码")] //显示在Label上的名字
        public string PasswordOld { get; set; }
        
        /// <summary>
        /// 新密码
        /// </summary>
        [Required] //必填项
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "密码长度不能小于6位", MinimumLength = 6)]
        [DisplayName("新密码")] //显示在Label上的名字
        public string PasswordNew { get; set; }

        [Required] //必填项
        [Compare("PasswordNew", ErrorMessage = "确认密码必须一致")]
        [DataType(DataType.Password)]
        [DisplayName("确认密码")]
        public string RepPassword { get; set; }
    }
}