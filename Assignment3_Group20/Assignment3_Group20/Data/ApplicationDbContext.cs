using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Assignment3_Group20.Model;

namespace Assignment3_Group20.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Assignment3_Group20.Model.Reservation> Reservation { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Reservation>().HasData(new Reservation
                { Adults = 2, Children = 2, ID = 1, isCheckedIn = DateTime.Now, RoomNumber = 1 });
            base.OnModelCreating(builder);
        }

        public DbSet<Assignment3_Group20.Model.FutureReservation> FutureReservation { get; set; }
    }
}