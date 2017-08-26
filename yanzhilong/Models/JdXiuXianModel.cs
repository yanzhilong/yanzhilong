using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yanzhilong.Models
{
    public class JdXiuXianModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "必选项")]
        [DisplayName("属性标题")]
        public string Title { get; set; }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("标语")]
        public string addWareVOadContent { get {
                return addWareVOadContent;
            } set {
                addWareVOadContent = "#addWareVO\\.adContent@" + value;
            }
        }//标语
        [Required(ErrorMessage = "必选项")]
        [DisplayName("品牌")]
        public string combobox_caption_brandId {
            get
            {
                return combobox_caption_brandId;
            }
            set
            {
                combobox_caption_brandId = "#combobox-caption-brandId@" + value;
            }
        }//品牌
        [Required(ErrorMessage = "必选项")]
        [DisplayName("7天无理由退货")]
        public string addWareVOis7ToReturn { get; set; }//7天无理由退货
        public IList<SelectListItem> addWareVOis7ToReturnItems { get {

                var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}};
                selectItemList.Add(new SelectListItem { Value = "#addWareVO\\.is7ToReturn@1", Text = "支持" });
                selectItemList.Add(new SelectListItem { Value = "#addWareVO\\.is7ToReturn@0", Text = "不支持" });
                return selectItemList;
            }
        }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("场合")]
        public string attid_3_1_91768 { get; set; }//场合
        public IList<SelectListItem> attid_3_1_91768Items
        {
            get
            {
                var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}};
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91768@91768:570338", Text = "时尚休闲" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91768@91768:570340", Text = "日常休闲" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91768@91768:570342", Text = "运动休闲" });

                return selectItemList;
            }
        }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("种类")]
        public string attid_3_1_11853 { get; set; }//种类
        public IList<SelectListItem> attid_3_1_11853Items
        {
            get
            {
                var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}};
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11853@11853:112838", Text = "便鞋" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11853@11853:112846", Text = "驾车鞋" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11853@11853:112855", Text = "其它" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11853@11853:114767", Text = "板鞋" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11853@11853:539166", Text = "豆豆鞋" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11853@11853:539167", Text = "懒人鞋" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11853@11853:570363", Text = "布洛克鞋" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11853@11853:570366", Text = "帆船鞋" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11853@11853:570369", Text = "乐福鞋" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11853@11853:589926", Text = "透气网鞋" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11853@11853:589927", Text = "休闲皮鞋" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11853@11853:589928", Text = "运动鞋" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11853@11853:589929", Text = "户外鞋" });

                return selectItemList;
            }
        }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("鞋面材料")]
        public string attid_3_1_11864 { get; set; }//鞋面材料
        public IList<SelectListItem> attid_3_1_11864Items
        {
            get
            {
                var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}};
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11864@11864:112931", Text = "   棉布" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11864@11864:112934", Text = "羊皮" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11864@11864:220131", Text = "人造皮革"});
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11864@11864:570497", Text = "网布"});
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11864@11864:570498", Text = "羊皮毛一体"});
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11864@11864:570499", Text = "猪皮"});
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11864@11864:570507", Text = "牛仔布鞋"});
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11864@11864:589931", Text = "二层牛皮"});
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11864@11864:589932", Text = "头层牛皮"});
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11864@11864:609631", Text = "牛皮鞋"});
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11864@11864:609632", Text = "反绒皮鞋"});
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11864@11864:609634", Text = "绒面"});
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11864@11864:722211", Text = "其它"});
                return selectItemList;
            }
        }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("里料材质")]
        public string attid_3_1_91791 { get; set; }//里料材质
        public IList<SelectListItem> attid_3_1_91791Items
        {
            get
            {
                var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}};
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91791@91791:570526", Text = "皮" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91791@91791:570528", Text = "棉布"});
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91791@91791:570530", Text = "羊毛革"});
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91791@91791:570532", Text = "人造短毛绒"});
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91791@91791:570533", Text = "人造长毛绒一体" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91791@91791:570535", Text = "人造皮革"});
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91791@91791:570537", Text = "其他鞋" });
                return selectItemList;
            }
        }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("鞋底材质")]
        public string attid_3_1_14919 { get; set; }//鞋底材质
        public IList<SelectListItem> attid_3_1_14919Items
        {
            get
            {
                var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}};
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14919@14919:221157", Text = "橡胶" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14919@14919:221159", Text = "塑胶"});
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14919@14919:222028", Text = "泡沫"});
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14919@14919:222031", Text = "其他"});
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14919@14919:570542", Text = "真皮" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14919@14919:570547", Text = "仿皮" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14919@14919:570551", Text = "人造皮革" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14919@14919:570552", Text = "复合底" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14919@14919:570554", Text = "软木" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14919@14919:570555", Text = "千层底" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14919@14919:589933", Text = "TPR底" });

                return selectItemList;
            }
        }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("闭合方式")]
        public string attid_3_1_14850 { get; set; }//闭合方式
        public IList<SelectListItem> attid_3_1_14850Items
        {
            get
            {
                var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}};
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14850@14850:220185", Text = "系带" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14850@14850:220188", Text = "搭扣" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14850@14850:220191", Text = "套脚" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14850@14850:220193", Text = "魔术贴" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14850@14850:220196", Text = "松紧带" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14850@14850:589934", Text = "其他" });
                return selectItemList;
            }
        }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("鞋头款式")]
        public string attid_3_1_14888 { get; set; }//鞋头款式
        public IList<SelectListItem> attid_3_1_14888Items
        {
            get
            {
                var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}};
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14888@14888:220845", Text = "圆头" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14888@14888:220849", Text = "尖头" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14888@14888:220853", Text = "方头" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14888@14888:220855", Text = "扁头" });

                return selectItemList;
            }
        }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("价格")]
        public string attid_3_1_11839 { get; set; }//价格
        public IList<SelectListItem> attid_3_1_11839Items
        {
            get
            {
                var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}};
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11839@11839:112870", Text = "100-199" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11839@11839:112871", Text = "200-299" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_11839@11839:570565", Text = "1-99" });

                return selectItemList;
            }
        }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("上市年份季节")]
        public string attid_3_1_104886 { get; set; }//上市年份季节
        public IList<SelectListItem> attid_3_1_104886Items
        {
            get
            {
                var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}};
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_104886@104886:702267", Text = "2017春季" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_104886@104886:708732", Text = "2017夏季" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_104886@104886:719352", Text = "2017秋季" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_104886@104886:719353", Text = "2017冬季" });
                return selectItemList;
            }
        }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("制作工艺")]
        public string attid_3_1_91794 { get; set; }//制作工艺
        public IList<SelectListItem> attid_3_1_91794Items
        {
            get
            {
                var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}};
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91794@91794:570618", Text = "纯手工" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91794@91794:570619", Text = "固特异" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91794@91794:570620", Text = "缝制鞋" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91794@91794:570621", Text = "胶粘鞋" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91794@91794:570622", Text = "注压鞋" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91794@91794:570623", Text = "其他" });
                return selectItemList;
            }
        }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("风格")]
        public string attid_3_1_14941 { get; set; }//风格
        public IList<SelectListItem> attid_3_1_14941Items
        {
            get
            {
                var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}};
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14941@14941:222420", Text = "英伦 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14941@14941:222425", Text = "欧美 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14941@14941:222428", Text = "日系 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14941@14941:222431", Text = "学院派" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14941@14941:222435", Text = "中国风" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14941@14941:570656", Text = "民族风" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14941@14941:570657", Text = "韩版 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14941@14941:570659", Text = "简约 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14941@14941:570660", Text = "复古 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14941@14941:570662", Text = "朋克 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14941@14941:570704", Text = "百搭 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_14941@14941:722212", Text = "其它 " });
                return selectItemList;
            }
        }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("流行元素")]
        public string attid_3_1_91800 { get; set; }//流行元素
        public IList<SelectListItem> attid_3_1_91800Items
        {
            get
            {
                var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}};
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91800@91800:570688", Text = "鳄鱼纹 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91800@91800:570690", Text = "图腾 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91800@91800:570691", Text = "柳钉 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91800@91800:570692", Text = "车缝线 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91800@91800:570693", Text = "金属 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91800@91800:570694", Text = "皮革拼接" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91800@91800:570695", Text = "绣花 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91800@91800:570697", Text = "镂空 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91800@91800:570701", Text = "荧光 " });
                return selectItemList;
            }
        }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("皮革风格")]
        public string attid_3_1_91801 { get; set; }//皮革风格
        public IList<SelectListItem> attid_3_1_91801Items
        {
            get
            {
                var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}};
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91801@91801:570705", Text = "磨砂皮 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91801@91801:570706", Text = "软面皮" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91801@91801:570707", Text = "漆皮 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91801@91801:570712", Text = "油蜡皮 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91801@91801:570721", Text = "其他 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91801@91801:589939", Text = "贴膜皮" });
                return selectItemList;
            }
        }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("功能")]
        public string attid_3_1_91805 { get; set; }//功能
        public IList<SelectListItem> attid_3_1_91805Items
        {
            get
            {
                var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}};
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91805@91805:570726", Text = "透气 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91805@91805:570728", Text = "轻质" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91805@91805:570729", Text = "保暖" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91805@91805:570731", Text = "耐磨 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91805@91805:570732", Text = "减震" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91805@91805:570734", Text = "增高" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91805@91805:589944", Text = "防水 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91805@91805:589945", Text = "吸汗" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91805@91805:589946", Text = "防滑" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91805@91805:589947", Text = "支撑 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91805@91805:589948", Text = "平衡" });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91805@91805:722213", Text = "其它" });
                return selectItemList;
            }
        }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("鞋跟")]
        public string attid_3_1_91806 { get; set; }//鞋跟
        public IList<SelectListItem> attid_3_1_91806Items
        {
            get
            {
                var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}};
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91806@91806:570754", Text = "内增高 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91806@91806:589950", Text = "平底 " });
                selectItemList.Add(new SelectListItem { Value = "#attid_3_1_91806@91806:589951", Text = "有跟 " });
                return selectItemList;
            }
        }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("商品毛重")]
        public string addWareVOweight
        {
            get
            {
                return addWareVOweight;
            }
            set
            {
                addWareVOweight = "#addWareVO\\.weight@" + value;
            }
        }//商品毛重
        [Required(ErrorMessage = "必选项")]
        [DisplayName("[包装]长")]
        public string addWareVOlength
        {
            get
            {
                return addWareVOlength;
            }
            set
            {
                addWareVOlength = "#addWareVO\\.length@" + value;
            }
        }//[包装]长
        [Required(ErrorMessage = "必选项")]
        [DisplayName("[包装]宽")]
        public string addWareVOwide
        {
            get
            {
                return addWareVOwide;
            }
            set
            {
                addWareVOwide = "#addWareVO\\.wide@" + value;
            }
        }//[包装]宽
        [Required(ErrorMessage = "必选项")]
        [DisplayName("/[包装]高")]
        public string addWareVOhigh
        {
            get
            {
                return addWareVOhigh;
            }
            set
            {
                addWareVOhigh = "#addWareVO\\.high@" + value;
            }
        }//[包装]高
        [Required(ErrorMessage = "必选项")]
        [DisplayName("发货地 省")]
        public string areaId1 { get; set; }//发货地 省
        public IList<SelectListItem> areaId1Items
        {
            get
            {
                var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}};
                selectItemList.Add(new SelectListItem { Value = "#areaId1@16", Text = "福建 " });
                return selectItemList;
            }
        }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("发货地 市")]
        public string areaId2 { get; set; }//发货地 市
        public IList<SelectListItem> areaId2Items
        {
            get
            {
                var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}};
                selectItemList.Add(new SelectListItem { Value = "##areaId2@1332", Text = "泉州" });
                return selectItemList;
            }
        }
        [Required(ErrorMessage = "必选项")]
        [DisplayName("运费模版")]
        public string fareId { get; set; }//运费模版
    }
}