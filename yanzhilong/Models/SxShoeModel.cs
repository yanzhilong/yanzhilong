using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using yanzhilong.Domain;

namespace yanzhilong.Models
{
    public class SxShoeModel
    {

        /// <summary>
        /// 编号
        /// </summary>
        [DisplayName("编号")]
        public string Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [DisplayName("标题")]
        public string Title { get; set; }

        /// <summary>
        /// 网址
        /// </summary>
        [DisplayName("网址")]
        public string Url { get; set; }

        /// <summary>
        /// 商家编号
        /// </summary>
        [DisplayName("商家编号")]
        public string Number { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [DisplayName("价格")]
        public float Price { get; set; }

        /// <summary>
        /// 人气
        /// </summary>
        [DisplayName("人气")]
        public int Popularity { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DisplayName("更新时间")]
        public string UpdateStr { get; set; }

        /// <summary>
        /// 市场
        /// </summary>
        [DisplayName("市场")]
        public string Market { get; set; }

        /// <summary>
        /// 时间排序
        /// </summary>
        [DisplayName("时间排序")]
        public int Sort { get; set; }

        /// <summary>
        /// 第一张主图
        /// </summary>
        public string MainImage { get; set; }

        /// <summary>
        /// 类目
        /// </summary>
        public int Cid { get; set; }

        /// <summary>
        /// 类目
        /// </summary>
        public string CidStr
        {
            get
            {
                switch (Cid)
                {
                    case (int)ShoeCidEnum.DIBANG:

                        return "低帮鞋";
                    case (int)ShoeCidEnum.GAOBANG:

                        return "高帮鞋";
                    case (int)ShoeCidEnum.TUOXIE:

                        return "拖鞋";
                    case (int)ShoeCidEnum.LIANGXIE:

                        return "凉鞋";
                }
                return "请选择";
            }
            set
            {

            }
        }

        /// <summary>
        /// 类目选择
        /// </summary>
        public List<SelectListItem> CidItems { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [DisplayName("标题")]
        public string FilterTitle { get; set; }

        /// <summary>
        /// 商家编号
        /// </summary>
        [DisplayName("商家编号")]
        public string FilterNumber { get; set; }

    }
}