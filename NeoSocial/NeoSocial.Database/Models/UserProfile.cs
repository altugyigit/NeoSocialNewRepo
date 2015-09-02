using System;
using System.Collections.Generic;

namespace NeoSocial.Database.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            this.Comments = new List<Comment>();
            this.Followers = new List<Follower>();
        }

        public int UserProfileID { get; set; }
        public int UserRegisterID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> IconID { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Follower> Followers { get; set; }
        public virtual Icon Icon { get; set; }
        public virtual UserLogin UserLogin { get; set; }
    }
}
