using Microsoft.EntityFrameworkCore;
using ClyvoDayApi.Models;

namespace ClyvoDayApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Veterinarian> Veterinarians { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<MonitoringPet> Monitorings { get; set; }
        public DbSet<CareEvent> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().HasOne<Tutor>().WithMany(t => t.Pets).HasForeignKey(p => p.TutorId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CareEvent>().HasOne(e => e.Pet).WithMany().HasForeignKey(e => e.PetId);
            modelBuilder.Entity<Veterinarian>().HasOne(v => v.Clinic).WithMany(c => c.Veterinarians).HasForeignKey(v => v.ClinicId);
            modelBuilder.Entity<Pet>().Property(p => p.Weight).HasPrecision(10, 2);

        }
    }
}

////modelBuilder.Entity<Veterinarian>().HasOne<Clinic>().WithMany(c => c.Veterinarians).HasForeignKey(v => v.ClinicId);