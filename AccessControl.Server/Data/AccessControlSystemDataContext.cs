using AccessControl.Server.Data.Mappings;
using AccessControl.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Server.Data {
    public class AccessControlSystemDataContext : DbContext{

        public AccessControlSystemDataContext(DbContextOptions<AccessControlSystemDataContext> options) : base(options) {

        }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new DeviceMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
