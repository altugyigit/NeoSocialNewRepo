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
        ViewModel _viewModel;
        IPostBusiness _postBusiness;
        IIconBusiness _iconBusiness;
        IProfileBusiness _profileBusiness;
        ILoginBusiness _loginBusiness;
        IRegisterBusiness _registerBusiness;
        UserProfile _userProfile;
        UserRegister _userRegister;
        static int _userId;
        int _iconId;
        static int _followMeProfileId;

        public ProfileController(
            ViewModel viewModel,
            UserProfile userProfile,
            UserRegister userRegister) {

                _postBusiness = DependencyResolver.Current.GetService<IPostBusiness>();
                _iconBusiness = DependencyResolver.Current.GetService<IIconBusiness>();
                _profileBusiness = DependencyResolver.Current.GetService<IProfileBusiness>();
                _loginBusiness = DependencyResolver.Current.GetService<ILoginBusiness>();
                _registerBusiness = DependencyResolver.Current.GetService<IRegisterBusiness>();
            _viewModel = viewModel;
            _userProfile = userProfile;
            _userRegister = userRegister;
        
        
        
        }

        //
        // GET: /Profile/
        [Authorize]
        public ActionResult Profile()
        {
             _userId = -1;
            
           

            try
            {
                _userId = (int)Session["UserId"];
                _iconId = (int)_profileBusiness.getProfileInfo(_userId).IconID;

                ViewData["pathImage"] = _iconBusiness.getIconUrl(_iconId);
                ViewData["postDatabase"] = _postBusiness.getUserArticlePost(_userId);
            }
            catch(Exception ex)
            {
            }
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult PartialShareArticle()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult PartialShareArticle(ViewModel model)
        {
          

            string currentDate = DateTime.Today.ToShortDateString();
            model.article.PostDate = currentDate;

            model.article.PostOwnerID = (int)Session["UserId"];

            model.article.PostLikeCount = 0;
            model.article.PostCommentID = 0;

            _postBusiness.insertArticlePost(model.article);

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
