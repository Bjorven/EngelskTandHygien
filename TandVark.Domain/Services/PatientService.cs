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



namespace TandVark.Domain.Services
{
    public class PatientServices : IPatientServices
    {
        
        private readonly TandVerkContext _tandVardContext;

        public PatientServices(TandVerkContext tandVerkContext)
        {
            _tandVardContext = tandVerkContext;
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

        public List<TblAppointment> AllPatientsAppointments(int pID)
        {
            var res = (_tandVardContext
                       .TblAppointments
                       .Where(x => x.FldPatientFK == pID)
                       .Future()
                       .ToList()
                       );
            return res;
        }
    }
}
