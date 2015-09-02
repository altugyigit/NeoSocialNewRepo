using System;
using System.Collections.Generic;

namespace NeoSocial.Database.Models
{
    public partial class Icon
    {
        public Icon()
        {
            this.UserProfiles = new List<UserProfile>();
        }

        public int IconID { get; set; }
        public string IconPath { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
