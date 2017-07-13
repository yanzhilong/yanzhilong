using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yanzhilong.Domain
{
    public class TbPropertyMapping
    {
        
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
       
        /// <summary>
        /// 属性
        /// </summary>
        public TbProperty tbProperty { get; set; }
       
        /// <summary>
        /// 属性分类
        /// </summary>
        public TbPropertyCategory tbPropertyCategory { get; set; }
       

    }
}