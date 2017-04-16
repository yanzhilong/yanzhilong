using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yanzhilong.Models
{
    /// <summary>
    /// 文章表
    /// </summary>
    public class Article
    {
        public string ArticleID { get; set; } //编号
        [Required(ErrorMessage = "请输入标题")] //必填项
        [DisplayName("标题")] //显示在Label上的名字
        public string Title { get; set; } //标题
        [Required(ErrorMessage = "请输入正文")] //必填项
        [DataType(DataType.MultilineText)]
        [DisplayName("文章内容")] //显示在Label上的名字
        public string Content { get; set; } //内容
        [DisplayName("图片")] //显示在Label上的名字
        public string ImageUrl { get; set; } //说明图像
        [DisplayName("摘要")] //显示在Label上的名字
        public string Disc { get; set; } //摘要
        [DisplayName("备注")] //显示在Label上的名字
        public string Notes { get; set; } //备注
        [DisplayName("发表时间")] //显示在Label上的名字
        public DateTime CreateAt { get; set; } //发表时间
        public DateTime UpdateAt { get; set; } //更新时间
        [Required(ErrorMessage = "请选择分类")]
        [DisplayName("分类")] //显示在Label上的名字
        public Category category { get; set; } //文章分类
        public User user { get; set; } //创建者
    }
}