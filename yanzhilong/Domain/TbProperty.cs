using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yanzhilong.Domain
{
    public class TbProperty
    {
        
       /// <summary>
       /// 编号
       /// </summary>
       public string Id { get; set; }
       
       /// <summary>
       /// 名称
       /// </summary>
       public string Name { get; set; }
       
       /// <summary>
       /// 值
       /// </summary>
       public string ValueKey { get; set; }
       
       /// <summary>
       /// 属性分类
       /// </summary>
       public TbPropertyCategory tbPropertyCategory { get; set; }
       

    }
}