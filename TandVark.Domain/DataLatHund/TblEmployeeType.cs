using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TandVark.Domain.DataLatHund
{
    public partial class TblEmployeeType
    {
        public TblEmployeeType()
        {
            TblEmployee = new HashSet<TblEmployee>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FldId { get; set; }
        public string FldEmployeeTypeName { get; set; }

        public ICollection<TblEmployee> TblEmployee { get; set; }
    }
}
