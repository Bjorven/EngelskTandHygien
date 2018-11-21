using System;

namespace TandVark.Data.Interfaces
{
    public interface IHasAppointment
    {
        DateTime FldAppointmentBegin { get; set; }
        DateTime FldAppointmentEnd { get; set; }

    }
}
