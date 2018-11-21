using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TandVark.Domain.DTO;
using TandVark.Data.Data1;
using Microsoft.EntityFrameworkCore;
using TandVark.Domain.Services.Interfaces;
using TandVark.Domain.Repositories.Interfaces;
using TandVark.Domain.Helpers;
using System.Linq;
using TandVark.Domain.Helpers.Interfaces;

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

        public async Task<TblPatient> SingelPatientAsync(string requestedPatient)
        {

            var value = await _tandVardContext.TblPatients.SingleOrDefaultAsync(x => x.FldSSnumber == requestedPatient);

            if (value == null)
            {
                throw new NullReferenceException("Patient does not exist");
            }

            return value;

        }

        public async Task<IEnumerable<TblPatient>> AllPatients()
        {

            var result = _tandVardContext.TblPatients.Page(1);
            return await Task.FromResult(result);

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
                _tandVardContext.SaveChanges();
                dbcxtransaction.Commit();

                if (result.State.ToString() == "Added")
                {
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
    }
}
