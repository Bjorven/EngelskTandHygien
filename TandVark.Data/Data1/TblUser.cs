using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TandVark.Data.Data1
{
    public class TblUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FldUserId { get; set; }
        public string FldAccountName { get; set; }
        public string FldPassword { get; set; }

        [ForeignKey("FldUserTypeId")]
        public TblUserType FldUserType { get; set; }
        
        public List<TblAppointment> Appointments { get; set; }
    }
}
