using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TandVark.Domain.DTO;

namespace TandVark.Domain.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<string> CreateNewAppointment(AppointmentDTO appointment);
        Task<string> DeleteAppointment(int AppointmentID);
    }
}
