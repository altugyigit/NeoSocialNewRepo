using NeoSocial.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NeoSocial.Business;
using NeoSocial.Database.Models;
namespace NeoSocial.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        IPostBusiness _postBusiness;
        IIconBusiness _iconBusiness;
        IProfileBusiness _profileBusiness;
        ILoginBusiness _loginBusiness;
        IRegisterBusiness _registerBusiness;
        ICountryBusiness _countryBusiness;
        ProfileModel _profileModel;

        int _iconId;
        static int _followMeProfileId;

        public ProfileController(ProfileModel profileModel)
        {
                _countryBusiness = DependencyResolver.Current.GetService<ICountryBusiness>();
                _postBusiness = DependencyResolver.Current.GetService<IPostBusiness>();
                _iconBusiness = DependencyResolver.Current.GetService<IIconBusiness>();
                _profileBusiness = DependencyResolver.Current.GetService<IProfileBusiness>();
                _loginBusiness = DependencyResolver.Current.GetService<ILoginBusiness>();
                _registerBusiness = DependencyResolver.Current.GetService<IRegisterBusiness>();

                _profileModel = profileModel;
        }

        //
        // GET: /Profile/
        [Authorize]
        public ActionResult Profile()
        {
            _profileModel.CurrentUserID = (int)Session["userId"];
            _profileModel.UserRegisterID = _loginBusiness.findRegisterIdByUserId(_profileModel.CurrentUserID);

            _profileModel.Name = _registerBusiness.findById(_profileModel.UserRegisterID).Name;
            _profileModel.Surname = _registerBusiness.findById(_profileModel.UserRegisterID).Surname;
            _profileModel.CountryName = _countryBusiness.getCountryById((int)(_registerBusiness.findById(_profileModel.UserRegisterID).CountryID));
                
            _profileModel.IconUrl = _iconBusiness.getIconUrl((int)_profileBusiness.getProfileInfo(_profileModel.CurrentUserID).IconID);

            return View(_profileModel);
        }
        [Authorize]
        [HttpGet]
        public ActionResult PartialShareArticle()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult PartialShareArticle(ArticleDbWebModel articleDbWebModel)
        {
            articleDbWebModel.articlePostDatabaseModel.PostDate = DateTime.Today.ToShortDateString(); //Current Date

            articleDbWebModel.articlePostDatabaseModel.PostOwnerID = _profileModel.CurrentUserID;

            articleDbWebModel.articlePostDatabaseModel.PostLikeCount = 0;
            articleDbWebModel.articlePostDatabaseModel.PostCommentID = 0;

            _postBusiness.insertArticlePost(articleDbWebModel.articlePostDatabaseModel);

            return Redirect("~/Profile/Profile");
            
        }

        [HttpGet]
        public ActionResult Icon() {

            return View();
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Icon(ViewModel model)
        {
              int userId = (int)Session["UserId"];
           
            
           
            
           _userProfile = _profileBusiness.getProfileInfo(userId);

            _userProfile.IconID = model.profile.IconID;
            

            _profileBusiness.updateIcon(_userProfile);
           
            return View();
        }

        public ActionResult OtherProfile(int userId)
        {
            
            ViewData["userId"] = userId;
            _userId = userId;

        

            _userProfile = _profileBusiness.getProfileInfo(userId);

            _followMeProfileId = _userProfile.UserProfileID;
            ViewData["followProfileId"] = _followMeProfileId;

            int _registerId = (int)_userProfile.UserRegisterID;
            int _iconId = (int)_userProfile.IconID;

            _userRegister = _registerBusiness.findById(_registerId);

            string _userRegisterName = _userRegister.Name;
            string _userRegisterSurname = _userRegister.Surname;

            try
            {
                ViewData["registerName"] = _userRegisterName;
                ViewData["registerSurname"] = _userRegisterSurname;
                ViewData["pathImage"] = _iconBusiness.getIconUrl(_iconId);
                ViewData["postDatabase"] = _postBusiness.getUserArticlePost(userId);
            }
            catch (Exception ex)
            {
            }

            return View();
        }

        public ActionResult FollowMe() 
        {
         
            _viewModel.follower.ProfileID = _followMeProfileId;
            _viewModel.follower.UserID = (int)Session["UserId"];



          
            _profileBusiness.insertFollower(_viewModel.follower);

            return Redirect("~/Profile/OtherProfile?userId="+_userId);
        }

        public ActionResult Unfollow() {

          
            _viewModel.follower.ProfileID = _followMeProfileId;
            _viewModel.follower.UserID = (int)Session["UserId"];

           
            _viewModel.follower.FollowerID = _profileBusiness.checkFollower(_viewModel.follower);
            _profileBusiness.deleteFollower(_viewModel.follower);

            return Redirect("~/Profile/OtherProfile?userId=" + _userId);
        
        }
    }
}
