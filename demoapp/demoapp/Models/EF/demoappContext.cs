using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace demoapp.Models.EF
{
    public partial class demoappContext : DbContext
    {
        public demoappContext()
        {
        }

        public demoappContext(DbContextOptions<demoappContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Exerciseequipment> Exerciseequipments { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Invoicedetail> Invoicedetails { get; set; }
        public virtual DbSet<Membercard> Membercards { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Workoutpackage> Workoutpackages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=demoapp;Username=postgres;Password=2002;SSL Mode=Prefer");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_Vietnam.1258");

            modelBuilder.Entity<Exerciseequipment>(entity =>
            {
                entity.HasKey(e => e.Idm)
                    .HasName("exerciseequipment_pkey");

                entity.ToTable("exerciseequipment");

                entity.Property(e => e.Idm).HasColumnName("idm");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .HasColumnName("note");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Idhd)
                    .HasName("invoice_pkey");

                entity.ToTable("invoice");

                entity.Property(e => e.Idhd).HasColumnName("idhd");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("invoice_user_id_fkey");
            });

            modelBuilder.Entity<Invoicedetail>(entity =>
            {
                entity.HasKey(e => e.Idch)
                    .HasName("invoicedetail_pkey");

                entity.ToTable("invoicedetail");

                entity.Property(e => e.Idch).HasColumnName("idch");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.PackageId).HasColumnName("package_id");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.Invoicedetails)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("invoicedetail_invoice_id_fkey");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.Invoicedetails)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("invoicedetail_package_id_fkey");
            });

            modelBuilder.Entity<Membercard>(entity =>
            {
                entity.HasKey(e => e.Idt)
                    .HasName("membercard_pkey");

                entity.ToTable("membercard");

                entity.Property(e => e.Idt).HasColumnName("idt");

                entity.Property(e => e.PackageId).HasColumnName("package_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Timeend)
                    .HasColumnType("date")
                    .HasColumnName("timeend");

                entity.Property(e => e.Timestart)
                    .HasColumnType("date")
                    .HasColumnName("timestart");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.Membercards)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("membercard_package_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Membercards)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("membercard_user_id_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.Point).HasColumnName("point");

                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .HasColumnName("role");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Workoutpackage>(entity =>
            {
                entity.HasKey(e => e.Idg)
                    .HasName("workoutpackage_pkey");

                entity.ToTable("workoutpackage");

                entity.Property(e => e.Idg).HasColumnName("idg");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Timeend)
                    .HasColumnType("date")
                    .HasColumnName("timeend");

                entity.Property(e => e.Timestart)
                    .HasColumnType("date")
                    .HasColumnName("timestart");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
