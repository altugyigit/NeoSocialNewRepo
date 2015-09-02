using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using NeoSocial.Database.Models;

namespace NeoSocial.Database.Repository
{
    public interface IUserLogin : IRepository<UserLogin>
    { }

    public class UserLoginRepository : Repository<UserLogin>, IUserLogin
    {
        public UserLoginRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }
}
