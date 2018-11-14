using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TandVark.Data.Data1;

namespace TandVark.Domain.Helpers
{
    public static class PatientQueryObjects
    {
        


        public static IQueryable<TblPatient> AllPatients(this IQueryable<TblPatient> @this)
        {
            var dateNow = new DateTime().Date;
            
            var patients = @this.Include()
            return patients;
        }
    }
}

