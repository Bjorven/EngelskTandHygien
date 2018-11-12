using System.Threading.Tasks;
using TandVark.Domain.DTO;
using TandVark.Domain.Models;

namespace TandVark.Domain.Services.Interfaces
{
    public interface IPatientServices
    {
        Task<PatientDTO> SingelPatientAsync(PatientDTO requestedPatient);
    }
}