using System;
using System.Collections.Generic;

namespace TandVark.Domain.DTO
{
    public class AppointmentDTO
    {
        public DateTime FldAppointmentBegin { get; set; }
        public DateTime FldAppointmentEnd { get; set; }

        public int FldDenistIdFK { get; set; }
        public int FldPatientFK { get; set; }

        public virtual List<XRayDTO> FldXrays { get; set; }
    }
}
