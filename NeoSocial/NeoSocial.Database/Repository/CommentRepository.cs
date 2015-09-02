using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using NeoSocial.Database.Models;

namespace NeoSocial.Database.Repository
{
    public interface IComment : IRepository<Comment>
    { }

    public class CommentRepository : Repository<Comment>, IComment
    {
        public CommentRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }
}
