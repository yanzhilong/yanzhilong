using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Models;

namespace yanzhilong.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryCRUD categoryCRUD = new CategoryCRUD();

        public ActionResult SideBar()
        {
            IList<ActicleCount> acticleCounts = categoryCRUD.GetArticlesCountGroupByCategory();
            return PartialView("CategorySide", acticleCounts);
        }
    }
}