using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yanzhilong.Models
{
    public class JdAutoModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("名称")]
        public string Name { get; set; }//

        [DisplayName("父级")]
        public string PId { get; set; }//父级编号

        public string PName { get; set; }//父级名称
        public IList<SelectListItem> PJdAutoSelectItems { get; set; } //父级列表
    }
}