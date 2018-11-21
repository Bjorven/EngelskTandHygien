using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TandVark.Domain.DTO;
using TandVark.Domain.Services.Interfaces;

namespace TandVark_ASP.NETCORE_REACT.Controllers
{
    [Route("api/[controller]")]
    public class DentistController : Controller
    {

        private readonly IDentistServices _dentisServices;

        public DentistController(IDentistServices dentisServices)
        {
            _dentisServices = dentisServices;
        }

        [HttpGet("{requestedDentistID}")]
        public IActionResult AllDentistFutureAppointments(int requestedDentistID)
        {
            var appointments = _dentisServices.AllDentistFutureAppointments(requestedDentistID);
            return Ok(appointments);
        }
    }
}