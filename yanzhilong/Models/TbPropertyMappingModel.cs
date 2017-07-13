using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Domain;

namespace yanzhilong.Models
{
    public class TbPropertyMappingModel
    {
        
       /// <summary>
       /// 编号
       /// </summary>
       [DisplayName("编号")]
       public string Id { get; set; }
       
       /// <summary>
       /// 属性
       /// </summary>
       [DisplayName("属性")]
       public TbProperty tbProperty { get; set; }
       
       /// <summary>
       /// 属性分类
       /// </summary>
       [DisplayName("属性分类")]
       public TbPropertyCategory tbPropertyCategory { get; set; }
       

    }
}