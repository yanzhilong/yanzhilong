using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Domain
{
    /// <summary>
    /// 权限类
    /// </summary>
    public class PermissionRecord
    {
        public string Id { get; set; } //编号
        public string Name { get; set; }//名称
        public string SystemName { get; set; }//配置名称
    }
}