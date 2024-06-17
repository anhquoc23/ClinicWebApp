using ClinicWebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicWebAPI.Configs
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> dbContext): base(dbContext) { }

        // DataSet
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Entity Medicine
            builder.Entity<Medicine>()
                .HasIndex(e => e.Name).IsUnique();

            builder.Entity<Medicine>()
                .Property(e => e.CreatedDate)
                .HasDefaultValue(DateTime.Now);

            builder.Entity<Medicine>()
                .Property(e => e.UpdatedDate)
                .HasDefaultValue(DateTime.Now)
                .ValueGeneratedOnUpdate()
                .HasDefaultValue(DateTime.Now);

            // Entity Category
            builder.Entity<Category>()
                .HasIndex(e => e.Name).IsUnique();

            // Entity Room
            builder.Entity<Room>()
                .HasIndex(e => e.Name).IsUnique();

            // Entity Specialization
            builder.Entity<Specialization>()
                .HasIndex(e => e.Name).IsUnique();

            // Entity Shift
            builder.Entity<Shift>()
                .HasIndex(e => e.Name).IsUnique();

            // Entity Medical Record
            builder.Entity<MedicalRecord>()
                .Property(e => e.CreatedDate)
                .HasDefaultValue(DateTime.Now);

            // Entity IdentityUserLogin
            builder.Entity<IdentityUserLogin<string>>().HasKey(e => new { e.LoginProvider, e.ProviderKey });
        }
    }
}
