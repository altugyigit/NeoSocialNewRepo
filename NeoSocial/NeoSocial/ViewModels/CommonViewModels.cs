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
    public class PostModel
    {
        public int PostID { get; set; }
        public string PostHeader { get; set; }
        public string PostContent { get; set; }
        public string PostDate { get; set; }
        public int PostOwnerID { get; set; }
        public int PostLikeCount { get; set; }
        public int PostCommentID { get; set; }
        public int UserProfileID { get; set; }
        public int UserRegisterID { get; set; }
        public int CurrentUserID { get; set; }
        public int UserID { get; set; }
        public int IconID { get; set; }
        public string IconUrl { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class ProfileModel
    {
        public int CurrentUserID { get; set; }
        public int UserRegisterID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public short Gender { get; set; }
        public string CountryName { get; set; }
        public string IconUrl { get; set; }
    }

    public class MailV
    {
        public Mail mail { get; set; }
    }


}