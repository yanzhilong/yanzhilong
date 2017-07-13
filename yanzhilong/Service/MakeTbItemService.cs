using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Repository;
using yanzhilong.Domain;
using System.Text.RegularExpressions;

namespace yanzhilong.Service
{
    public class MakeTbItemService
    {
        #region Fields

        private TbItemService tbItemService = new TbItemService();
        private TbPropertyService tbPropertyService = new TbPropertyService();
        private TbPropertyCategoryService tbPropertyCategoryService = new TbPropertyCategoryService();
        private SxShoeServiceMB sxShoeServiceMB = new SxShoeServiceMB();
        private SxColorServiceMB sxColorServiceMB = new SxColorServiceMB();
        private SxImageServiceMB sxImageServiceMB = new SxImageServiceMB();
        private SxMainImageServiceMB sxMainImageServiceMB = new SxMainImageServiceMB();
        private SxPropertyServiceMB sxPropertyServiceMB = new SxPropertyServiceMB();
        private SxSsizeServiceMB sxSsizeServiceMB = new SxSsizeServiceMB();
        private TbPropertyMappingService tbPropertyMappingService = new TbPropertyMappingService();
        private float AddPrice = 30;
        
        #endregion

        public TbItem makeTbItem(SxShoe sxShoe)
        {
            TbItem tbItem = tbItemService.GetEntry(new TbItem { DataTypeEnum = TbDataTypeEnum.DEFAULTDATA });
            tbItem.DataTypeEnum = TbDataTypeEnum.TBDATA;
            tbItem.Id = Guid.NewGuid().ToString();
            tbItem.title = sxShoe.Title;
            tbItem.price = (sxShoe.Price + AddPrice).ToString();
            tbItem.cid = makeTbItemCid(sxShoe);
            tbItem.description = makeTbItemDescription(sxShoe);
            string[] catePropsAndinput_custom_cpvAndskuProps = makeTbItemCateProps(sxShoe);
            tbItem.cateProps = catePropsAndinput_custom_cpvAndskuProps[0];//宝贝属性
            tbItem.input_custom_cpv = catePropsAndinput_custom_cpvAndskuProps[1];//自定义属性
            tbItem.skuProps = catePropsAndinput_custom_cpvAndskuProps[2];//销售属性
            tbItem.picture = makeTbItempicture(sxShoe);
            tbItem.outer_id = sxShoe.Number;

            return tbItem;
        }

