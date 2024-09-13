using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Gift_of_the_Givers_Foundation.Models;

namespace Gift_of_the_Givers_Foundation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Gift_of_the_Givers_Foundation.Models.Volunteer> Volunteer { get; set; }
        public DbSet<Gift_of_the_Givers_Foundation.Models.DisasterIncident> DisasterIncident { get; set; }
        public DbSet<Gift_of_the_Givers_Foundation.Models.Donation> Donation { get; set; }

        public DbSet<Gift_of_the_Givers_Foundation.Models.TaskAssignment> TaskAssignment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Volunteer>().ToTable("Volunteer");
            modelBuilder.Entity<DisasterIncident>().ToTable("DisasterIncident");
            modelBuilder.Entity<Donation>().ToTable("Donation");
            modelBuilder.Entity<TaskAssignment>().ToTable("TaskAssignment");
            base.OnModelCreating(modelBuilder);
        }
       
    }
}
