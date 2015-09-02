using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NeoSocial.Database.Models;
using NeoSocial.Database.Repository;
using NeoSocial.Database.IUnitOfWork;
using NeoSocial.Business;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public int SharingsCount { get; set; }
        public int CommentsCount { get; set; }
        public int FollowersCount { get; set; }        
    }

    public class MailModel
    {
        [EmailAddress]
        public string FromEmail { get; set; }
        [Required, EmailAddress]
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }

    public class LoginModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int UserRegisterID { get; set; }
    }


}