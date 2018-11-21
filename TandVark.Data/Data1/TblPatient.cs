using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TandVark.Data.Data1
{
    public class TblPatient
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FldPatientId { get; set; }

        public string FldFirstName { get; set; }
        public string FldLastName { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 12)]
        public string FldSSnumber { get; set; }

        public string FldAddress { get; set; }
        public string FldPhoneNumber { get; set; }
        public string FldEmail { get; set; }
        

        
        public List<TblAppointment> Appointments { get; set; }

    }
}
