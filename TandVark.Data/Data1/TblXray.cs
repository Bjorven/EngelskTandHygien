using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TandVark.Data.Data1
{
    public class TblXray
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FldXrayId { get; set; }
        public string FldXrayURL { get; set; }

        public int FldAppointmentFK { get; set; }
        [ForeignKey("FldAppointmentFK")]
        public TblAppointment Appointment { get; set; }
        

    }
}
