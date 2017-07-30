using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yanzhilong.Models
{
    public class TbItemModel
    {
        
       /// <summary>
       /// 编号
       /// </summary>
       [DisplayName("编号")]
       public string Id { get; set; }
       
       /// <summary>
       /// 宝贝名称
       /// </summary>
       [DisplayName("宝贝名称")]
       public string title { get; set; }
       
       /// <summary>
       /// 宝贝类目
       /// </summary>
       [DisplayName("宝贝类目")]
       public string cid { get; set; }
       
       /// <summary>
       /// 店铺类目
       /// </summary>
       [DisplayName("店铺类目")]
       public string seller_cids { get; set; }
       
       /// <summary>
       /// 新旧程度
       /// </summary>
       [DisplayName("新旧程度")]
       public string stuff_status { get; set; }
       
       /// <summary>
       /// 省
       /// </summary>
       [DisplayName("省")]
       public string location_state { get; set; }
       
       /// <summary>
       /// 城市
       /// </summary>
       [DisplayName("城市")]
       public string location_city { get; set; }
       
       /// <summary>
       /// 出售方式
       /// </summary>
       [DisplayName("出售方式")]
       public string item_type { get; set; }
       
       /// <summary>
       /// 宝贝价格
       /// </summary>
       [DisplayName("宝贝价格")]
       public string price { get; set; }
       
       /// <summary>
       /// 加价幅度
       /// </summary>
       [DisplayName("加价幅度")]
       public string auction_increment { get; set; }
       
       /// <summary>
       /// 宝贝数量
       /// </summary>
       [DisplayName("宝贝数量")]
       public string num { get; set; }
       
       /// <summary>
       /// 有效期
       /// </summary>
       [DisplayName("有效期")]
       public string valid_thru { get; set; }
       
       /// <summary>
       /// 运费承担
       /// </summary>
       [DisplayName("运费承担")]
       public string freight_payer { get; set; }
       
       /// <summary>
       /// 平邮
       /// </summary>
       [DisplayName("平邮")]
       public string post_fee { get; set; }
       
       /// <summary>
       /// EMS
       /// </summary>
       [DisplayName("EMS")]
       public string ems_fee { get; set; }
       
       /// <summary>
       /// 快递
       /// </summary>
       [DisplayName("快递")]
       public string express_fee { get; set; }
       
       /// <summary>
       /// 发票
       /// </summary>
       [DisplayName("发票")]
       public string has_invoice { get; set; }
       
       /// <summary>
       /// 保修
       /// </summary>
       [DisplayName("保修")]
       public string has_warranty { get; set; }
       
       /// <summary>
       /// 放入仓库
       /// </summary>
       [DisplayName("放入仓库")]
       public string approve_status { get; set; }
       
       /// <summary>
       /// 橱窗推荐
       /// </summary>
       [DisplayName("橱窗推荐")]
       public string has_showcase { get; set; }
       
       /// <summary>
       /// 开始时间
       /// </summary>
       [DisplayName("开始时间")]
       public string list_time { get; set; }
       
       /// <summary>
       /// 宝贝描述
       /// </summary>
       [DisplayName("宝贝描述")]
       public string description { get; set; }
       
       /// <summary>
       /// 宝贝属性
       /// </summary>
       [DisplayName("宝贝属性")]
       public string cateProps { get; set; }
       
       /// <summary>
       /// 邮费模版ID
       /// </summary>
       [DisplayName("邮费模版ID")]
       public string postage_id { get; set; }
       
       /// <summary>
       /// 会员打折
       /// </summary>
       [DisplayName("会员打折")]
       public string has_discount { get; set; }
       
       /// <summary>
       /// 修改时间
       /// </summary>
       [DisplayName("修改时间")]
       public string modified { get; set; }
       
       /// <summary>
       /// 上传状态
       /// </summary>
       [DisplayName("上传状态")]
       public string upload_fail_msg { get; set; }
       
       /// <summary>
       /// 图片状态
       /// </summary>
       [DisplayName("图片状态")]
       public string picture_status { get; set; }
       
       /// <summary>
       /// 返点比例
       /// </summary>
       [DisplayName("返点比例")]
       public string auction_point { get; set; }
       
       /// <summary>
       /// 新图片
       /// </summary>
       [DisplayName("新图片")]
       public string picture { get; set; }
       
       /// <summary>
       /// 视频
       /// </summary>
       [DisplayName("视频")]
       public string video { get; set; }
       
       /// <summary>
       /// 销售属性组合
       /// </summary>
       [DisplayName("销售属性组合")]
       public string skuProps { get; set; }
       
       /// <summary>
       /// 用户输入ID串
       /// </summary>
       [DisplayName("用户输入ID串")]
       public string inputPids { get; set; }
       
       /// <summary>
       /// 用户输入名 - 值对
       /// </summary>
       [DisplayName("用户输入名 - 值对")]
       public string inputValues { get; set; }
       
       /// <summary>
       /// 商家编码
       /// </summary>
       [DisplayName("商家编码")]
       public string outer_id { get; set; }
       
       /// <summary>
       /// 销售属性别名
       /// </summary>
       [DisplayName("销售属性别名")]
       public string propAlias { get; set; }
       
       /// <summary>
       /// 代充类型
       /// </summary>
       [DisplayName("代充类型")]
       public string auto_fill { get; set; }
       
       /// <summary>
       /// 数字ID
       /// </summary>
       [DisplayName("数字ID")]
       public string num_id { get; set; }
       
       /// <summary>
       /// 本地ID
       /// </summary>
       [DisplayName("本地ID")]
       public string local_cid { get; set; }
       
       /// <summary>
       /// 宝贝分类
       /// </summary>
       [DisplayName("宝贝分类")]
       public string navigation_type { get; set; }
       
       /// <summary>
       /// 用户名称
       /// </summary>
       [DisplayName("用户名称")]
       public string user_name { get; set; }
       
       /// <summary>
       /// 宝贝状态
       /// </summary>
       [DisplayName("宝贝状态")]
       public string syncStatus { get; set; }
       
       /// <summary>
       /// 闪电发货
       /// </summary>
       [DisplayName("闪电发货")]
       public string is_lighting_consigment { get; set; }
       
       /// <summary>
       /// 新品
       /// </summary>
       [DisplayName("新品")]
       public string is_xinpin { get; set; }
       
       /// <summary>
       /// 食品专项
       /// </summary>
       [DisplayName("食品专项")]
       public string foodparame { get; set; }
       
       /// <summary>
       /// 尺码库
       /// </summary>
       [DisplayName("尺码库")]
       public string features { get; set; }
       
       /// <summary>
       /// 采购地
       /// </summary>
       [DisplayName("采购地")]
       public string buyareatype { get; set; }
       
       /// <summary>
       /// 库存类型
       /// </summary>
       [DisplayName("库存类型")]
       public string global_stock_type { get; set; }
       
       /// <summary>
       /// 国家地区
       /// </summary>
       [DisplayName("国家地区")]
       public string global_stock_country { get; set; }
       
       /// <summary>
       /// 库存计数
       /// </summary>
       [DisplayName("库存计数")]
       public string sub_stock_type { get; set; }
       
       /// <summary>
       /// 物流体积
       /// </summary>
       [DisplayName("物流体积")]
       public string item_size { get; set; }
       
       /// <summary>
       /// 物流重量
       /// </summary>
       [DisplayName("物流重量")]
       public string item_weight { get; set; }
       
       /// <summary>
       /// 退换货承诺
       /// </summary>
       [DisplayName("退换货承诺")]
       public string sell_promise { get; set; }
       
       /// <summary>
       /// 定制工具
       /// </summary>
       [DisplayName("定制工具")]
       public string custom_design_flag { get; set; }
       
       /// <summary>
       /// 无线详情
       /// </summary>
       [DisplayName("无线详情")]
       public string wireless_desc { get; set; }
       
       /// <summary>
       /// 商品条形码
       /// </summary>
       [DisplayName("商品条形码")]
       public string barcode { get; set; }
       
       /// <summary>
       /// sku 条形码
       /// </summary>
       [DisplayName("sku 条形码")]
       public string sku_barcode { get; set; }
       
       /// <summary>
       /// 7天退货
       /// </summary>
       [DisplayName("7天退货")]
       public string newprepay { get; set; }
       
       /// <summary>
       /// 宝贝卖点
       /// </summary>
       [DisplayName("宝贝卖点")]
       public string subtitle { get; set; }
       
       /// <summary>
       /// 属性值备注
       /// </summary>
       [DisplayName("属性值备注")]
       public string cpv_memo { get; set; }
       
       /// <summary>
       /// 自定义属性值
       /// </summary>
       [DisplayName("自定义属性值")]
       public string input_custom_cpv { get; set; }
       
       /// <summary>
       /// 商品资质
       /// </summary>
       [DisplayName("商品资质")]
       public string qualification { get; set; }
       
       /// <summary>
       /// 增加商品资质
       /// </summary>
       [DisplayName("增加商品资质")]
       public string add_qualification { get; set; }
       
       /// <summary>
       /// 关联线下服务
       /// </summary>
       [DisplayName("关联线下服务")]
       public string o2o_bind_service { get; set; }
       
       /// <summary>
       /// 数据类型(英文标题中文标题数据)
       /// </summary>
       [DisplayName("数据类型(英文标题中文标题数据)")]
       public int datatype { get; set; }

        /// <summary>
        /// 搜鞋url
        /// </summary>
        [DisplayName("搜鞋url")]
        public string sxurl { get; set; }

        /// <summary>
        /// 淘宝url
        /// </summary>
        [DisplayName("淘宝url")]
        public string tburl { get; set; }

    }
}