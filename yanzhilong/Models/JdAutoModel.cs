using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yanzhilong.Models
{
    public class JdAutoModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("名称")]
        public string Name { get; set; }//
    }
}