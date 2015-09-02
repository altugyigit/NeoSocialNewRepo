using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using NeoSocial.Database.Models;

namespace NeoSocial.Database.Repository
{
    public interface ITurkeyCity : IRepository<TurkeyCity>
    { }

    public class TurkeyCityRepository : Repository<TurkeyCity>, ITurkeyCity
    {
        public TurkeyCityRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }
}
