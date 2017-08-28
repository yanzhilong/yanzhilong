using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yanzhilong.Models
{
    public class JdItemModel
    {
        
        public string Id { get; set; }

        [Required(ErrorMessage = "必选项")]
        [DisplayName("链接")]
        public string Url { get; set; }

        [Required(ErrorMessage = "必选项")]
        [DisplayName("商家编码")]
        public string JNumber { get; set; }

        [Required(ErrorMessage = "必选项")]
        [DisplayName("创建时间")]
        public DateTime? CreateAt { get; set; }
    }
}