using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Domain;
using yanzhilong.filter;
using yanzhilong.Helper;
using yanzhilong.Models;
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

        public ActionResult Login()
        {
            UserLoginModel ulm = new UserLoginModel();
            return View(ulm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginModel ulm)
        {
            if (ModelState.IsValid)
            {
                UserLoginResultEnum userLoginResultEnum = userCRUD.ValidateUser(ulm.UserNameOrEmailOrPhoneNumber, ulm.Password);
                if (userLoginResultEnum == UserLoginResultEnum.Successful)
                {
                    var mUser = userCRUD.GetEntry(new User { UserName = ulm.UserNameOrEmailOrPhoneNumber });
                    if(mUser == null)
                    {
                        mUser = userCRUD.GetEntry(new User { Email = ulm.UserNameOrEmailOrPhoneNumber });
                    }
                    if (mUser == null)
                    {
                        mUser = userCRUD.GetEntry(new User { PhoneNumber = ulm.UserNameOrEmailOrPhoneNumber });
                    }
                    //保存session
                    HttpContext.Session["UserID"] = mUser.Id;
                    //string userID = HttpContext.Session["UserID"] as string;
                    return RedirectToAction("Index");
                }
            }
            return View("Login");
        }

        public ActionResult Register()
        {
            UserRegisterModel urm = new UserRegisterModel();
            urm.RegisterTypeItems = new List<SelectListItem>();
            urm.RegisterTypeItems.Add(new SelectListItem { Value = (int)UserRegisterTypeEnum.UserName + "", Text = "用户名注册"});
            urm.RegisterTypeItems.Add(new SelectListItem { Value = (int)UserRegisterTypeEnum.Email + "", Text = "邮箱注册" });
            urm.RegisterTypeItems.Add(new SelectListItem { Value = (int)UserRegisterTypeEnum.PhoneNumber + "", Text = "手机注册" });

            return View(urm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegisterModel urm)
        {
            User user = new Domain.User();
            switch (urm.RegisterType)
            {
                case (int)UserRegisterTypeEnum.UserName:
                    user.UserName = urm.UserName;
                    if (string.IsNullOrEmpty(urm.UserName))
                    {
                        ModelState.AddModelError("","用户名不能为空");
                    }
                    break;
                case (int)UserRegisterTypeEnum.Email:
                    user.Email = urm.Email;
                    if (string.IsNullOrEmpty(urm.Email))
                    {
                        ModelState.AddModelError("", "邮箱不能为空");
                    }
                    break;
                case (int)UserRegisterTypeEnum.PhoneNumber:
                    user.PhoneNumber = urm.PhoneNumber;
                    if (string.IsNullOrEmpty(urm.PhoneNumber))
                    {
                        ModelState.AddModelError("", "手机不能为空");
                    }
                    break;
            }
            if (ModelState.IsValid)
            {
                UserRegistResult userRegistResult = userCRUD.RegisterUser(user, urm.Password, (UserRegisterTypeEnum)urm.RegisterType);
                if (userRegistResult.Success)
                {
                    var mUser = userCRUD.GetEntry(user);

                    //保存session
                    HttpContext.Session["UserID"] = mUser.Id;
                    //string userID = HttpContext.Session["UserID"] as string;
                    return RedirectToAction("Index");
                }else
                {
                    foreach(string err in userRegistResult.Errors)
                    {
                        ModelState.AddModelError("", err);
                    }
                }
                return View("Index");
            }
            else
            {
                return View("Register");
            }
        }
    }
}