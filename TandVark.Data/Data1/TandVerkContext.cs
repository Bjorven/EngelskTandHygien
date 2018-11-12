using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TandVark.Data.Data1
{
    public class TandVerkContext : DbContext
    {

        public TandVerkContext()
        {
        }

        public TandVerkContext(DbContextOptions<TandVerkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<TblUserType> TblUserTypes { get; set; }
        public virtual DbSet<TblPatient> TblPatients { get; set; }
        public virtual DbSet<TblAppointment> TblAppointments { get; set; }
        public virtual DbSet<TblXray> TblXrays { get; set; }




    }

}
