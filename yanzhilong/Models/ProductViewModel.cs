using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Models
{
    /// <summary>
    /// 软件产品实体
    /// </summary>
    public class ProductViewModel
    {
        public string ProductID { get; set; } //编号
        public string Name { get; set; } //名称
        public string Content { get; set; } //产品说明
        public string Version { get; set; } //版本
        public int Size { get; set; } //大小 
        public string ImageUrl { get; set; } //说明图像
        public string Disc { get; set; } //摘要
        public string Notes { get; set; } //备注
        public DateTime CreateAt { get; set; } //发布时间
    }
}