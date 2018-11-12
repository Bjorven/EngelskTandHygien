using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TandVark.Domain.DataLatHund
{
    public partial class TblPatient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FldId { get; set; }
        public string FldFirstName { get; set; }
        public string FldLastName { get; set; }
        public int? FldSsnumber { get; set; }
        public string FldAddress { get; set; }
        public string FldPhoneId { get; set; }
        public string FldEmail { get; set; }
    }
}
