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

       

        public UserController() {

                _loginBusiness = DependencyResolver.Current.GetService<ILoginBusiness>();
                _registerBusiness = DependencyResolver.Current.GetService<IRegisterBusiness>();
                _mailBusiness = DependencyResolver.Current.GetService<IMailBusiness>();
                
        
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

            int registerId = _registerBusiness.findRegisterIDByMail(mailModel.ToEmail);

       

       

        mailModel.FromEmail = "mertkozcan@outlook.com";
        mailModel.Subject = "Şifre";
        mailModel.Message = _mailBusiness.findPassword(registerId);

        _mailBusiness.sendMail(mailModel.FromEmail,mailModel.ToEmail,mailModel.Subject,mailModel.Message);

            return View();
        }

    }
}
