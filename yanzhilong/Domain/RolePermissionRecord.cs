using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Domain
{
    /// <summary>
    /// 角色权限类
    /// </summary>
    public class RolePermissionRecord
    {
        public string Id { get; set; } //编号
        public Role Role { get; set; }
        public PermissionRecord PermissionRecord { get; set; } //权限
        public string Options { get; set; } //子权限项
    }
}