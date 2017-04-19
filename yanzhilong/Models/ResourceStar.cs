using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yanzhilong.Models
{
    /// <summary>
    /// 资源推荐
    /// </summary>
    public class ResourceStar
    {
        [DisplayName("资源推荐编号")] //显示在Label上的名字
        public string ResourceStarID { get; set; }
        [Required] //必填项
        [DisplayName("资源编号")] //显示在Label上的名字
        public string ResourceID { get; set; }
        [Required] //必填项
        [DisplayName("资源类型")] //显示在Label上的名字
        public int ResourceType { get; set; }
    }
}