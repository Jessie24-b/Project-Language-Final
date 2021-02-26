using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebAPISupport.Models
{
    public partial class SupportApplicationContext : DbContext
    {
        public SupportApplicationContext()
        {
        }

        public SupportApplicationContext(DbContextOptions<SupportApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeService> EmployeeService { get; set; }
        public virtual DbSet<Issue> Issue { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<Service> Service { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=FOFOPC\\FOFOSQLSERVER;Database=SupportApplication;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.DateCreation)
                    .HasColumnName("Date_Creation")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeEmail)
                    .IsRequired()
                    .HasColumnName("Employee_Email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasColumnName("Employee_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeOccupation)
                    .IsRequired()
                    .HasColumnName("Employee_Occupation")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeePassword)
                    .IsRequired()
                    .HasColumnName("Employee_Password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeSupervisor).HasColumnName("Employee_Supervisor");

                entity.Property(e => e.ModificationDate)
                    .HasColumnName("Modification_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModificationUser).HasColumnName("Modification_user");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserCreation).HasColumnName("User_Creation");

                entity.HasOne(d => d.EmployeeSupervisorNavigation)
                    .WithMany(p => p.InverseEmployeeSupervisorNavigation)
                    .HasForeignKey(d => d.EmployeeSupervisor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Employ__36B12243");
            });

            modelBuilder.Entity<EmployeeService>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.ServiceId })
                    .HasName("PK__Employee__A3C096B870161654");

                entity.ToTable("Employee_Service");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.ServiceId).HasColumnName("Service_ID");

                entity.Property(e => e.DateCreation)
                    .HasColumnName("Date_Creation")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModificationDate)
                    .HasColumnName("Modification_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModificationUser).HasColumnName("Modification_user");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserCreation).HasColumnName("User_Creation");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeService)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Assigned");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.EmployeeService)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Service_Supporter");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__Issue__30FA9DB1134CBE95");

                entity.Property(e => e.ReportId)
                    .HasColumnName("Report_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateCreation)
                    .HasColumnName("Date_Creation")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.ModificationDate)
                    .HasColumnName("Modification_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModificationUser).HasColumnName("Modification_user");

                entity.Property(e => e.ReportClassification)
                    .IsRequired()
                    .HasColumnName("Report_Classification")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ReportDateTime)
                    .HasColumnName("Report_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReportResolution)
                    .HasColumnName("Report_Resolution")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReportStatus)
                    .IsRequired()
                    .HasColumnName("Report_Status")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceId).HasColumnName("Service_ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserCreation).HasColumnName("User_Creation");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Issue)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_Issue");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Issue)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Service");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.IssueId })
                    .HasName("PK__Note__E338C63C70793BBD");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.IssueId).HasColumnName("Issue_ID");

                entity.Property(e => e.DateCreation)
                    .HasColumnName("Date_Creation")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModificationDate)
                    .HasColumnName("Modification_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModificationUser).HasColumnName("Modification_user");

                entity.Property(e => e.NoteDescription)
                    .HasColumnName("Note_Description")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.NoteTime)
                    .HasColumnName("Note_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserCreation).HasColumnName("User_Creation");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Note)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Comment");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.Note)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Issue_Assigned");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.ServiceId).HasColumnName("Service_ID");

                entity.Property(e => e.DateCreation)
                    .HasColumnName("Date_Creation")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModificationDate)
                    .HasColumnName("Modification_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModificationUser).HasColumnName("Modification_user");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasColumnName("Service_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserCreation).HasColumnName("User_Creation");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
