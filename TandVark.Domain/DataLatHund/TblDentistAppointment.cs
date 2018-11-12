using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TandVark.Domain.DataLatHund
{
    public partial class TblDentistAppointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FldId { get; set; }
        public string FldAppointmentType { get; set; }
        public DateTime? FldDateAndTime { get; set; }
        public int? FldDentist { get; set; }
        public int? FldPatient { get; set; }
        public string FldComment { get; set; }
    }
}
