using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yanzhilong.Domain
{
    public class SxColor
    {
        
       /// <summary>
       /// 编号
       /// </summary>
       public string Id { get; set; }
       
       /// <summary>
       /// 颜色
       /// </summary>
       public string Name { get; set; }
       
       /// <summary>
       /// 鞋子
       /// </summary>
       public SxShoe sxShoe { get; set; }
       

    }
}