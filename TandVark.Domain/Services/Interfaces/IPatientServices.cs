using System.Collections.Generic;
using System.Threading.Tasks;
using TandVark.Data.Data1;
using TandVark.Domain.DTO;

namespace TandVark.Domain.Services.Interfaces
{
    public interface IPatientServices
    {
        Task<PatientDTO> SingelPatientAsync(string requestedPatient);
        Task<List<PatientDTO>> AllPatients(int pageNumber);
        List<TblAppointment> AllPatientsFutureAppointments(int requestedPatient);
        string AddPatients(PatientDTO patient);
        string DeletePatients(int Id);
        string EditPatients(PatientDTO patientUpdated);
    }
}