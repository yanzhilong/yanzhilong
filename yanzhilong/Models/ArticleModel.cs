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
    /// <summary>
    /// 文章表
    /// </summary>
    public class ArticleModel
    {
        public string Id { get; set; } //编号
        [Required(ErrorMessage = "请输入标题")] //必填项
        [DisplayName("标题")] //显示在Label上的名字
        public string Title { get; set; } //标题
        [Required(ErrorMessage = "请输入正文")] //必填项
        [DataType(DataType.MultilineText)]
        [DisplayName("文章内容")] //显示在Label上的名字
        public string Content { get; set; } //内容
        [DataType(DataType.MultilineText)]
        [DisplayName("摘要")] //显示在Label上的名字
        public string Description { get; set; } //摘要
        [DisplayName("发表时间")] //显示在Label上的名字
        public DateTime CreateAt { get; set; } //发表时间
        public int PV { get; set; }//浏览量
        public IList<SelectListItem> CategorySelectItems { get; set; } //分类列表
        [Required(ErrorMessage = "请选择分类")]
        [DisplayName("分类")] //显示在Label上的名字
        [MinLength(36)]
        public string CategoryID { get; set; }
        [DisplayName("分类名称")] //显示在Label上的名字
        public string CategoryName { get; set; }
        public string UserID { get; set; }
        public string DisplayName { get; set; }
    }
}