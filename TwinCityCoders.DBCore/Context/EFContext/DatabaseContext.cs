using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TwinCityCoders.Models.Entities.TestTableEntity;
using TwinCityCoders.Models.Identity;

namespace TwinCityCoders.DBCore.Context.EFContext
{
    public partial class DatabaseContext : IdentityDbContext<ApplicationUser>, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }



        #region Table Models


        public DbSet<TestTable> TestTables { get; set; }


        #endregion Table Models






        #region Sp Models
        //public DbSet<DriverListDto> driverList { get; set; }
        //public DbSet<PetDto> petList { get; set; }

        #endregion Sp Models

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
