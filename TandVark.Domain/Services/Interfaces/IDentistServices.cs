using System.Collections.Generic;
using TandVark.Data.Data1;

namespace TandVark.Domain.Services.Interfaces
{
    public interface IDentistServices
    {

        List<TblAppointment> AllDentistFutureAppointments(int dID);
        
    }
}
