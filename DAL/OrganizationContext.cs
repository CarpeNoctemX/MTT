using MTT.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MTT.DAL
{
    public class OrganizationContext : DbContext
    {

        public OrganizationContext () : base("OrganizationContext")
        {
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Player> Players { get; set; }
        
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Role>()
                .HasMany(c => c.Coach).WithMany(i => i.Roles)
                .Map(t => t.MapLeftKey("RoleID")
                    .MapRightKey("CoachID")
                    .ToTable("RoleCoach"));

            modelBuilder.Entity<Region>().MapToStoredProcedures();
        }
    }
}