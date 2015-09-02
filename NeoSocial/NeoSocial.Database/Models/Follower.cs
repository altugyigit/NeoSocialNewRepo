using System;
using System.Collections.Generic;

namespace NeoSocial.Database.Models
{
    public partial class Follower
    {
        public Nullable<int> ProfileID { get; set; }
        public Nullable<int> UserID { get; set; }
        public int FollowerID { get; set; }
        public virtual UserLogin UserLogin { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
