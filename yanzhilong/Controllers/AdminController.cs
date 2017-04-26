using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Helper;
using yanzhilong.Domain;
using yanzhilong.Service;

namespace yanzhilong.Controllers
{
    public class AdminController : Controller
    {
        private UserCRUD userCRUD = new UserCRUD();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                user.PasswordHash = PasswordHelper.GetMd5HashStr(user.PasswordHash);
                User user1 = userCRUD.CheckUser(user);
                if(user1 != null)
                {
                    //保存session
                    HttpContext.Session["UserID"] = user1.UserID;
                    //string userID = HttpContext.Session["UserID"] as string;
                    return RedirectToAction("Index","Manage");
                }
            }
            return View("Index");
        }
    }
}