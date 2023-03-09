using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QamaCoreShared.Helpers.DataContext;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace ModulerCrm.Helpers
{
    public class DataContext : DataContextBase
    {
        //public virtual DbSet<Users> Users { get; set; }

        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var conenctionString = Configuration.GetConnectionString("DefaultConnection");
            // connect to sqlite database
            options.UseSqlServer(conenctionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
