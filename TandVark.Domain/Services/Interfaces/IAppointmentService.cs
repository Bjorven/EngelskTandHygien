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
