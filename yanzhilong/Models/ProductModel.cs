using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yanzhilong.Models
{
    /// <summary>
    /// 软件产品实体
    /// </summary>
    public class ProductModel
    {
        public string ProductID { get; set; } //编号
        [Required(ErrorMessage = "请输入名称")] //必填项
        [DisplayName("名称")] //显示在Label上的名字
        public string Name { get; set; } //名称
        [Required(ErrorMessage = "请输入正文")] //必填项
        [DataType(DataType.MultilineText)]
        [DisplayName("产品说明")] //显示在Label上的名字
        public string Content { get; set; } //产品说明
        [Required(ErrorMessage = "请输入版本号")] //必填项
        [DisplayName("版本号")] //显示在Label上的名字
        public string Version { get; set; } //版本
        [DisplayName("大小")] //显示在Label上的名字
        public int Size { get; set; } //大小 
        [DisplayName("图片")] //显示在Label上的名字
        public string ImageUrl { get; set; } //说明图像
        [DataType(DataType.MultilineText)]
        [DisplayName("摘要")] //显示在Label上的名字
        public string Disc { get; set; } //摘要
        [DataType(DataType.MultilineText)]
        [DisplayName("备注")] //显示在Label上的名字
        public string Notes { get; set; } //备注
        [DisplayName("发布时间")] //显示在Label上的名字
        public DateTime CreateAt { get; set; } //发布时间
    }
}