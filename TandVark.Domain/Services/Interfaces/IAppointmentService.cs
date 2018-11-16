using System;
using System.Collections.Generic;
using System.Text;
using TandVark.Domain.DTO;

namespace TandVark.Domain.Services.Interfaces
{
    public interface IAppointmentService
    {
        string CreateNewAppointment(AppointmentDTO appointment);
        string DeleteAppointment(int AppointmentID);
    }
}
