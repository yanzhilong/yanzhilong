using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yanzhilong.Models
{
    public class NoteModel
    {
        public string NoteID { get; set; }
        [Required(ErrorMessage = "请输入标题")] //必填项
        [DisplayName("标题")] //显示在Label上的名字
        public string Title { get; set; } //标题
        [Required(ErrorMessage = "请输入正文")] //必填项
        [DataType(DataType.MultilineText)]
        [DisplayName("文章内容")] //显示在Label上的名字
        public string Content { get; set; }
        [DisplayName("创建时间")] //显示在Label上的名字
        public DateTime CreateAt { get; set; } //创建时间
        [DisplayName("更新时间")] //显示在Label上的名字
        public DateTime UpdateAt { get; set; } //修改时间
    }
}