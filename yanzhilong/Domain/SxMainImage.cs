using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yanzhilong.Domain
{
    public class SxMainImage
    {
        
       /// <summary>
       /// 编号
       /// </summary>
       public string Id { get; set; }
       
       /// <summary>
       /// 网址
       /// </summary>
       public string Url { get; set; }
       
       /// <summary>
       /// 时间排序
       /// </summary>
       public int Sort { get; set; }
       
       /// <summary>
       /// 鞋子
       /// </summary>
       public SxShoe sxShoe { get; set; }
       

    }
}