        /// <summary>
        /// 销售属性组合，尺码，数量，颜色，价格
        /// 35(价格):35(价格)::1627207(颜色编号):28335(颜色值);20549(尺码编号):670(尺码值);
        /// </summary>
        /// <param name="sxShoe"></param>
        /// <returns></returns>
        //private string makeTbItemSkuProps(SxShoe sxShoe)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// 新图片，主图
        /// </summary>
        /// <param name="sxShoe"></param>
        /// <returns></returns>
        private string makeTbItempicture(SxShoe sxShoe)
        {
            StringBuilder sb = new StringBuilder();
            IList<SxMainImage> sxMainImages = sxMainImageServiceMB.GetEntrys(new SxMainImage { sxShoe = new SxShoe { Id = sxShoe.Id }, Sort = -1 }).ToList<SxMainImage>();
            int index = 0;
            foreach (SxMainImage sx in sxMainImages)
            {
                //提取url后面的文件名字
                string RegexStr = @"\d.*\.jpg";
                Match mt = Regex.Match(sx.Url, RegexStr);
                sb.Append(mt.Value + ":1:" + index + ":|;");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 定义宝贝属性（颜色、尺码），类目，款式等 ....
        /// </summary>
        /// <param name="sxShoe"></param>
        /// <returns>返回数组，0是宝贝属性，1是自定义的颜色属性2,是销售属性</returns>
        private string[] makeTbItemCateProps(SxShoe sxShoe)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder customProperty = new StringBuilder();//自定义属性
            StringBuilder saleProperty = new StringBuilder();//自定义属性

            List<int> sale = new List<int>();//用于存放自定义属性

            int customNum = -1001;
            //品牌:其它
            sb.Append("20000:29534;");
            //颜色
            IList<SxColor> sxColors = sxColorServiceMB.GetEntrys(new SxColor { sxShoe = new SxShoe { Id = sxShoe.Id } }).ToList<SxColor>();

            TbPropertyCategory tbPropertyCategorycolor = tbPropertyCategoryService.GetEntry(new TbPropertyCategory { Name = "颜色" });

            TbPropertyCategory tbPropertyCategorysize = tbPropertyCategoryService.GetEntry(new TbPropertyCategory { Name = "尺码" });

            IList<TbProperty> tbPropertyscolor = tbPropertyService.GetEntrys(new TbProperty { tbPropertyCategory = new TbPropertyCategory { Id = tbPropertyCategorycolor.Id } }).ToList<TbProperty>();

            IList<TbProperty> tbPropertyssize = tbPropertyService.GetEntrys(new TbProperty { tbPropertyCategory = new TbPropertyCategory { Id = tbPropertyCategorysize.Id } }).ToList<TbProperty>();

            IList<SxSsize> sxSizes = sxSsizeServiceMB.GetEntrys(new SxSsize { sxShoe = new SxShoe { Id = sxShoe.Id }, Num = -1 }).ToList<SxSsize>();

            int mCustomNum = 0;
            foreach (SxColor sxColor in sxColors)
            {
                bool isFind = false;
                TbProperty mTp = null;
                foreach (TbProperty tp in tbPropertyscolor)
                {
                    
                    if (sxColor.Name.Equals(tp.Name))
                    {
                        sb.Append(tbPropertyCategorycolor.ValueKey + ":" + tp.ValueKey + ";");
                        isFind = true;
                        mTp = tp;
                        break;
                    }
                }
                //这个颜色没找到，要添加到自定义中
                if (!isFind)
                {
                    mCustomNum = customNum;
                    //添加自定义的宝贝属性
                    sb.Append(tbPropertyCategorycolor.ValueKey + ":" + customNum + ";");
                    //添加自定义属性名称
                    customProperty.Append(tbPropertyCategorycolor.ValueKey + ":" + customNum + ":" + sxColor.Name + ";");
                    customNum--;
                }
                //添加这个颜色的尺码，保存到销售属性中
                foreach (SxSsize sxSize in sxSizes)
                {
                    foreach (TbProperty tpsize in tbPropertyssize)
                    {
                        if (sxSize.Num == int.Parse(tpsize.Name))
                        {
                            //添加销售
                            saleProperty.Append((sxShoe.Price + AddPrice).ToString() + ":100::" + tbPropertyCategorycolor.ValueKey + ":" + (mCustomNum == 0 ? mTp.ValueKey : mCustomNum + "") + ";");
                            saleProperty.Append(tbPropertyCategorysize.ValueKey + ":" + tpsize.ValueKey + ";");
                        }
                    }
                }
            }
            //尺码

            //属性
            IList<SxProperty> sxPropertys = sxPropertyServiceMB.GetEntrys(new SxProperty { sxShoe = new SxShoe { Id = sxShoe.Id } }).ToList<SxProperty>();

            List<TbPropertyCategory> tbPropertyCategorys = tbPropertyCategoryService.GetEntrys(new TbPropertyCategory { }).ToList<TbPropertyCategory>();

            foreach (SxProperty sp in sxPropertys)
            {
                foreach (TbPropertyCategory tpc in tbPropertyCategorys)
                {
                    if (tpc.Name.Contains(sp.Name))
                    {
                        List<TbPropertyMapping> tpms = tbPropertyMappingService.GetEntrys(new TbPropertyMapping { tbPropertyCategory = new TbPropertyCategory { Id = tpc.Id } } ).ToList<TbPropertyMapping>();
                        IList<TbProperty> tbPropertys = new List<TbProperty>();
                        foreach (TbPropertyMapping tpm in tpms)
                        {
                            TbProperty tp = tbPropertyService.GetEntry(tpm.tbProperty);
                            if(tp != null)
                            {
                                tbPropertys.Add(tp);
                            }
                        }

                        foreach(TbProperty tp in tbPropertys)
                        {
                            if (tp.Name.Contains(sp.Value))
                            {
                                sb.Append(tpc.ValueKey + ":" + tp.ValueKey + ";");
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            return new string[] { sb.ToString(), customProperty.ToString(), saleProperty.ToString() };
        }



        /// <summary>
        /// 定义宝贝描述
        /// </summary>
        /// <param name="sxShoe"></param>
        /// <returns></returns>
        private string makeTbItemDescription(SxShoe sxShoe)
        {
            StringBuilder sb = new StringBuilder();
            IList<SxImage> sxImages = sxImageServiceMB.GetEntrys(new SxImage { sxShoe = new SxShoe { Id = sxShoe.Id},Sort = -1 }).ToList<SxImage>();
            foreach(SxImage sx in sxImages)
            {
                //提取url后面的文件名字
                //string[] urlspl = sx.Url.Split("\\");
                string RegexStr = @"\d.*\.jpg";
                Match mt = Regex.Match(sx.Url, RegexStr);
                string path = string.Format("<IMG align=middle src=\"FILE:///d:\\sooxie\\{0}\">", mt.Value);
                sb.Append(path);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 判断当前鞋子的类目
        /// </summary>
        /// <param name="sxShoe"></param>
        /// <returns></returns>
        private string makeTbItemCid(SxShoe sxShoe)
        {
            IList<SxProperty> sxPropertys = sxPropertyServiceMB.GetEntrys(new SxProperty { sxShoe = new SxShoe { Id = sxShoe.Id } }).ToList<SxProperty>();
            //得到款式
            string kuanshi = null;
            string xietoukuanshi = null;
            foreach (SxProperty sxProperty in sxPropertys)
            {
                if (sxProperty.Name.Equals("款式"))
                {
                    kuanshi = sxProperty.Value;
                }
                if (sxProperty.Name.Equals("鞋头款式"))
                {
                    xietoukuanshi = sxProperty.Value;
                }
            }
            if((kuanshi != null && (kuanshi.Equals("一字拖") || kuanshi.Equals("夹趾") || kuanshi.Equals("人字拖"))) || (xietoukuanshi != null && xietoukuanshi.Equals("夹趾")))
            {
                return "50011746"; //拖鞋
            }
            if (kuanshi != null && (kuanshi.Equals("高帮板鞋") || kuanshi.Equals("布洛克高帮鞋") || kuanshi.Equals("高帮工装鞋") || kuanshi.Equals("马丁靴"))) 
            {
                return "50012907"; //高帮
            }
            if (sxShoe.Title.Contains("凉鞋") ||( xietoukuanshi != null && (xietoukuanshi.Equals("露趾") || xietoukuanshi.Equals("套趾"))) || (kuanshi != null && kuanshi.Equals("马丁靴")))
            {
                return "50011745"; //凉鞋
            }
            if (sxShoe.Title.Contains("拖鞋") )
            {
                return "50011746"; //拖鞋
            }
            return "50012906"; //低帮鞋
        }
    }
}
