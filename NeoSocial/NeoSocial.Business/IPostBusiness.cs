using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoSocial.Database.Models;

namespace NeoSocial.Business
{
    public interface IPostBusiness
    {
        bool insertArticlePost(ArticlePost articlePost);
        List<ArticlePost> getAllArticlePost();
        List<ArticlePost> getUserArticlePost(int ownerUserId);

    }
}
