using System;
using System.Collections.Generic;

namespace NeoSocial.Database.Models
{
    public partial class UserLogin
    {
        public UserLogin()
        {
            this.ArticlePosts = new List<ArticlePost>();
            this.Followers = new List<Follower>();
            this.UserProfiles = new List<UserProfile>();
        }

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int UserRegisterID { get; set; }
        public virtual ICollection<ArticlePost> ArticlePosts { get; set; }
        public virtual ICollection<Follower> Followers { get; set; }
        public virtual UserRegister UserRegister { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
