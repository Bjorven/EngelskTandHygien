using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TandVark.Domain.Repositories.Interfaces;

using TandVark.Domain.Models;
using System.ComponentModel.DataAnnotations;
using TandVark.Domain.Services.Interfaces;
using System.Net;

namespace TandVark_ASP.NETCORE_REACT.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IUserServices _userService;

        public AuthenticationController(IUserServices userService)
        {
            _userService = userService;
        }
    
        [HttpPost]
        [Route("{FromBody}")]
        public async Task<IActionResult> AuthenticateUserAsync([FromBody]UserViewModel credentialsModel)
        {
            try
            {
                if (credentialsModel.UserName == null)
                    throw new ArgumentNullException($"Parameter {nameof(credentialsModel.UserName)} cannot be null", nameof(credentialsModel.UserName));
                if (credentialsModel.PassWord == null)
                    throw new ArgumentNullException($"Parameter {nameof(credentialsModel.PassWord)} cannot be null", nameof(credentialsModel.PassWord));

                return Ok(await _userService.AuthenticationAsync(credentialsModel));

            }
            catch (ArgumentNullException argumentNullException)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, argumentNullException.Message);
            }
            catch (ArgumentException argumentException)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, argumentException.Message);
            }
            catch (NullReferenceException nullReferenceException)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, nullReferenceException.Message);
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
            }
        }

    }
}
