using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

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

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeService> EmployeeServices { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Service> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=FOFOPC\\FOFOSQLSERVER;Initial Catalog=SupportApplication;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Creation");

                entity.Property(e => e.EmployeeEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Email");

                entity.Property(e => e.EmployeeFirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Employee_FirstName");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Name");

                entity.Property(e => e.EmployeeOccupation)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Occupation");

                entity.Property(e => e.EmployeePassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Password");

                entity.Property(e => e.EmployeeSecondName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Employee_SecondName");

                entity.Property(e => e.EmployeeSupervisor).HasColumnName("Employee_Supervisor");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modification_Date");

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
                    .HasName("PK__Employee__A3C096B885537741");

                entity.ToTable("Employee_Service");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.ServiceId).HasColumnName("Service_ID");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Creation");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modification_Date");

                entity.Property(e => e.ModificationUser).HasColumnName("Modification_user");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserCreation).HasColumnName("User_Creation");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeServices)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Assigned");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.EmployeeServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Service_Supporter");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__Issue__30FA9DB13ACF996E");

                entity.ToTable("Issue");

                entity.Property(e => e.ReportId).HasColumnName("Report_ID");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Creation");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modification_Date");

                entity.Property(e => e.ModificationUser).HasColumnName("Modification_user");

                entity.Property(e => e.ReportClassification)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Report_Classification");

                entity.Property(e => e.ReportDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Report_DateTime");

                entity.Property(e => e.ReportResolution)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Report_Resolution");

                entity.Property(e => e.ReportStatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Report_Status");

                entity.Property(e => e.ServiceId).HasColumnName("Service_ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserCreation).HasColumnName("User_Creation");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_Issue");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Service");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.IssueId })
                    .HasName("PK__Note__E338C63C8F051ED5");

                entity.ToTable("Note");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.IssueId).HasColumnName("Issue_ID");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Creation");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modification_Date");

                entity.Property(e => e.ModificationUser).HasColumnName("Modification_user");

                entity.Property(e => e.NoteDescription)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("Note_Description");

                entity.Property(e => e.NoteTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Note_time");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserCreation).HasColumnName("User_Creation");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Comment");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Issue_Assigned");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.ServiceId).HasColumnName("Service_ID");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Creation");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modification_Date");

                entity.Property(e => e.ModificationUser).HasColumnName("Modification_user");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Service_Name");

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
