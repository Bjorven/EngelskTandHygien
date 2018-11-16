using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TandVark.Domain.DTO;
using TandVark.Domain.Services.Interfaces;

namespace TandVark_ASP.NETCORE_REACT.Controllers
{
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<IActionResult> NewAppointmentAsync([FromBody] AppointmentDTO appointment)
        {
            try
            {
                var result = await _appointmentService.CreateNewAppointment(appointment);
                return Ok(result);
            }
            catch (ArgumentException argumentException)
            {
                return BadRequest(argumentException.Message);
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);

            }

        }
        
        [HttpDelete("{appointmentID}")]
        public async  Task<IActionResult> Appointment(int appointmentID)
        {
            var result = await _appointmentService.DeleteAppointment(appointmentID);
            return Ok(result);
        }
    }
}