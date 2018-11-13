using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TandVark.Data.Data1;

namespace TandVark.Domain.Helpers
{
    public static class Pageinator
    {

        //PatientView Paginator
        public static IQueryable<TblPatient> Page(this IQueryable<TblPatient> @this, int page, int n = 12)
        {
            return @this.Skip(n * (page - 1)).Take(n);
        }
    }
}
