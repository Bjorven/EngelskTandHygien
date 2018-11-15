using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TandVark.Data.Data1;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;
using TandVark.Data.Interfaces;
using TandVark.Domain.Helpers.Interfaces;

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

