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
            try
            {
                _profileModel.CurrentUserID = (int)Session["userId"];
                _profileModel.UserRegisterID = _loginBusiness.findRegisterIdByUserId(_profileModel.CurrentUserID);

                _profileModel.Name = _registerBusiness.findById(_profileModel.UserRegisterID).Name;
                _profileModel.Surname = _registerBusiness.findById(_profileModel.UserRegisterID).Surname;
                _profileModel.CountryName = _countryBusiness.getCountryNameById((int)(_registerBusiness.findById(_profileModel.UserRegisterID).CountryID));

                _profileModel.IconUrl = _iconBusiness.getIconUrl((int)_profileBusiness.getProfileInfo(_profileModel.CurrentUserID).IconID);

                _profileModel.SharingsCount = _postBusiness.getUserArticlePost(_profileModel.CurrentUserID).Count;
                _profileModel.FollowersCount = _profileBusiness.getAllFollowerByProfileId(_profileBusiness.getProfileId(_profileModel.CurrentUserID)).Count;

                return View(_profileModel);
            }
            catch(Exception ex)
            {
                return View(new ProfileModel());
            }
            
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
        public ActionResult Icon(String denemetest)
        {/*
              int userId = (int)Session["UserId"];
           
            
           
            
           _userProfile = _profileBusiness.getProfileInfo(userId);

            _userProfile.IconID = model.profile.IconID;
            

            _profileBusiness.updateIcon(_userProfile);
           */
            return View();
        }

        public ActionResult OtherProfile(int userId)
        {          
            try
            {
                _profileModel.CurrentUserID = userId;
                _profileModel.UserRegisterID = _loginBusiness.findRegisterIdByUserId(_profileModel.CurrentUserID);

                _profileModel.Name = _registerBusiness.findById(_profileModel.UserRegisterID).Name;
                _profileModel.Surname = _registerBusiness.findById(_profileModel.UserRegisterID).Surname;
                _profileModel.CountryName = _countryBusiness.getCountryNameById((int)(_registerBusiness.findById(_profileModel.UserRegisterID).CountryID));

                _profileModel.IconUrl = _iconBusiness.getIconUrl((int)_profileBusiness.getProfileInfo(_profileModel.CurrentUserID).IconID);

                _profileModel.SharingsCount = _postBusiness.getUserArticlePost(_profileModel.CurrentUserID).Count;
                _profileModel.FollowersCount = _profileBusiness.getAllFollowerByProfileId(_profileBusiness.getProfileId(_profileModel.CurrentUserID)).Count;

                return View(_profileModel);
            }
            catch (Exception ex)
            {
                return View(new ProfileModel());
            }
           
        }

        public ActionResult FollowMe() 
        {

            /* _viewModel.follower.ProfileID = _followMeProfileId;
             _viewModel.follower.UserID = (int)Session["UserId"];



          
             _profileBusiness.insertFollower(_viewModel.follower);
             return Redirect("~/Profile/OtherProfile?userId="+_userId);
             */
            return Redirect("~/Profile/OtherProfile");
        }

        public ActionResult Unfollow() {
            /*
          
            _viewModel.follower.ProfileID = _followMeProfileId;
            _viewModel.follower.UserID = (int)Session["UserId"];

           
            _viewModel.follower.FollowerID = _profileBusiness.checkFollower(_viewModel.follower);
            _profileBusiness.deleteFollower(_viewModel.follower);

            return Redirect("~/Profile/OtherProfile?userId=" + _userId);*/

            return Redirect("~/Profile/OtherProfile");
        }
    }
}
