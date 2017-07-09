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

        }
        
    }
}
