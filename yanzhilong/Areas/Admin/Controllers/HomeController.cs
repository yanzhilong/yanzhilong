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
                UserLoginResultEnum userLoginResultEnum = userCRUD.ValidateUser(user.UserName,user.PasswordHash);
                if (userLoginResultEnum == UserLoginResultEnum.Successful)
                {
                    var mUser = userCRUD.GetEntry(new User { UserName = user.UserName });

                    //保存session
                    HttpContext.Session["UserID"] = mUser.Id;
                    //string userID = HttpContext.Session["UserID"] as string;
                    return RedirectToAction("Index");
                }
            }
            return View("Login");
        }
    }
}