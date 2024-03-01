using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SharedModels.Models;

public partial class PatientsContext : DbContext
{
    public PatientsContext()
    {
    }

    public PatientsContext(DbContextOptions<PatientsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AllergiesDetail> AllergiesDetails { get; set; }

    public virtual DbSet<Allergy> Allergies { get; set; }

    public virtual DbSet<DiseaseInformation> DiseaseInformations { get; set; }

    public virtual DbSet<Ncd> Ncds { get; set; }

    public virtual DbSet<NcdDetail> NcdDetails { get; set; }

    public virtual DbSet<PatientsInformation> PatientsInformations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=ZAWAD-PC\\SQLEXPRESS;Database=PatientPortal;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AllergiesDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Allergie__3214EC27B0BE3F32");

            entity.ToTable("Allergies_Details");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AllergiesId).HasColumnName("AllergiesID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");

            entity.HasOne(d => d.Allergies).WithMany(p => p.AllergiesDetails)
                .HasForeignKey(d => d.AllergiesId)
                .HasConstraintName("FK__Allergies__Aller__5629CD9C");

            entity.HasOne(d => d.Patient).WithMany(p => p.AllergiesDetails)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Allergies__Patie__5535A963");
        });

        modelBuilder.Entity<Allergy>(entity =>
        {
            entity.HasKey(e => e.AllergiesId).HasName("PK__Allergie__704D9A94E8316D55");

            entity.Property(e => e.AllergiesId).HasColumnName("AllergiesID");
            entity.Property(e => e.AllergiesName).HasMaxLength(50);
        });

        modelBuilder.Entity<DiseaseInformation>(entity =>
        {
            entity.HasKey(e => e.DiseaseId).HasName("PK__DiseaseI__69B533A925807395");

            entity.ToTable("DiseaseInformation");

            entity.Property(e => e.DiseaseId).HasColumnName("DiseaseID");
            entity.Property(e => e.DiseaseName).HasMaxLength(50);
        });

        modelBuilder.Entity<Ncd>(entity =>
        {
            entity.HasKey(e => e.Ncdid).HasName("PK__NCD__B85D6690BC0669AE");

            entity.ToTable("NCD");

            entity.Property(e => e.Ncdid).HasColumnName("NCDID");
            entity.Property(e => e.Ncdname)
                .HasMaxLength(50)
                .HasColumnName("NCDName");
        });

        modelBuilder.Entity<NcdDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NCD_Deta__3214EC27D5DABF5C");

            entity.ToTable("NCD_Details");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Ncdid).HasColumnName("NCDID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");

            entity.HasOne(d => d.Ncd).WithMany(p => p.NcdDetails)
                .HasForeignKey(d => d.Ncdid)
                .HasConstraintName("FK__NCD_Detai__NCDID__52593CB8");

            entity.HasOne(d => d.Patient).WithMany(p => p.NcdDetails)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__NCD_Detai__Patie__5165187F");
        });

        modelBuilder.Entity<PatientsInformation>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC346B381FBA9");

            entity.ToTable("PatientsInformation");

            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
