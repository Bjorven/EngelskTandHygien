using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TandVark.Domain.DataLatHund
{
    public partial class TblXray
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FldId { get; set; }
        public string FldXrayLink { get; set; }
    }
}
