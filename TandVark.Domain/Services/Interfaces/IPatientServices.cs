﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TandVark.Data.Data1;
using TandVark.Domain.DTO;
using TandVark.Domain.Models;

namespace TandVark.Domain.Services.Interfaces
{
    public interface IPatientServices
    {
        Task<TblPatient> SingelPatientAsync(string requestedPatient);
        Task<IEnumerable<TblPatient>> AllPatients();
        List<TblAppointment> AllPatientsFutureAppointments(int requestedPatient);
    }
}