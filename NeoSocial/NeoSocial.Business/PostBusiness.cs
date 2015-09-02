using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoSocial.Database.Models;
using NeoSocial.Database.Repository;
using NeoSocial.Database.IUnitOfWork;

namespace NeoSocial.Business
{


    public class PostBusiness: IPostBusiness
    {
        PostContext _postContext;


        public PostBusiness()
        {

            _postContext = new PostContext(new DbContextFactory());

        }

        public bool insertArticlePost(ArticlePost articlePost)
        {
            try
            {
                _postContext.ArticlePostRepository.Create(articlePost);
                _postContext.Commit();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }


        }

        public List<ArticlePost> getAllArticlePost()
        {
            return _postContext.ArticlePostRepository.Get().OrderByDescending(x => x.PostID).ToList();

        }

        public List<ArticlePost> getUserArticlePost(int ownerUserId)
        {
            return _postContext.ArticlePostRepository.Filter(a => a.PostOwnerID == ownerUserId).OrderByDescending(x => x.PostID).ToList();


        }
    }

}