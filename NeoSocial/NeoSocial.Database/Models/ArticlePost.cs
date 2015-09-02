using System;
using System.Collections.Generic;

namespace NeoSocial.Database.Models
{
    public partial class ArticlePost
    {
        public int PostID { get; set; }
        public string PostHeader { get; set; }
        public string PostContent { get; set; }
        public string PostDate { get; set; }
        public int PostOwnerID { get; set; }
        public int PostLikeCount { get; set; }
        public int PostCommentID { get; set; }
        public virtual UserLogin UserLogin { get; set; }
    }
}
