using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yanzhilong.Domain
{
    public enum TbDataTypeEnum
    {
        ENGLISHTITLE = 0,//英文标题
        CNTITLE = 1,//中文标题
        DEFAULTDATA = 2,//默认数据
        TBDATA = 3,//宝贝数据
    }


    public enum ShoeCidEnum
    {
        DIBANG = 50012906,//低帮鞋
        GAOBANG = 50012907,//高帮鞋
        TUOXIE = 50011745,//拖鞋
        LIANGXIE = 50011746,//凉鞋
    }

    public class ShoeCidHelper
    {
        public static string GetShoeCid(ShoeCidEnum sce)
        {
            switch (sce)
            {
                case ShoeCidEnum.DIBANG:

                    return "低帮鞋";
                case ShoeCidEnum.GAOBANG:

                    return "高帮鞋";
                case ShoeCidEnum.TUOXIE:

                    return "拖鞋";
                case ShoeCidEnum.LIANGXIE:

                    return "凉鞋";
            }
            return null;
        }

        public static List<SelectListItem> GetShoeCidItems()
        {
            List<SelectListItem> shoeCidItems = new List<SelectListItem>();
            shoeCidItems.Add(new SelectListItem { Value = "0", Text = "请选择" });
            shoeCidItems.Add(new SelectListItem { Value = (int)ShoeCidEnum.DIBANG + "", Text = "低帮鞋" });
            shoeCidItems.Add(new SelectListItem { Value = (int)ShoeCidEnum.GAOBANG + "", Text = "高帮鞋" });
            shoeCidItems.Add(new SelectListItem { Value = (int)ShoeCidEnum.TUOXIE + "", Text = "拖鞋" });
            shoeCidItems.Add(new SelectListItem { Value = (int)ShoeCidEnum.LIANGXIE + "", Text = "凉鞋" });

            return shoeCidItems;
        }
    }
}