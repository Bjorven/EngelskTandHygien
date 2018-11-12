//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace TandVark.Domain.DataLatHund
//{
//    public partial class TandVardContext : DbContext
//    {
//        public TandVardContext()
//        {
//        }

//        public TandVardContext(DbContextOptions<TandVardContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<TblDentistAppointment> TblDentistAppointment { get; set; }
//        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
//        public virtual DbSet<TblEmployeeType> TblEmployeeType { get; set; }
//        public virtual DbSet<TblPatient> TblPatient { get; set; }
//        public virtual DbSet<TblXray> TblXray { get; set; }

//        // Unable to generate entity type for table 'dbo.tbl_AppointmentToXray'. Please see the warning messages.
//        // Unable to generate entity type for table 'dbo.tbl_EmployeeToAppointment'. Please see the warning messages.
//        // Unable to generate entity type for table 'dbo.tbl_PatientToAppointment'. Please see the warning messages.

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=LAPTOP-TU1UMOIC\\SQLEXPRESS;Initial Catalog=TandVard;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<TblDentistAppointment>(entity =>
//            {
//                entity.HasKey(e => e.FldId);

//                entity.ToTable("tbl_DentistAppointment");

//                entity.Property(e => e.FldId)
//                    .HasColumnName("fld_ID")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.FldAppointmentType)
//                    .HasColumnName("fld_AppointmentType")
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.FldComment)
//                    .HasColumnName("fld_Comment")
//                    .HasMaxLength(140)
//                    .IsUnicode(false);

//                entity.Property(e => e.FldDateAndTime)
//                    .HasColumnName("fld_DateAndTime")
//                    .HasColumnType("datetime");

//                entity.Property(e => e.FldDentist).HasColumnName("fld_Dentist");

//                entity.Property(e => e.FldPatient).HasColumnName("fld_Patient");
//            });

//            modelBuilder.Entity<TblEmployee>(entity =>
//            {
//                entity.HasKey(e => e.FldId);

//                entity.ToTable("tbl_Employee");

//                entity.HasIndex(e => e.FldEmpType)
//                    .HasName("IXFK_tbl_Employee_tbl_EmployeeType");

//                entity.Property(e => e.FldId)
//                    .HasColumnName("fld_ID")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.FldAccountName)
//                    .HasColumnName("fld_AccountName")
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.FldEmpType).HasColumnName("fld_EmpType");

//                entity.Property(e => e.FldPassword)
//                    .HasColumnName("fld_Password")
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.HasOne(d => d.FldEmpTypeNavigation)
//                    .WithMany(p => p.TblEmployee)
//                    .HasForeignKey(d => d.FldEmpType)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_tbl_Employee_tbl_EmployeeType");
//            });

//            modelBuilder.Entity<TblEmployeeType>(entity =>
//            {
//                entity.HasKey(e => e.FldId);

//                entity.ToTable("tbl_EmployeeType");

//                entity.Property(e => e.FldId)
//                    .HasColumnName("fld_ID")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.FldEmployeeTypeName)
//                    .HasColumnName("fld_EmployeeTypeName")
//                    .HasMaxLength(50)
//                    .IsUnicode(false);
//            });

//            modelBuilder.Entity<TblPatient>(entity =>
//            {
//                entity.HasKey(e => e.FldId);

//                entity.ToTable("tbl_Patient");

//                entity.Property(e => e.FldId)
//                    .HasColumnName("fld_ID")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.FldAddress)
//                    .HasColumnName("fld_Address")
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.FldEmail)
//                    .HasColumnName("fld_Email")
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.FldFirstName)
//                    .IsRequired()
//                    .HasColumnName("fld_FirstName")
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.FldLastName)
//                    .IsRequired()
//                    .HasColumnName("fld_LastName")
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.FldPhoneId)
//                    .HasColumnName("fld_PhoneID")
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.FldSsnumber).HasColumnName("fld_SSNumber");
//            });

//            modelBuilder.Entity<TblXray>(entity =>
//            {
//                entity.HasKey(e => e.FldId);

//                entity.ToTable("tbl_Xray");

//                entity.Property(e => e.FldId)
//                    .HasColumnName("fld_ID")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.FldXrayLink)
//                    .HasColumnName("fld_XrayLink")
//                    .HasMaxLength(50)
//                    .IsUnicode(false);
//            });
//        }
//    }
//}
