using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yanzhilong.Domain
{
    /// <summary>
    /// 文章表
    /// </summary>
    public class Article
    {
        public string ArticleID { get; set; } //编号
        public string Title { get; set; } //标题
        public string Content { get; set; } //内容
        public string ImageUrl { get; set; } //说明图像
        public string Disc { get; set; } //摘要
        public string Notes { get; set; } //备注
        public DateTime CreateAt { get; set; } //发表时间
        public DateTime UpdateAt { get; set; } //更新时间
        public Category category { get; set; } //文章分类
        public User user { get; set; } //创建者
        public int PV { get; set; }//浏览量
    }
}