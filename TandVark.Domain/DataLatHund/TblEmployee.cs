using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TandVark.Domain.DataLatHund
{
    public partial class TblEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FldId { get; set; }
        public string FldAccountName { get; set; }
        public string FldPassword { get; set; }
        public int FldEmpType { get; set; }

        public TblEmployeeType FldEmpTypeNavigation { get; set; }
    }
}
