using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TandVark.Domain.DTO;
using TandVark.Data.Data1;
using Microsoft.EntityFrameworkCore;
using TandVark.Domain.Services.Interfaces;
using TandVark.Domain.Helpers;
using System.Linq;
using TandVark.Domain.Helpers.Interfaces;
using TandVark.Domain.QueryObjects;

namespace TandVark.Domain.Services
{
    public class PatientServices : IPatientServices
    {
        
        private readonly TandVerkContext _tandVardContext;
        private readonly IDateTimeProvider _dateTimeProvider;

        public PatientServices(TandVerkContext tandVerkContext, IDateTimeProvider dateTimeProvider)
        {
            _tandVardContext = tandVerkContext;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<PatientDTO> SingelPatientAsync(string requestedPatient)
        {

            var patient = await _tandVardContext.TblPatients.SingleOrDefaultAsync(x => x.FldSSnumber == requestedPatient);

            if (patient == null)
            {
                throw new NullReferenceException("Patient does not exist");
            }
            var p = new PatientDTO();
            p.FldPatientId = patient.FldPatientId;
            p.FldFirstName = patient.FldFirstName;
            p.FldLastName = patient.FldLastName;
            p.FldSSnumber = patient.FldSSnumber;
            p.FldAddress = patient.FldAddress;
            p.FldEmail = patient.FldEmail;
            p.FldPhoneNumber = patient.FldPhoneNumber;

            return p;

        }

        public async Task<List<PatientDTO>> AllPatients(int pageNumber)
        {
            List<PatientDTO> patients = new List<PatientDTO>();
            var result = _tandVardContext.TblPatients.Page(pageNumber);

            await Task.FromResult(result);

            foreach (var patient in result)
            {
                var p = new PatientDTO();
                p.FldPatientId = patient.FldPatientId;
                p.FldFirstName = patient.FldFirstName;
                p.FldLastName = patient.FldLastName;
                p.FldSSnumber = patient.FldSSnumber;
                p.FldAddress = patient.FldAddress;
                p.FldEmail = patient.FldEmail;
                p.FldPhoneNumber = patient.FldPhoneNumber;

                patients.Add(p);
            }

            return patients;

        }

        public List<TblAppointment> AllPatientsFutureAppointments(int pID)
        {
            var res = (_tandVardContext
                       .TblAppointments
                       .Where(x => x.FldPatientFK == pID)
                       .FutureAppointments(_dateTimeProvider.Today())
                       .ToList()
                       );
            return res;
        }

        public string AddPatients(PatientDTO patient)
        {
            using (var dbcxtransaction = _tandVardContext.Database.BeginTransaction())
            {
                var tblInsertItem = new TblPatient()
                {
                    FldFirstName = patient.FldFirstName,
                    FldLastName = patient.FldLastName,
                    FldAddress = patient.FldAddress,
                    FldEmail = patient.FldEmail,
                    FldSSnumber = patient.FldSSnumber,
                    FldPhoneNumber = patient.FldPhoneNumber

                };

                var result = _tandVardContext.TblPatients.Add(tblInsertItem);
                

                if (result.State.ToString() == "Added")
                {
                    _tandVardContext.SaveChanges();
                    dbcxtransaction.Commit();
                    return "New patient created";
                }
                else
                {
                    throw new Exception("Something went wrong");
                }
                
            }
        }

        public string DeletePatients(int Id)
        {
            using (var dbcxtransaction = _tandVardContext.Database.BeginTransaction())
            {
                var patient = _tandVardContext.TblPatients.Find(Id);
                if (patient == null)
                    throw new NullReferenceException("Patient does not exist");

                _tandVardContext.TblPatients.Remove(patient);
                _tandVardContext.SaveChanges();
                dbcxtransaction.Commit();
              
                    return "Patient Deleted";
             
            }
        }
        public string EditPatients(PatientDTO patientUpdated)
        {
            using (var dbcxtransaction = _tandVardContext.Database.BeginTransaction())
            {
                var patient = _tandVardContext.TblPatients.Find(patientUpdated.FldPatientId);
                if (patient == null)
                    throw new NullReferenceException("Patient does not exist");

                patient.FldFirstName = patientUpdated.FldFirstName;
                patient.FldLastName = patientUpdated.FldLastName;
                patient.FldAddress = patientUpdated.FldAddress;
                patient.FldEmail = patientUpdated.FldEmail;
                patient.FldPhoneNumber = patientUpdated.FldPhoneNumber;

                _tandVardContext.TblPatients.Update(patient);
                _tandVardContext.SaveChanges();
                dbcxtransaction.Commit();
                return "Patient Updated";
            }
        }
    }
}
