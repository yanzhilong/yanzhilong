using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yanzhilong.Domain
{
    public class SxShoe
    {

        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 网址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 商家编号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// 人气
        /// </summary>
        public int Popularity { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public string UpdateStr { get; set; }

        /// <summary>
        /// 市场
        /// </summary>
        public string Market { get; set; }

        /// <summary>
        /// 时间排序
        /// </summary>
        public int Sort { get; set; }


    }
}