using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Domain
{
    /// <summary>
    /// 角色类
    /// </summary>
    public class Role
    {
        private ICollection<PermissionRecord> _permissionRecords;

        public string Id { get; set; } //编号
        public string Name { get; set; }//名称
        public string SystemName { get; set; }//配置名称

        public virtual ICollection<PermissionRecord> PermissionRecords
        {
            get { return _permissionRecords ?? (_permissionRecords = new List<PermissionRecord>()); }
            set { _permissionRecords = value; }
        }
    }
}