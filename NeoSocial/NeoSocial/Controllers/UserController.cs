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

          

            Session["UserId"] = _loginBusiness.findUserIdByName(HttpContext.User.Identity.Name.ToString(),_userLogin);

            return Redirect("~/Main/MainPage");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(ViewModel viewModel)
        {
          

            string _userName = viewModel.login.UserName.ToString();
            string _userPassword = viewModel.login.UserPassword.ToString();
            int _userId = _loginBusiness.verifyUser(viewModel.login);

            if (ModelState.IsValid && _userId != -1)
            {
                FormsAuthentication.SetAuthCookie(_userName, true);
                Session["UserName"] = _userName;
                Session["Password"] = _userPassword;
                Session["UserId"] = _userId;

                return Redirect("~/Main/MainPage");
            }
            else
            {
                ModelState.AddModelError( "", "Kullanıcı Adı yada Parola Hatalı !");
            }
            return View(viewModel);
            
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
        public ActionResult ForgotPassword(Mail mail)
        {
           
           _userRegister.Email=mail.ToEmail;

          list=  _registerBusiness.findID(_userRegister);

        list2= _mailBusiness.findPassword(list[0].UserRegisterID);

        mail.FromEmail = "mertkozcan@outlook.com";
        mail.Subject = "Şifre";
        mail.Message = list2[0].UserPassword;

        _mailBusiness.sendMail(mail);

            return View();
        }

    }
}
