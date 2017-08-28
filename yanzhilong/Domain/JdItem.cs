using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yanzhilong.Domain
{
    public class JdItem
    {
        
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
       
        /// <summary>
        /// 链接
        /// </summary>
        public string Url { get; set; }
       
        /// <summary>
        /// 商家编码
        /// </summary>
        public string JNumber { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateAt { get; set; }
    }
}