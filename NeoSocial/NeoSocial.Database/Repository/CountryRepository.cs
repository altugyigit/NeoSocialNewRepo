using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using NeoSocial.Database.Models;

namespace NeoSocial.Database.Repository
{
    public interface ICountry : IRepository<Country>
    { }

    public class CountryRepository : Repository<Country>, ICountry
    {
        public CountryRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }
}
