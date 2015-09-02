using System;
using System.Collections.Generic;

namespace NeoSocial.Database.Models
{
    public partial class Badge
    {
        public int BadgeID { get; set; }
        public string BadgeName { get; set; }
        public string BadgeIconPath { get; set; }
    }
}
