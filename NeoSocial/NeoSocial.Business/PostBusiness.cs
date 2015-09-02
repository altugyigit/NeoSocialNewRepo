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
        ArticlePost _articlePost;

        public PostBusiness()
        {

            _postContext = new PostContext(new DbContextFactory());
            _articlePost = new ArticlePost();
        }

        public bool insertArticlePost()
        {
            try
            {


                _postContext.ArticlePostRepository.Create(_articlePost);
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