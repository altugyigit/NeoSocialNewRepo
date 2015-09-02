using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using NeoSocial.Database.Models.Mapping;

namespace NeoSocial.Database.Models
{
    public partial class DB_9D589F_neosocialContext : DbContext
    {
        static DB_9D589F_neosocialContext()
        {
            System.Data.Entity.Database.SetInitializer<DB_9D589F_neosocialContext>(null);
        }

        public DB_9D589F_neosocialContext()
            : base("Name=DB_9D589F_neosocialContext")
        {
        }

        public DbSet<ArticlePost> ArticlePosts { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Icon> Icons { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<TurkeyCity> TurkeyCities { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserRegister> UserRegisters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ArticlePostMap());
            modelBuilder.Configurations.Add(new BadgeMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new FollowerMap());
            modelBuilder.Configurations.Add(new IconMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TurkeyCityMap());
            modelBuilder.Configurations.Add(new UserLoginMap());
            modelBuilder.Configurations.Add(new UserProfileMap());
            modelBuilder.Configurations.Add(new UserRegisterMap());
        }
    }
}
