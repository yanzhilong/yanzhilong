using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Domain;
using yanzhilong.filter;
using yanzhilong.Helper;
using yanzhilong.Service;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private UserService userCRUD = new UserService();

        // GET: Admin/Home
        [Authentication]
        public ActionResult Index()
        {
            return View();
        }

        [Authentication]
        public ActionResult Index1()
        {
            return View();
        }


        public ActionResult Login()
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
                if (user1 != null)
                {
                    //保存session
                    HttpContext.Session["UserID"] = user1.Id;
                    //string userID = HttpContext.Session["UserID"] as string;
                    return RedirectToAction("Index");
                }
            }
            return View("Login");
        }
    }
}