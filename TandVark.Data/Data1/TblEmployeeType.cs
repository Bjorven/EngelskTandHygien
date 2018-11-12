using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace TandVark.Data.Data1
{
    public class TblUserType
    {
        public TblUserType()
        {
            TblUsers = new HashSet<TblUser>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FldUserTypeId { get; set; }
        public string FldEmployeeTypeName { get; set; }

        public ICollection<TblUser> TblUsers { get; set; }
    }
}
