using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Domain;

namespace yanzhilong.Models
{
    public class JdAutoPropertyValueModel
    {
        public string Id { get; set; }
        public string JdAutoId { get; set; }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("名称")]
        public string PropertyName { get; set; }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("名称")]
        public string PropertyKey { get; set; }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("名称")]
        public string ValueName { get; set; }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("名称")]
        public string ValueValue { get; set; }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("名称")]
        public int IsCheck { get; set; }
        public string CheckStr
        {
            get
            {
                switch (IsCheck)
                {
                    case 0:
                        return "否";
                    case 1:
                        return "是";
                }
                return "其它";
            }
        }
        public List<SelectListItem> CheckItems { get; set; }
    }
}