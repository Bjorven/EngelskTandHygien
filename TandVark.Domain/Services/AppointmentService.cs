using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TandVark.Data.Data1;
using TandVark.Domain.DTO;
using TandVark.Domain.Helpers.Interfaces;
using TandVark.Domain.Services.Interfaces;

namespace TandVark.Domain.Services
{
    public class AppointmentService:IAppointmentService
    {
        private readonly TandVerkContext _tandVardContext;
        private readonly IDateTimeProvider _dateTimeProvider;


        public AppointmentService(TandVerkContext tandVerkContext, IDateTimeProvider dateTimeProvider)
        {
            _tandVardContext = tandVerkContext;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<string> CreateNewAppointment(AppointmentDTO appointment)
        {
            using (var dbcxtransaction = _tandVardContext.Database.BeginTransaction())
            {
                var tblInsertItem = new TblAppointment()
                {
                    FldAppointmentBegin = appointment.FldAppointmentBegin,
                    FldAppointmentEnd = appointment.FldAppointmentEnd,
                    FldDenistIdFK = appointment.FldDenistIdFK,
                    FldPatientFK = appointment.FldPatientFK
                };
                if (!_tandVardContext.TblUsers.Any(x => x.FldUserId == tblInsertItem.FldDenistIdFK))
                    throw new ArgumentException("The appointed dentist does not Exist");
                if (!_tandVardContext.TblPatients.Any(x => x.FldPatientId == tblInsertItem.FldPatientFK))
                    throw new ArgumentException("The appointed patient does not Exist");

                var result = await _tandVardContext.TblAppointments.AddAsync(tblInsertItem);
                if (result.State.ToString() != "Added")
                    throw new Exception("Appointment was not added");

                _tandVardContext.SaveChanges();
                dbcxtransaction.Commit();
                return "Appointment was successfully created";
            }
        }
        public async Task<string> DeleteAppointment(int AppointmentID)
        {
            using (var dbcxtransaction = _tandVardContext.Database.BeginTransaction())
            {
                var appointment = await _tandVardContext.TblAppointments.FindAsync(AppointmentID);
                if (appointment == null)
                    throw new NullReferenceException("Appointment does not exist");
                _tandVardContext.TblAppointments.Remove(appointment);
                _tandVardContext.SaveChanges();
                dbcxtransaction.Commit();
                
                return $"Deletion of appointment nr: {appointment.FldAppointmentId}";
            }
        }
    }
}
