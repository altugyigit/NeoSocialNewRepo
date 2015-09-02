using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoSocial.Database.Models;
using NeoSocial.Database.Repository;
using System.Data.Entity;
using System.Data.Entity.Validation;


namespace NeoSocial.Database.IUnitOfWork
{
    public interface IUserContext : IUnitOfWork
    {

        UserLoginRepository UserLoginRepository { get; }
        UserProfileRepository UserProfileRepository { get; }
        UserRegisterRepository UserRegisterRepository { get; }
        FollowerRepository FollowerRepository { get; }
    }

    public class UserContext : IUserContext
    {
        private readonly DbContext _dbContext;
        private bool _disposed;

        private UserLoginRepository _userLoginRepository;
        private UserProfileRepository _userProfileRepository;
        private UserRegisterRepository _userRegisterRepository;
        private FollowerRepository _followerRepository;


        public UserContext(IDbContextFactory dbContextFactory)
        {
            _dbContext = dbContextFactory.GetDbContext();
        }

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

        public UserLoginRepository UserLoginRepository
        {
            get
            {
                if (_userLoginRepository == null)
                {
                    _userLoginRepository = new UserLoginRepository(_dbContext);
                }
                return _userLoginRepository;
            }
        }

        public UserProfileRepository UserProfileRepository
        {
            get
            {
                if (_userProfileRepository == null)
                {
                    _userProfileRepository = new UserProfileRepository(_dbContext);
                }
                return _userProfileRepository;
            }
        }


        public UserRegisterRepository UserRegisterRepository
        {
            get
            {
                if (_userRegisterRepository == null)
                {
                    _userRegisterRepository = new UserRegisterRepository(_dbContext);
                }
                return _userRegisterRepository;
            }
        }

        public FollowerRepository FollowerRepository
        {
            get
            {
                if (_followerRepository == null)
                {
                    _followerRepository = new FollowerRepository(_dbContext);
                }
                return _followerRepository;
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
