using NeoSocial.Business;
using NeoSocial.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NeoSocial.Database.Models;
using NeoSocial.Database.Repository;
using NeoSocial.Database.IUnitOfWork;
using NeoSocial.Business;
using NeoSocial.ViewModels;

namespace NeoSocial.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        ILoginBusiness _loginBusiness;
        IRegisterBusiness _registerBusiness;
        IMailBusiness _mailBusiness;

        UserRegister _userRegister;
        UserLogin _userLogin;

        List<UserRegister> list;
        List<UserLogin> list2;

        public UserController(
            UserRegister userRegister,
            UserLogin userLogin) {

                _loginBusiness = DependencyResolver.Current.GetService<ILoginBusiness>();
                _registerBusiness = DependencyResolver.Current.GetService<IRegisterBusiness>();
                _mailBusiness = DependencyResolver.Current.GetService<IMailBusiness>();
                _userRegister = userRegister;
                _userLogin = userLogin;
        
        }


        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }

          

            Session["UserId"] = _loginBusiness.findUserIdByName(HttpContext.User.Identity.Name.ToString());

            return Redirect("~/Main/MainPage");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {

              int _userId = _loginBusiness.verifyUser(loginModel.UserName, loginModel.UserPassword);

              if (ModelState.IsValid && _userId != -1)
              {
                  FormsAuthentication.SetAuthCookie(loginModel.UserName, true);
                  Session["UserId"] = _userId;

                  return Redirect("~/Main/MainPage");
              }
              else
              {
                  ModelState.AddModelError( "", "Kullanıcı Adı yada Parola Hatalı !");
              }


             return View(loginModel);
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

         [AllowAnonymous]
        [HttpGet]
        public ActionResult ForgotPassword() {
        
        return View();
        
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ForgotPassword(MailModel mailModel)
        {
           /*
           _userRegister.Email=mail.ToEmail;

          list=  _registerBusiness.findID(_userRegister);

        list2= _mailBusiness.findPassword(list[0].UserRegisterID);

        mail.FromEmail = "mertkozcan@outlook.com";
        mail.Subject = "Şifre";
        mail.Message = list2[0].UserPassword;

        _mailBusiness.sendMail(mail);*/

            return View();
        }

    }
}
