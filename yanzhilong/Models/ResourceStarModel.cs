using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yanzhilong.Models
{
    /// <summary>
    /// 资源推荐
    /// </summary>
    public class ResourceStarModel
    {
        public string ResourceStarID { get; set; }
        [Required(ErrorMessage = "请输入资源编号")] //必填项
        [DisplayName("资源编号")] //显示在Label上的名字
        public string ResourceID { get; set; }
        [Required(ErrorMessage = "请选择资源分类")]
        [DisplayName("资源类型")] //显示在Label上的名字
        public int ResourceType { get; set; }

        public IList<SelectListItem> ResourceTypeSelectItems { get; set; } //分类列表
    }
}