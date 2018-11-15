using System;
using System.Collections.Generic;
using System.Text;

namespace TandVark.Data.Interfaces
{
    public interface IHasDate
    {
        DateTime FldAppointmentBegin { get; set; }
        DateTime FldAppointmentEnd { get; set; }

    }
}
