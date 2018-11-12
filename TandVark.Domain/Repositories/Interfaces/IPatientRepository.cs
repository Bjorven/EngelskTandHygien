using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TandVark.Data.Data1;
using TandVark.Domain.DTO;

namespace TandVark.Domain.Repositories.Interfaces
{
    public interface IPatientRepository
    {


        Task<TblPatient> SingelPatientAsync(PatientDTO requestedPatient);
    }
}
