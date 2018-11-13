using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TandVark.Domain.Services.Interfaces;

namespace TandVark_ASP.NETCORE_REACT.Controllers
{
    [Route("api/[controller]")]
    public class DentistController : Controller
    {

        private readonly IPatientServices _patientServices;

        public DentistController(IPatientServices patientServices)
        {
            _patientServices = patientServices;
        }

        [HttpGet("{requestedPatientSSNumber}")]
        public IActionResult AllAppointments()
        {
            return View();
        }
    }
}