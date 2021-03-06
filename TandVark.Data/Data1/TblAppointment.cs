﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TandVark.Data.Interfaces;

namespace TandVark.Data.Data1
{
    public class TblAppointment:IHasAppointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FldAppointmentId { get; set; }

        public DateTime FldAppointmentBegin { get; set; }
        public DateTime FldAppointmentEnd { get; set; }

        public int FldDenistIdFK { get; set; }
        [ForeignKey("FldDenistIdFK")]
        public virtual TblUser FldAppointedDentist { get; set; }

        public int FldPatientFK { get; set; }
        [ForeignKey("FldPatientFK")]
        public virtual TblPatient FldAppointedPatient { get; set; }

        public virtual List<TblXray> Xrays { get; set; }

    }
}
