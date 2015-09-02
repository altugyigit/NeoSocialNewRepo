using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NeoSocial.Database.Models;

namespace NeoSocial.ViewModels
{
    public interface IPostModel
    {
        int PostID { get; set; }
        string PostHeader { get; set; }
        string PostContent { get; set; }
        string PostDate { get; set; }
        int PostOwnerID { get; set; }
        int PostLikeCount { get; set; }
        int PostCommentID { get; set; }
        UserLogin UserLogin { get; set; }
    }
    public class PostModel : IPostModel
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