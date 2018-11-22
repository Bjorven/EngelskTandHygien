using System;
using Xunit;
using FakeItEasy;
using System.Collections.Generic;

using TandVark_ASP.NETCORE_REACT.Controllers;
using TandVark.Domain.Services.Interfaces;
using TandVark.Domain.Services;

using Microsoft.AspNetCore.Mvc;
using System.Net;
using TandVark.Domain.DTO;
using TandVark.Data.Data1;
using Microsoft.EntityFrameworkCore;
using TandVark.Domain.Helpers;
using System.Threading;
using TandVark.Domain.Helpers.Interfaces;

namespace TandVark.UnitTest
{
    public class PatientTest
    {
        

        [Fact]
        public async void HttpGet_SingelPatient_RequestWillOnlyWorkWithValidInput()
        {
            //ARRANGE
            var expectedType = typeof(OkObjectResult);
            var expectedStatusCode = (int)HttpStatusCode.OK;

            
            var fakeUserInput = "198901263999";
            
            var fakeUserResult = A.Fake<PatientDTO>();
            var fakeService = A.Fake<IPatientServices>();
            var fakeHelperValidation = A.Fake<IHelperValidationSSN>();
            
            
            A.CallTo(() => fakeService.SingelPatientAsync(fakeUserInput)).Returns(fakeUserResult);
            A.CallTo(() => fakeHelperValidation.Validate(fakeUserInput)).Returns(true);
            
            var sut = new PatientController(fakeService, fakeHelperValidation);

            //ACT
            
            var result = await sut.SingelPatientDetailsAsync(fakeUserInput) as OkObjectResult;
            
            //ASSERT
            Assert.Equal(expectedType, result.GetType());
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }

        [Fact]
        public async void HttpGet_SingelPatient_RequestWillFailWithInValidInputAndThrowNullException()
        {
            //ARRANGE
            var expectedType = typeof(BadRequestObjectResult);
            var expectedStatusCode = (int)HttpStatusCode.BadRequest;
            var requestedPatientSSNumber = "";
            var message = $"Parameter {nameof(requestedPatientSSNumber)} Must be 12 characters long and may only contain digits.";

            var fakeUserInput = "210301230123";
            

            var fakeException = new NullReferenceException (message);
            var fakeHelperValidation = A.Fake<IHelperValidationSSN>();

            var fakeService = A.Fake<IPatientServices>();

            A.CallTo(() => fakeService.SingelPatientAsync(fakeUserInput)).Throws(fakeException);

            var sut = new PatientController(fakeService, fakeHelperValidation);

            //ACT
            
            var result = await sut.SingelPatientDetailsAsync(fakeUserInput) as BadRequestObjectResult;

            //ASSERT
            Assert.IsType(expectedType, result);
            Assert.Equal(message, result.Value);
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
        [Fact]
        public async void HttpGet_SingelPatient_RequestWillFailWithNoInputAndThrowArgumentException()
        {
            //ARRANGE
            var expectedType = typeof(BadRequestObjectResult);
            var expectedStatusCode = (int)HttpStatusCode.BadRequest;

            var fakeUserInput = "";
            var requestedPatientSSNumber = "";
            var message = $"Parameter {nameof(requestedPatientSSNumber)} Must be 12 characters long and may only contain digits.";
            var fakeException = new NullReferenceException(message);
            var fakeException2 = new ArgumentException(message);

            var fakeHelperValidation = A.Fake<IHelperValidationSSN>();

            var fakeService = A.Fake<IPatientServices>();
            //A.CallTo(() => fakeService.SingelPatientAsync(fakeUserInput)).Throws(fakeException);
            A.CallTo(() => fakeHelperValidation.Validate(fakeUserInput)).Returns(false);

            var sut = new PatientController(fakeService, fakeHelperValidation);

            //ACT

            var result = await sut.SingelPatientDetailsAsync(fakeUserInput) as BadRequestObjectResult;

            //ASSERT
            Assert.IsType(expectedType, result);
            Assert.Equal(message, result.Value);
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }

   
        [Fact]
        public void validateSSNrTrue()
        {
            //Arrange
            var UserInputSSNr = "198901263999";
            

            var sut = new HelperValidationSSN();
            //ACT
            var result = sut.Validate(UserInputSSNr);
            //ASSERT
            Assert.True(result);
           
        }

        [Fact]
        public void validateSSNrFalse()
        {
            //Arrange
            var UserInputSSNr = "198901263995";
            

            var sut = new HelperValidationSSN();
            //ACT
            var result = sut.Validate(UserInputSSNr);
            //ASSERT
            Assert.False(result);

        }
        [Fact]
        public void validateSSNrwithNonNumberStringReturnsFalse()
        {
            //Arrange
            var UserInputSSNr = "asdasfasfads";


            var sut = new HelperValidationSSN();
            //ACT
            var result = sut.Validate(UserInputSSNr);
            //ASSERT
            Assert.False(result);

        }
        [Fact]
        public void validateSSNrwithEmptyStringReturnsFalse()
        {
            //Arrange
            var UserInputSSNr = "";


            var sut = new HelperValidationSSN();
            //ACT
            var result = sut.Validate(UserInputSSNr);
            //ASSERT
            Assert.False(result);

        }
        [Fact]
        public async void HttpGetAllPatient_HappyPath() {
            //ARRANGE
            var expected = typeof(OkObjectResult);
            var fakePageNumber = 1;
            var fakeUserResult = A.Fake<List<PatientDTO>>();
            var fakeService = A.Fake<PatientServices>();
            var fakeHelper = A.Fake<IHelperValidationSSN>();

            A.CallTo(() => fakeService.AllPatients(fakePageNumber)).Returns(fakeUserResult);
            var sut = new PatientController(fakeService, fakeHelper);

            //ACT

            var result = await sut.AllPatients(1);
            //ASSERT
            Assert.IsType(expected, result);
        }

    }
}
