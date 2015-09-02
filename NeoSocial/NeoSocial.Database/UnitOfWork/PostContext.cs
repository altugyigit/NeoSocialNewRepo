using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoSocial.Database.Repository;
using System.Data.Entity;
using NeoSocial.Database.Models;
using System.Data.Entity.Validation;

namespace NeoSocial.Database.IUnitOfWork
{
    public interface IPostContext : IUnitOfWork
    {
        ArticlePostRepository ArticlePostRepository { get; }
        CommentRepository CommentRepository { get; }
        IconRepository IconRepository { get; }

    }
    public class PostContext : IPostContext
    {
        private readonly DbContext _dbContext;
        private bool _disposed;

        private ArticlePostRepository _articlePostRepository;
        private CommentRepository _commentRepository;
        private IconRepository _iconRepository;

        #region Constructur
        public PostContext(IDbContextFactory dbContextFactory)
        {
            _dbContext = dbContextFactory.GetDbContext();
        }
        #endregion

        public void Commit()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("DbEntityValidationException: ", dex.Message);
                sb.AppendLine();
                foreach (var item in dex.EntityValidationErrors)
                {
                    foreach (var error in item.ValidationErrors)
                    {
                        sb.AppendFormat("Property: {0}, ErrorMessage: {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException(sb.ToString());
            }
        }

        public ArticlePostRepository ArticlePostRepository
        {
            get
            {
                if (_articlePostRepository == null)
                {
                    _articlePostRepository = new ArticlePostRepository(_dbContext);
                }
                return _articlePostRepository;
            }
        }
        public CommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(_dbContext);
                }
                return _commentRepository;
            }
        }

        public IconRepository IconRepository
        {
            get
            {
                if (_articlePostRepository == null)
                {
                    _iconRepository = new IconRepository(_dbContext);
                }
                return _iconRepository;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
