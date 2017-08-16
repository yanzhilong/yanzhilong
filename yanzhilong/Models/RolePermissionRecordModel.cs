using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Domain;

namespace yanzhilong.Models
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class RolePermissionRecordModel
    {
        public string Id { get; set; } //编号

        [DisplayName("角色")]
        public string RoleName { get; set; }

        [DisplayName("权限")]
        public string PermissionRecordName { get; set; }
    }
}