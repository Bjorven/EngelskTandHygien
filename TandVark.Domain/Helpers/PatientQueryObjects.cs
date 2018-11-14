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

namespace TandVark.Domain.Helpers
{
    public static class PatientQueryObjects
    {
        


       

        public static IQueryable<TSource> Future<TSource>(this IQueryable<TSource> @this) where TSource : IHasDate
        {
            var dateNow = DateTime.Today;

            var result = @this.Where(x => x.FldAppointmentBegin > dateNow);

            return result;

        }

        
    }
}

