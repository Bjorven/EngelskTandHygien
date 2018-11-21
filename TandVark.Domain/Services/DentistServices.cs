using System.Collections.Generic;
using System.Linq;
using TandVark.Data.Data1;
using TandVark.Domain.Helpers;
using TandVark.Domain.Helpers.Interfaces;
using TandVark.Domain.Services.Interfaces;

namespace TandVark.Domain.Services
{
    public class DentistServices:IDentistServices
    {
        private readonly TandVerkContext _tandVardContext;
        private readonly IDateTimeProvider _dateTimeProvider;
        

        public DentistServices(TandVerkContext tandVerkContext, IDateTimeProvider dateTimeProvider)
        {
            _tandVardContext = tandVerkContext;
            _dateTimeProvider = dateTimeProvider;
        }

        public List<TblAppointment> AllDentistFutureAppointments(int dID)
        {
            var res = (_tandVardContext
                       .TblAppointments
                       .Where(x => x.FldDenistIdFK == dID)
                       .FutureAppointments(_dateTimeProvider.Today())
                       .ToList()
                       );
            return res;
        }

    }
}
