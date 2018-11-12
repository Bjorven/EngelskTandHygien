using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TandVark.Domain.DTO;
using TandVark.Domain.Services.Interfaces;
using TandVark.Domain.Helpers;

namespace TandVark_ASP.NETCORE_REACT.Controllers
{
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private readonly IPatientServices _patientServices;

        public PatientController(IPatientServices patientServices)
        {
            _patientServices = patientServices;
        }

        [HttpPost]
        public async Task<IActionResult> SingelPatientDetailsAsync([FromBody] PatientDTO requestedPatientSSNumber)
        {
            try
            {
                var helper = new HelperValidationSSN();
                if (!helper.validate(requestedPatientSSNumber))
                    return BadRequest("Invalid SSN");
                var patient = await _patientServices.SingelPatientAsync(requestedPatientSSNumber);
                return Ok(patient);
            }
            catch (NullReferenceException nullReferenceException)
            {
                return BadRequest(nullReferenceException.Message);
            }
            catch (ArgumentNullException argumentNullException)
            {
                return BadRequest(argumentNullException.ParamName);
            }
        }
    }
    
}