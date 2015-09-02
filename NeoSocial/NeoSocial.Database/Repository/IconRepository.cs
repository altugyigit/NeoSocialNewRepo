using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using NeoSocial.Database.Models;

namespace NeoSocial.Database.Repository
{
    public interface IIcon : IRepository<Icon>
    { }

    public class IconRepository : Repository<Icon>, IIcon
    {
        public IconRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }
}
