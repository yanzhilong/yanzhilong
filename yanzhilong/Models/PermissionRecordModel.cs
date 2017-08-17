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
    /// 权限表
    /// </summary>
    public class PermissionRecordModel
    {
        public string Id { get; set; } //编号

        [DisplayName("名称")] //显示在Label上的名字
        public string Name { get; set; }//名称

        [DisplayName("配置名称")] //显示在Label上的名字
        public string SystemName { get; set; }//配置名称

        [DisplayName("是否授权")] //显示在Label上的名字
        public bool Authorize { get; set; }//是否授权
    }
}