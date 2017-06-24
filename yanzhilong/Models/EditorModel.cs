using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Models
{
    public class EditorModel
    {
        public string ParameterId { get; set; } //Get和Post的Id
        public string Get { get; set; } //获得MarkDown
        public string Post { get; set; } //保存MarkDown
    }
}