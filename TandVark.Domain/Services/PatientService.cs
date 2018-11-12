using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TandVark.Domain.DTO;
using TandVark.Data.Data1;
using Microsoft.EntityFrameworkCore;
using TandVark.Domain.Services.Interfaces;
using TandVark.Domain.Repositories.Interfaces;

namespace TandVark.Domain.Services
{
    public class PatientServices: IPatientServices
    {
        private readonly IPatientRepository _patientRepository;

        public PatientServices(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<PatientDTO> SingelPatientAsync(PatientDTO requestedPatient) {

            var value = await _patientRepository.SingelPatientAsync(requestedPatient);

            if (value == null)
            {
                throw new NullReferenceException("Patient does not exist");
            }
           
                var Patient = new PatientDTO {
                    FldId = value.FldPatientId,
                    FldFirstName = value.FldFirstName,
                    FldLastName = value.FldLastName,
                    FldSSnumber = value.FldSSnumber,
                    FldAddress = value.FldAddress,
                    FldEmail = value.FldEmail,
                    FldPhoneId = value.FldPhoneId

                };
                return Patient;
            
            

        }
    }
}
