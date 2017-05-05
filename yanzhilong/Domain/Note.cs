using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Domain
{
    public class Note
    {
        public string NoteID { get; set; }
        public string Title { get; set; } //标题
        public string Content { get; set; }
        public DateTime CreateAt { get; set; } //创建时间
        public DateTime UpdateAt { get; set; } //修改时间
    }
}