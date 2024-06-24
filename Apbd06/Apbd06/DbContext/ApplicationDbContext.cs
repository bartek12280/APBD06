using Apbd06.Models;



using Microsoft.EntityFrameworkCore;

namespace APBD_s24774.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Patient configuration
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Birthdate).HasColumnType("date");
            });

            // Doctor configuration
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Specialization).HasMaxLength(100);
            });

            // Medicament configuration
            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(200);
            });

            // Prescription configuration
            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription);
                entity.Property(e => e.Date).HasColumnType("datetime");
                entity.Property(e => e.DueDate).HasColumnType("datetime");
                entity.HasOne(e => e.Patient)
                      .WithMany(p => p.Prescriptions)
                      .HasForeignKey(e => e.PatientId);
                entity.HasOne(e => e.Doctor)
                      .WithMany( d => d.Prescriptions)
                      .HasForeignKey(e => e.DoctorId);
            });

            // PrescriptionMedicament configuration
            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.HasKey(e => new { e.IdPrescription, e.IdMedicament });
                entity.HasOne(e => e.Prescription)
                      .WithMany(p => p.PrescriptionMedicaments)
                      .HasForeignKey(e => e.IdPrescription);
                entity.HasOne(e => e.Medicament)
                      .WithMany(m => m.PrescriptionMedicaments)
                      .HasForeignKey(e => e.IdMedicament);
            });
        }
    }
}
