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
{
    [Authorize]
    public class MainController : Controller
    {
        IPostBusiness _postBusiness;
        IPostModel _postModel;

        public MainController() {

            _postBusiness = DependencyResolver.Current.GetService<IPostBusiness>();
            _postModel = DependencyResolver.Current.GetService<IPostModel>();
        
        }

        //
        // GET: /Main/
        [Authorize]
        public ActionResult MainPage()
        {            
          
            ViewData["postDatabase"] = _postBusiness.getAllArticlePost();

            ViewData["pathImage"] = "/Content/Image/Icons/iconFamale3.gif";

            return View();
        }
    }
}
