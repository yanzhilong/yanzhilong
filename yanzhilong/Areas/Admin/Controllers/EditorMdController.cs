using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Models;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class EditorMdController : Controller
    {
        // GET: Admin/EditorMd
        public ActionResult Index(EditorModel editorModel)
        {
            return View(editorModel);
        }
    }
}