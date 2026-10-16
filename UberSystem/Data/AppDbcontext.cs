using Microsoft.EntityFrameworkCore;
using UberSystem.Model;

namespace UberSystem.Data
{
    public class AppDbcontext: DbContext
    {
        public AppDbcontext(DbContextOptions options) : base(options)
        {
        }

      

        public DbSet<User> users { get; set; }
        public DbSet<Ride> rides { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<Rating> ratings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasOne(a => a.vehicle).WithOne(a => a.Driver).HasForeignKey<Vehicle>(a => a.DriverId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Ride>().HasOne(a => a.payment).WithOne(a => a.ride).HasForeignKey<Payment>(a => a.RideId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Ride>().HasOne(a => a.rating).WithOne(a => a.ride).HasForeignKey<Rating>(a => a.RideId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasMany(a => a.Riderrides).WithOne(a => a.Rider).HasForeignKey(a => a.RiderId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasMany(a => a.DriverRide).WithOne(a => a.Driver).HasForeignKey(a => a.DriverId).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
