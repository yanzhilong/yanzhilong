using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanzhilong.Repository;
using yanzhilong.Domain;

namespace yanzhilong.Service
{
    public class MakeTbItemService
    {
        #region Fields

        private TbItemService tbItemService = new TbItemService();
        private SxShoeServiceMB sxShoeServiceMB = new SxShoeServiceMB();
        private SxColorServiceMB sxColorServiceMB = new SxColorServiceMB();
        private SxImageServiceMB sxImageServiceMB = new SxImageServiceMB();
        private SxMainImageServiceMB sxMainImageServiceMB = new SxMainImageServiceMB();
        private SxPropertyServiceMB sxPropertyServiceMB = new SxPropertyServiceMB();
        private SxSsizeServiceMB sxSsizeServiceMB = new SxSsizeServiceMB();

        
        #endregion

        public MakeTbItemService(SxShoe sxShoe)
        {
            TbItem tbItem = tbItemService.GetEntry(new TbItem { DataTypeEnum = TbDataTypeEnum.DEFAULTDATA });
            tbItem.Id = Guid.NewGuid().ToString();
            tbItem.title = sxShoe.Title;
            tbItem.price = (sxShoe.Price + 30).ToString();
            tbItem.cid = makeTbItemCid(sxShoe);
            tbItem.description = makeTbItemDescription(sxShoe);
            tbItem.cateProps = makeTbItemCateProps(sxShoe);
            tbItem.picture_status = makeTbItemPictureStatus(sxShoe);
            tbItem.picture = makeTbItempicture(sxShoe);
            tbItem.skuProps = makeTbItemSkuProps(sxShoe);
            tbItem.outer_id = sxShoe.Number;

        }

        /// <summary>
        /// 销售属性组合，尺码，数量，颜色，价格
        /// 35(数量):35(价格)::1627207(颜色编号):28335(颜色值);20549(尺码编号):670(尺码值);
        /// </summary>
        /// <param name="sxShoe"></param>
        /// <returns></returns>
        private string makeTbItemSkuProps(SxShoe sxShoe)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新图片，主图
        /// </summary>
        /// <param name="sxShoe"></param>
        /// <returns></returns>
        private string makeTbItempicture(SxShoe sxShoe)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 图片状态，功能暂时未知
        /// </summary>
        /// <param name="sxShoe"></param>
        /// <returns></returns>
        private string makeTbItemPictureStatus(SxShoe sxShoe)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 定义宝贝属性（颜色、尺码），类目，款式等 ....
        /// </summary>
        /// <param name="sxShoe"></param>
        /// <returns></returns>
        private string makeTbItemCateProps(SxShoe sxShoe)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 定义宝贝描述
        /// </summary>
        /// <param name="sxShoe"></param>
        /// <returns></returns>
        private string makeTbItemDescription(SxShoe sxShoe)
        {
            StringBuilder sb = new StringBuilder();
            IList<SxImage> sxImages = sxImageServiceMB.GetEntrys(new SxImage { sxShoe = new SxShoe { Id = sxShoe.Id} }).ToList<SxImage>();
            foreach(SxImage sx in sxImages)
            {
                //提取url后面的文件名字
                //string[] urlspl = sx.Url.Split("\\");
                string.Format("<IMG align=middle src=\"FILE:///{0}\">", sx.Url);
            }
            return null;
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
            if(kuanshi.Equals("一字拖") || kuanshi.Equals("夹趾") || kuanshi.Equals("人字拖") || xietoukuanshi.Equals("夹趾"))
            {
                return "50011746"; //拖鞋
            }
            if (kuanshi.Equals("高帮板鞋") || kuanshi.Equals("布洛克高帮鞋") || kuanshi.Equals("高帮工装鞋") || kuanshi.Equals("马丁靴")) 
            {
                return "50012907"; //高帮
            }
            if (sxShoe.Title.Contains("凉鞋") || xietoukuanshi.Equals("露趾") || xietoukuanshi.Equals("套趾") || kuanshi.Equals("马丁靴"))
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
