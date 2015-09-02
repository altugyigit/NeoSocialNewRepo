using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using NeoSocial.Database.Models;

namespace NeoSocial.Database.Repository
{
    public interface IUserRegister : IRepository<UserRegister>
    { }

    public class UserRegisterRepository : Repository<UserRegister>, IUserRegister
    {
        public UserRegisterRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }
}
