using System;
using System.Collections.Generic;

namespace NeoSocial.Database.Models
{
    public partial class Comment
    {
        public int CommentID { get; set; }
        public string CommentText { get; set; }
        public int CommentOwnerID { get; set; }
        public string CommentDate { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
