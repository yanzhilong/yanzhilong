using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Domain;

namespace yanzhilong.Models
{
    public class SxPropertyModel
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
       public string Value { get; set; }
       
       /// <summary>
       /// 鞋子
       /// </summary>
       [DisplayName("鞋子")]
       public SxShoe sxShoe { get; set; }
       

    }
}