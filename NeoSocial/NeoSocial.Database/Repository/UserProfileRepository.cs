using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using NeoSocial.Database.Models;

namespace NeoSocial.Database.Repository
{
    public interface IUserProfile : IRepository<UserProfile>
    { }

    public class UserProfileRepository : Repository<UserProfile>, IUserProfile
    {
        public UserProfileRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }
}
