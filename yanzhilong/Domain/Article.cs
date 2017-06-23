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
        public string Id { get; set; } //编号
        public string Title { get; set; } //标题
        public string Content { get; set; } //内容
        public string Description { get; set; } //摘要
        public DateTime CreateAt { get; set; } //发表时间
        public Category category { get; set; } //文章分类
        public User user { get; set; } //创建者
        public int PV { get; set; }//浏览量
    }
}