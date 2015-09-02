using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoSocial.Database.Models;

namespace NeoSocial.Database.Repository
{
    /// <summary>
    /// Creates instance of specific DbContext
    /// </summary>
    public interface IDbContextFactory
    {
        DbContext GetDbContext();
        DbContext CreateNewContext();
    }

    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext _context;

        public DbContextFactory()
        {
            _context = new NeoSocial.Database.Models.DB_9D589F_neosocialContext();
        }

        public DbContext GetDbContext()
        {
            return _context;
        }

        public DbContext CreateNewContext()
        {
            return new NeoSocial.Database.Models.DB_9D589F_neosocialContext();
        }
    }
}
