using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Domain;

namespace yanzhilong.Models
{
    public class SxSsizeModel
    {
        
       /// <summary>
       /// 编号
       /// </summary>
       [DisplayName("编号")]
       public string Id { get; set; }
       
       /// <summary>
       /// 鞋码
       /// </summary>
       [DisplayName("鞋码")]
       public int Num { get; set; }
       
       /// <summary>
       /// 鞋子
       /// </summary>
       [DisplayName("鞋子")]
       public SxShoe sxShoe { get; set; }
       

    }
}