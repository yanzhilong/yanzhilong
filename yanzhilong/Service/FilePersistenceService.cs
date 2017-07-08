using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using yanzhilong.Domain;

namespace yanzhilong.Service
{
    /// <summary>
    /// 文件持久层服务类
    /// </summary>
    public class FilePersistenceService
    {
        private UploadFileService fileService = new UploadFileService();

        /// <summary>
        /// 写入上传的文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileEnum"></param>
        /// <returns></returns>
        public UploadFile WriteFile(HttpPostedFileBase file, FileEnum fileEnum)
        {
            if (file == null)
            {
                return null;
            }
            UploadFile uploadFile = new UploadFile();
            string UploadName = file.FileName;//获取上传的文件名
            string ext = System.IO.Path.GetExtension(UploadName);// 获取文件的扩展名，比如 .gif
            DateTime dt = DateTime.Now;
            string SaveName = dt.ToString("yyyyMMddHHmmssffff") + ext;//利用时间生成新文件名后再加扩展名生成完整名字

            //判断文件类型,得到路径
            string Url = MakeFilePath(fileEnum) + SaveName;
            var lastfilepath = Path.Combine(HttpContext.Current.Request.MapPath(MakeFilePath(fileEnum)), SaveName);
            try
            {
                file.SaveAs(lastfilepath);
                uploadFile.Id = Guid.NewGuid().ToString();
                uploadFile.SaveName = SaveName;
                uploadFile.UploadName = UploadName;
                uploadFile.Url = Url;
                uploadFile.Type = (int)fileEnum;
                fileService.Create(uploadFile);
                return uploadFile;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 写入淘宝的CSV文件
        /// </summary>
        /// <param name="tbItems"></param>
        /// <returns></returns>
        public UploadFile WriteFile(List<TbItem> tbItems)
        {
            if (tbItems == null)
            {
                return null;
            }
            UploadFile uploadFile = new UploadFile();
            string UploadName = "";//上传文件名
            DateTime dt = DateTime.Now;
            string SaveName = dt.ToString("yyyyMMddHHmmssffff") + ".csv";//利用时间生成新文件名后再加扩展名生成完整名字

            //判断文件类型,得到路径
            string Url = MakeFilePath(FileEnum.TEMP) + SaveName;
            var lastfilepath = Path.Combine(HttpContext.Current.Request.MapPath(MakeFilePath(FileEnum.TEMP)), SaveName);

            FileStream fileStream = new FileStream(lastfilepath, FileMode.Create, FileAccess.Write);//创建写入文件 
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            {
                //写入版本
                streamWriter.WriteLine("version 1.00");
                //写入英文标题，中文标题，及数据
                foreach (TbItem tbItem in tbItems)
                {
                    string line =
                        tbItem.title + "\t" +
                        tbItem.cid + "\t" +
                        tbItem.seller_cids + "\t" +
                        tbItem.stuff_status + "\t" +
                        tbItem.location_state + "\t" +
                        tbItem.location_city + "\t" +
                        tbItem.item_type + "\t" +
                        tbItem.price + "\t" +
                        tbItem.auction_increment + "\t" +
                        tbItem.num + "\t" +
                        tbItem.valid_thru + "\t" +
                        tbItem.freight_payer + "\t" +
                        tbItem.post_fee + "\t" +
                        tbItem.ems_fee + "\t" +
                        tbItem.express_fee + "\t" +
                        tbItem.has_invoice + "\t" +
                        tbItem.has_warranty + "\t" +
                        tbItem.approve_status + "\t" +
                        tbItem.has_showcase + "\t" +
                        tbItem.list_time + "\t" +
                        tbItem.description + "\t" +
                        tbItem.cateProps + "\t" +
                        tbItem.postage_id + "\t" +
                        tbItem.has_discount + "\t" +
                        tbItem.modified + "\t" +
                        tbItem.upload_fail_msg + "\t" +
                        tbItem.picture_status + "\t" +
                        tbItem.auction_point + "\t" +
                        tbItem.picture + "\t" +
                        tbItem.video + "\t" +
                        tbItem.skuProps + "\t" +
                        tbItem.inputPids + "\t" +
                        tbItem.inputValues + "\t" +
                        tbItem.outer_id + "\t" +
                        tbItem.propAlias + "\t" +
                        tbItem.auto_fill + "\t" +
                        tbItem.num_id + "\t" +
                        tbItem.local_cid + "\t" +
                        tbItem.navigation_type + "\t" +
                        tbItem.user_name + "\t" +
                        tbItem.syncStatus + "\t" +
                        tbItem.is_lighting_consigment + "\t" +
                        tbItem.is_xinpin + "\t" +
                        tbItem.foodparame + "\t" +
                        tbItem.features + "\t" +
                        tbItem.buyareatype + "\t" +
                        tbItem.global_stock_type + "\t" +
                        tbItem.global_stock_country + "\t" +
                        tbItem.sub_stock_type + "\t" +
                        tbItem.item_size + "\t" +
                        tbItem.item_weight + "\t" +
                        tbItem.sell_promise + "\t" +
                        tbItem.custom_design_flag + "\t" +
                        tbItem.wireless_desc + "\t" +
                        tbItem.barcode + "\t" +
                        tbItem.sku_barcode + "\t" +
                        tbItem.newprepay + "\t" +
                        tbItem.subtitle + "\t" +
                        tbItem.cpv_memo + "\t" +
                        tbItem.input_custom_cpv + "\t" +
                        tbItem.qualification + "\t" +
                        tbItem.add_qualification + "\t" +
                        tbItem.o2o_bind_service + "\t" +
                        tbItem.datatype;
                        //写入一行
                        streamWriter.WriteLine(line);
                }
                streamWriter.Close();
                fileStream.Close();
            }
            try
            {
                uploadFile.Id = Guid.NewGuid().ToString();
                uploadFile.SaveName = SaveName;
                uploadFile.UploadName = UploadName;
                uploadFile.Url = Url;
                uploadFile.Type = (int)FileEnum.TEMP;
                fileService.Create(uploadFile);
                return uploadFile;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 得到保存的路径
        /// </summary>
        /// <param name="fileEnum"></param>
        /// <returns></returns>
        private string MakeFilePath(FileEnum fileEnum)
        {
            switch (fileEnum)
            {
                case FileEnum.IMG:
                    return "/file/img/";
                case FileEnum.TEMP:
                    return "/file/temp/";
            }
            return null;
        }
    }
}