using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using United.NoteApp.Business.Abstract;
using United.NoteApp.Business.Concrete;
using United.NoteApp.DataAccess.Concrete.EntityFramework;
using United.NoteApp.Entities.Concrete;
using United.NoteApp.MVC.Models;

namespace United.NoteApp.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService = new UserManager(new EfUserDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
            var user = _userService.GetByName(userModel.UserName);
            if (user != null && userModel.Password.Equals(user.Password))
            {
                HttpCookie cookieLogin = new HttpCookie("UserId", user.Id.ToString());
                Response.Cookies.Add(cookieLogin);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Register(UserModel userModel)
        {
            var user = new User
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                UserName = userModel.UserName,
                Password = userModel.Password
            };
            _userService.Add(user);
            return Json(user, JsonRequestBehavior.AllowGet);
        }
    }
}