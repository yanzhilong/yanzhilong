using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yanzhilong.Domain
{
    public class TbItem
    {
        
       /// <summary>
       /// 编号
       /// </summary>
       public string Id { get; set; }
       
       /// <summary>
       /// 宝贝名称
       /// </summary>
       public string title { get; set; }
       
       /// <summary>
       /// 宝贝类目
       /// </summary>
       public string cid { get; set; }
       
       /// <summary>
       /// 店铺类目
       /// </summary>
       public string seller_cids { get; set; }
       
       /// <summary>
       /// 新旧程度
       /// </summary>
       public string stuff_status { get; set; }
       
       /// <summary>
       /// 省
       /// </summary>
       public string location_state { get; set; }
       
       /// <summary>
       /// 城市
       /// </summary>
       public string location_city { get; set; }
       
       /// <summary>
       /// 出售方式
       /// </summary>
       public string item_type { get; set; }
       
       /// <summary>
       /// 宝贝价格
       /// </summary>
       public string price { get; set; }
       
       /// <summary>
       /// 加价幅度
       /// </summary>
       public string auction_increment { get; set; }
       
       /// <summary>
       /// 宝贝数量
       /// </summary>
       public string num { get; set; }
       
       /// <summary>
       /// 有效期
       /// </summary>
       public string valid_thru { get; set; }
       
       /// <summary>
       /// 运费承担
       /// </summary>
       public string freight_payer { get; set; }
       
       /// <summary>
       /// 平邮
       /// </summary>
       public string post_fee { get; set; }
       
       /// <summary>
       /// EMS
       /// </summary>
       public string ems_fee { get; set; }
       
       /// <summary>
       /// 快递
       /// </summary>
       public string express_fee { get; set; }
       
       /// <summary>
       /// 发票
       /// </summary>
       public string has_invoice { get; set; }
       
       /// <summary>
       /// 保修
       /// </summary>
       public string has_warranty { get; set; }
       
       /// <summary>
       /// 放入仓库
       /// </summary>
       public string approve_status { get; set; }
       
       /// <summary>
       /// 橱窗推荐
       /// </summary>
       public string has_showcase { get; set; }
       
       /// <summary>
       /// 开始时间
       /// </summary>
       public string list_time { get; set; }
       
       /// <summary>
       /// 宝贝描述
       /// </summary>
       public string description { get; set; }
       
       /// <summary>
       /// 宝贝属性
       /// </summary>
       public string cateProps { get; set; }
       
       /// <summary>
       /// 邮费模版ID
       /// </summary>
       public string postage_id { get; set; }
       
       /// <summary>
       /// 会员打折
       /// </summary>
       public string has_discount { get; set; }
       
       /// <summary>
       /// 修改时间
       /// </summary>
       public string modified { get; set; }
       
       /// <summary>
       /// 上传状态
       /// </summary>
       public string upload_fail_msg { get; set; }
       
       /// <summary>
       /// 图片状态
       /// </summary>
       public string picture_status { get; set; }
       
       /// <summary>
       /// 返点比例
       /// </summary>
       public string auction_point { get; set; }
       
       /// <summary>
       /// 新图片
       /// </summary>
       public string picture { get; set; }
       
       /// <summary>
       /// 视频
       /// </summary>
       public string video { get; set; }
       
       /// <summary>
       /// 销售属性组合
       /// </summary>
       public string skuProps { get; set; }
       
       /// <summary>
       /// 用户输入ID串
       /// </summary>
       public string inputPids { get; set; }
       
       /// <summary>
       /// 用户输入名 - 值对
       /// </summary>
       public string inputValues { get; set; }
       
       /// <summary>
       /// 商家编码
       /// </summary>
       public string outer_id { get; set; }
       
       /// <summary>
       /// 销售属性别名
       /// </summary>
       public string propAlias { get; set; }
       
       /// <summary>
       /// 代充类型
       /// </summary>
       public string auto_fill { get; set; }
       
       /// <summary>
       /// 数字ID
       /// </summary>
       public string num_id { get; set; }
       
       /// <summary>
       /// 本地ID
       /// </summary>
       public string local_cid { get; set; }
       
       /// <summary>
       /// 宝贝分类
       /// </summary>
       public string navigation_type { get; set; }
       
       /// <summary>
       /// 用户名称
       /// </summary>
       public string user_name { get; set; }
       
       /// <summary>
       /// 宝贝状态
       /// </summary>
       public string syncStatus { get; set; }
       
       /// <summary>
       /// 闪电发货
       /// </summary>
       public string is_lighting_consigment { get; set; }
       
       /// <summary>
       /// 新品
       /// </summary>
       public string is_xinpin { get; set; }
       
       /// <summary>
       /// 食品专项
       /// </summary>
       public string foodparame { get; set; }
       
       /// <summary>
       /// 尺码库
       /// </summary>
       public string features { get; set; }
       
       /// <summary>
       /// 采购地
       /// </summary>
       public string buyareatype { get; set; }
       
       /// <summary>
       /// 库存类型
       /// </summary>
       public string global_stock_type { get; set; }
       
       /// <summary>
       /// 国家地区
       /// </summary>
       public string global_stock_country { get; set; }
       
       /// <summary>
       /// 库存计数
       /// </summary>
       public string sub_stock_type { get; set; }
       
       /// <summary>
       /// 物流体积
       /// </summary>
       public string item_size { get; set; }
       
       /// <summary>
       /// 物流重量
       /// </summary>
       public string item_weight { get; set; }
       
       /// <summary>
       /// 退换货承诺
       /// </summary>
       public string sell_promise { get; set; }
       
       /// <summary>
       /// 定制工具
       /// </summary>
       public string custom_design_flag { get; set; }
       
       /// <summary>
       /// 无线详情
       /// </summary>
       public string wireless_desc { get; set; }
       
       /// <summary>
       /// 商品条形码
       /// </summary>
       public string barcode { get; set; }
       
       /// <summary>
       /// sku 条形码
       /// </summary>
       public string sku_barcode { get; set; }
       
       /// <summary>
       /// 7天退货
       /// </summary>
       public string newprepay { get; set; }
       
       /// <summary>
       /// 宝贝卖点
       /// </summary>
       public string subtitle { get; set; }
       
       /// <summary>
       /// 属性值备注
       /// </summary>
       public string cpv_memo { get; set; }
       
       /// <summary>
       /// 自定义属性值
       /// </summary>
       public string input_custom_cpv { get; set; }
       
       /// <summary>
       /// 商品资质
       /// </summary>
       public string qualification { get; set; }
       
       /// <summary>
       /// 增加商品资质
       /// </summary>
       public string add_qualification { get; set; }
       
       /// <summary>
       /// 关联线下服务
       /// </summary>
       public string o2o_bind_service { get; set; }
       
       /// <summary>
       /// 数据类型(英文标题中文标题数据)
       /// </summary>
       public int datatype { get; set; }
       

    }
}