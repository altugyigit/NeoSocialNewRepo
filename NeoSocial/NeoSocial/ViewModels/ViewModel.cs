using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NeoSocial.Database.Models;
using NeoSocial.Database.Repository;
using NeoSocial.Database.IUnitOfWork;
using NeoSocial.Business;
using System.Web.Mvc;

namespace NeoSocial.ViewModels
{
    public class ViewModel
    {
        public UserRegister register { get; set; }
        public UserLogin login { get; set; }
        public Country country { get; set; }
        public TurkeyCity city { get; set; }
        public ArticlePost article { get; set; }
        public UserProfile profile { get; set; }
        public Follower follower { get; set; }

        public ViewModel() {
            profile = new UserProfile();
            follower = new Follower();

            profile.UserID = 0;
            profile.UserRegisterID = 0;
            
        
        }
    }
    
}