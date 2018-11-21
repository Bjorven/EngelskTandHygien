using System;
using Xunit;
using FakeItEasy;
using TandVark.Domain.Repositories.Interfaces;
using TandVark.Domain.Models;
using System.Collections.Generic;


using TandVark_ASP.NETCORE_REACT.Controllers;

using System.ComponentModel.DataAnnotations;
using TandVark.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TandVark.Domain.DTO;

namespace TandVark.Test
{
    public class TandVarkTests
    {
        [Theory]
        [InlineData(true, null, "Authenticated")]          // Valid input
        [InlineData(false, "0x003", "Not authenticated")]
        public async void AuthenticateCard_ParameterizedInput_AuthenticationWillOnlyWorkWithValidInputAndCorrectErrorMessagesWillBeReturned(bool isValid, string errorCode, string message)
        {
            //Arrange
            var expectedType = typeof(OkObjectResult);
            var expectedStatusCode = (int)HttpStatusCode.OK;

            var expectedMessage = message;
            var expectedErrorCode = errorCode;

            var fakeUserInput = A.Fake<UserViewModel>();
            fakeUserInput.UserName = "U1";
            fakeUserInput.PassWord = "1234";

            var fakeUserDTO = A.Fake<UserDTO> ();
            var fakeService = A.Fake<IUserServices>();


             A.CallTo(() => fakeService.AuthenticationAsync(fakeUserInput)).Returns(fakeUserDTO);
              

            var sut = new AuthenticationController(fakeService);

            //Act
            var result = await sut.AuthenticateUserAsync(fakeUserInput) as OkObjectResult;

            //Assert
            Assert.Equal(expectedType, result.GetType());
            Assert.Equal(expectedStatusCode, result.StatusCode);
            
        }

    }
}
