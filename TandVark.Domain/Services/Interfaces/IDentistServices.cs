﻿using System;
using System.Collections.Generic;
using System.Text;
using TandVark.Data.Data1;
using TandVark.Domain.DTO;

namespace TandVark.Domain.Services.Interfaces
{
    public interface IDentistServices
    {

        List<TblAppointment> AllDentistFutureAppointments(int dID);
        
    }
}
