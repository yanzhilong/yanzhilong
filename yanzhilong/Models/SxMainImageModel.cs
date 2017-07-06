using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Domain;

namespace yanzhilong.Models
{
    public class SxMainImageModel
    {
        
       /// <summary>
       /// 编号
       /// </summary>
       [DisplayName("编号")]
       public string Id { get; set; }
       
       /// <summary>
       /// 网址
       /// </summary>
       [DisplayName("网址")]
       public string Url { get; set; }
       
       /// <summary>
       /// 时间排序
       /// </summary>
       [DisplayName("时间排序")]
       public int Sort { get; set; }
       
       /// <summary>
       /// 鞋子
       /// </summary>
       [DisplayName("鞋子")]
       public SxShoe sxShoe { get; set; }
       

    }
}