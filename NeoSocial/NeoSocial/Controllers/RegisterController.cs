using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NeoSocial.Database.Models;
using NeoSocial.Database.Repository;
using NeoSocial.Database.IUnitOfWork;
using NeoSocial.Business;
using NeoSocial.ViewModels;


namespace NeoSocial.Controllers
{
    [Authorize]
    public class RegisterController : Controller
    {
        //
        // GET: /Register/
        ICountryBusiness _countryBusiness;
        IRegisterBusiness _registerBusiness;
        ILoginBusiness _loginBusiness;
        IProfileBusiness _profileBusiness;
        RegisterDbWebModel _registerDbWebModel;


        public RegisterController(RegisterDbWebModel registerDbWebModel)
        {

                _countryBusiness = DependencyResolver.Current.GetService<ICountryBusiness>();
                _registerBusiness = DependencyResolver.Current.GetService<IRegisterBusiness>();
                _loginBusiness = DependencyResolver.Current.GetService<ILoginBusiness>();
                _profileBusiness = DependencyResolver.Current.GetService<IProfileBusiness>();

                _registerDbWebModel = registerDbWebModel;

        }

        [AllowAnonymous]
        public ActionResult Register() {
           
            ViewData["country"] = _countryBusiness.getAllCountry();


            return View();
        
        
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel registerModel)
        {

            if (!_registerBusiness.checkUser(registerModel.Email))//Kullanıcı yoksa ekle.
            {

                _registerDbWebModel.registerDatabaseModel.BirthDate = Convert.ToDateTime(registerModel.BirthDate).ToShortDateString();
                _registerDbWebModel.registerDatabaseModel.Name = registerModel.Name;
                _registerDbWebModel.registerDatabaseModel.Surname = registerModel.Surname;
                _registerDbWebModel.registerDatabaseModel.Email = registerModel.Email;
                _registerDbWebModel.registerDatabaseModel.Gender = registerModel.Gender;
                _registerDbWebModel.registerDatabaseModel.CountryID = registerModel.CountryID;

                _registerBusiness.addUser(_registerDbWebModel.registerDatabaseModel);

                
               registerModel.UserRegisterID = _registerBusiness.findRegisterIDByMail(registerModel.Email);
                _loginBusiness.addUser(registerModel.UserName, registerModel.Password, registerModel.UserRegisterID) ;
                _profileBusiness.addProfile(_loginBusiness.findUserIdByName(registerModel.UserName), registerModel.UserRegisterID);
   


                    TempData["true"] ="kaydınız alınmıştır'" ;

                    return Redirect("~/User/Login");
                }

                else {
                   TempData["false"] = "kullanıcı adı daha önceden alınmış ya da kullanıcı adınızla şifreniz aynı" ;
            
                }

                ViewData["country"] = _countryBusiness.getAllCountry();

                return View();
        }
       

    }
}
