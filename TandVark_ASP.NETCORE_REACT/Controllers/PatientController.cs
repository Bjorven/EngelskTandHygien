using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TandVark.Domain.Services.Interfaces;
using TandVark.Domain.Helpers.Interfaces;
using TandVark.Domain.DTO;

namespace TandVark_ASP.NETCORE_REACT.Controllers
{
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private readonly IPatientServices _patientServices;
        private readonly IHelperValidationSSN _helperValidationSSN;


        public PatientController(IPatientServices patientServices, IHelperValidationSSN helperValidationSSN)
        {
            _patientServices = patientServices;
            _helperValidationSSN = helperValidationSSN;
        }

        

        

        [HttpGet("{requestedPatientSSNumber}")]
        public async Task<IActionResult> SingelPatientDetailsAsync(string requestedPatientSSNumber)
        {
            try
            {
                if (!_helperValidationSSN.Validate(requestedPatientSSNumber))
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

        [HttpGet("")]
        public async Task<IActionResult> AllPatients()
        {
            try
            {
                var patients = await _patientServices.AllPatients();
                return Ok(patients);
            }
            catch(Exception e)
            {
                return  StatusCode((int)HttpStatusCode.InternalServerError,  e.Message);
            }
        }
        [HttpPost("new")]
        public IActionResult AddNewPatient([FromBody] PatientDTO patient)
        {
            try
            {
                if(!_helperValidationSSN.Validate(patient.FldSSnumber))
                    return BadRequest("Invalid SSN");

                var result = _patientServices.AddPatients(patient);
                return Ok(result);


            }
            catch(ArgumentException argumentException)
            {
                return BadRequest(argumentException.Message);
            }
            catch(Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        
        [HttpDelete("{requestedPatientID}")]
        public IActionResult DeleteSinglePatient(int requestedPatientID)
        {
            try
            {
                var result = _patientServices.DeletePatients(requestedPatientID);
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

        [HttpPut("")]
        public IActionResult EditSingelPatient([FromBody]PatientDTO requestedPatient)
        {
            try
            {
                var result = _patientServices.EditPatients(requestedPatient);
                return Ok(result);


            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
            }
        }
    }
    
}