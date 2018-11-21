using System;
using System.Linq;
using TandVark.Data.Interfaces;

namespace TandVark.Domain.Helpers
{
    public static class PatientQueryObjects
    {

        public static IQueryable<TSource> FutureAppointments<TSource>(this IQueryable<TSource> @this, DateTime presentDate) where TSource : IHasAppointment
        {
            var dateNow = presentDate;

            var result = @this.Where(x => x.FldAppointmentBegin > dateNow);

            return result;

        }

        
    }
}

