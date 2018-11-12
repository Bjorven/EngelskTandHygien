using System;
using System.Collections.Generic;
using System.Text;

namespace TandVark.Domain.DTO
{
    public class PatientDTO
    {
        public int FldId { get; set; }
        public string FldFirstName { get; set; }
        public string FldLastName { get; set; }
        public string FldSSnumber { get; set; }
        public string FldAddress { get; set; }
        public string FldPhoneId { get; set; }
        public string FldEmail { get; set; }

    }
}
