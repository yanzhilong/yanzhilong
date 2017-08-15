using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Domain
{
    /// <summary>
    /// 用户角色
    /// </summary>
    public class UserRole
    {
        public string Id { get; set; } //编号
        public User user { get; set; } //用户
        public Role role { get; set; } //角色
    }
}