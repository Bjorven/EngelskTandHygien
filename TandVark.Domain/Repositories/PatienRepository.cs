using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TandVark.Data.Data1;
using TandVark.Domain.DTO;
using TandVark.Domain.Repositories.Interfaces;

namespace TandVark.Domain.Repositories
{
    public class PatientRepository: IPatientRepository
    {
        private readonly TandVerkContext _tandVardContext;

        public PatientRepository(TandVerkContext tandVardContext)
        {
            _tandVardContext = tandVardContext;
        }

        public async Task<TblPatient> SingelPatientAsync(PatientDTO requestedPatient)
        {
            var value = await _tandVardContext.TblPatients.
                FirstOrDefaultAsync(table => table.FldSSnumber.Equals(requestedPatient.FldSSnumber));
            return value;
        }
    }
}
