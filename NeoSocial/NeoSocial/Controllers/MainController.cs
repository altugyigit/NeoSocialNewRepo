using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NeoSocial.Business;
using System.IO;
using System.Web.Security;
using NeoSocial.ViewModels;

namespace NeoSocial.Controllers
    [Authorize]
    public class MainController : Controller
    {
        IIconBusiness _iconBusiness;
        IRegisterBusiness _registerBusiness;
        IProfileBusiness _profileBusiness;
        IPostBusiness _postBusiness;
        PostModel _postModel;
        List<PostModel> _postModelList;

        public MainController(PostModel postModel)
        {
            _postBusiness = DependencyResolver.Current.GetService<IPostBusiness>();
        
            _iconBusiness = DependencyResolver.Current.GetService<IIconBusiness>();
            _registerBusiness = DependencyResolver.Current.GetService<IRegisterBusiness>();
            _profileBusiness = DependencyResolver.Current.GetService<IProfileBusiness>();         
            _postModel = postModel;
            _postModelList = new List<PostModel>();
        }

        //
        // GET: /Main/
        [Authorize]
        public ActionResult MainPage()
        {
            //GEÇERLİ OTURUMU AÇMIŞ KİŞİNİN ID' SİNİ ALIP POST SAHİBİ KİŞİ İLE KONTROL ETTİRME İŞLEMİ.
            TempData["currentUserId"] = (int)Session["userId"];

            foreach (var articleItem in _postBusiness.getAllArticlePost())
            {
                _postModel = new PostModel();

                _postModel.UserID = (int)_profileBusiness.getProfileInfo(articleItem.PostOwnerID).UserID;
                _postModel.UserRegisterID = (int)_profileBusiness.getProfileInfo(articleItem.PostOwnerID).UserRegisterID;
                _postModel.IconID = (int)_profileBusiness.getProfileInfo(articleItem.PostOwnerID).IconID;

                _postModel.Name = _registerBusiness.findById(_postModel.UserRegisterID).Name;
                _postModel.Surname = _registerBusiness.findById(_postModel.UserRegisterID).Surname;

                _postModel.IconUrl = _iconBusiness.getIconUrl(_postModel.IconID);

                _postModel.PostHeader = articleItem.PostHeader;
                _postModel.PostContent = articleItem.PostContent;
                _postModel.PostDate = articleItem.PostDate;
                _postModel.PostOwnerID = articleItem.PostOwnerID;

                _postModelList.Add(_postModel);
            }

            return View(_postModelList);
        }


    }
}
