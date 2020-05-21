using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityCF.Models
{
	public class CFContext : DbContext
	{
		public CFContext()
		{
		}

		public CFContext(DbContextOptions<CFContext> options) : base(options) { }

		public virtual DbSet<Doctor> Doctor { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{

				optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s19278;Integrated Security=True;");
			}
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Doctor>(entity =>
			{
				entity.HasKey(e => e.IdDoctor).HasName("Doctor_PK");
				entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
				entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
				entity.Property(e => e.Email).HasMaxLength(100).IsRequired();


			});
			modelBuilder.Entity<Patient>(entity =>
			{
				entity.HasKey(e => e.IdPatient).HasName("Patient_PK");
				entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
				entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
				entity.Property(e => e.BirthDate).IsRequired();


			});
			modelBuilder.Entity<Medicament>(entity =>
			{
				entity.HasKey(e => e.IdMedicament).HasName("Medicament_PK");
				entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
				entity.Property(e => e.Description).HasMaxLength(100).IsRequired();
				entity.Property(e => e.Type).HasMaxLength(100).IsRequired();


			});
			modelBuilder.Entity<Prescription>(entity =>
			{
				entity.HasKey(e => e.IdPrescription).HasName("Prescription_PK");
				entity.Property(e => e.Date).IsRequired();
				entity.Property(e => e.DueDate).IsRequired();

				entity.HasOne(e => e.Patient).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdPatient).OnDelete(DeleteBehavior.ClientSetNull);
				entity.HasOne(e => e.Doctor).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdDoctor).OnDelete(DeleteBehavior.ClientSetNull);


			});
			modelBuilder.Entity<Prescription_Medicament>(entity =>
			{

				entity.Property(e => e.Dose);
				entity.Property(e => e.Details).HasMaxLength(100);
				entity.HasNoKey();

			});


		}
	}
}
