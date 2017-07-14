using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yanzhilong.Models
{
    public class TbPropertyModel
    {
        
        /// <summary>
        /// 编号
        /// </summary>
        [DisplayName("编号")]
        public string Id { get; set; }
       
        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        public string Name { get; set; }
       
        /// <summary>
        /// 值
        /// </summary>
        [DisplayName("值")]
        public string ValueKey { get; set; }
    }
}