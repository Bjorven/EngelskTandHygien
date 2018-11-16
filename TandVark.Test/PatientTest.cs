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
            
            var fakeUserResult = A.Fake<TblPatient>();
            var fakeService = A.Fake<IPatientServices>();
            var fakeHelperValidation = A.Fake<IHelperValidationSSN>();
            
            
            A.CallTo(() => fakeService.SingelPatientAsync(fakeUserInput)).Returns(fakeUserResult);

            
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
            var message = "Invalid SSN";

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
            var SSNr = "";
            var message = $"Parameter {nameof(SSNr)} Must be 12 characters long";
            var fakeException = new NullReferenceException(message);
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
        public async void GetValidSinglePatient_WillOnlyWorkWithValidInput()
        {
            //Arrange
            var fakeUserInput = "198901263999";
            
            var fakeContext = A.Fake<TandVerkContext>();
            var fakeDateTime = A.Fake<IDateTimeProvider>();

            var fakeCancel = A.Fake<CancellationToken>();

            var expectedResult = A.Fake<PatientDTO>();
            expectedResult.FldId = 1;
            expectedResult.FldFirstName = "Björn";
            expectedResult.FldLastName = "Bergqvist Wingren";
            expectedResult.FldSSnumber = "198901263999";
            expectedResult.FldPhoneId = "0730595983";
            expectedResult.FldEmail = "peken@live.se";
            expectedResult.FldAddress = "Gatan 11";

            var fakeTblPatient = A.Fake<TblPatient>();
            fakeTblPatient.FldPatientId = 1;
            fakeTblPatient.FldFirstName = "Björn";
            fakeTblPatient.FldLastName = "Bergqvist Wingren";
            fakeTblPatient.FldSSnumber = "198901263999";
            fakeTblPatient.FldPhoneId = "0730595983";
            fakeTblPatient.FldEmail = "peken@live.se";
            fakeTblPatient.FldAddress = "Gatan 11";

            A.CallTo(() => fakeContext.TblPatients.SingleOrDefaultAsync(x => x.FldSSnumber == fakeUserInput, fakeCancel)).Returns(fakeTblPatient);
           
            var sut = new PatientServices(fakeContext, fakeDateTime);

            //ACT
            var result = await sut.SingelPatientAsync(fakeUserInput);

            //ASSERT
            Assert.IsType<PatientDTO>(result);

            Assert.True(expectedResult.FldId == result.FldPatientId && expectedResult.FldFirstName == result.FldFirstName);

        }
        [Fact]
        public void validateSSNrTrue()
        {
            //Arrange
            var UserInputSSNr = "198901263999";
            

            var sut = new HelperValidationSSN();
            //ACT
            var result = sut.validate(UserInputSSNr);
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
            var result = sut.validate(UserInputSSNr);
            //ASSERT
            Assert.False(result);

        }
        [Fact]
        public async void HttpGetAllPatient_HappyPath() {
            //ARRANGE
            var expected = typeof(OkObjectResult);
            var fakeResponse = A.Fake<IEnumerable<TblPatient>>();
            var fakeService = A.Fake<PatientServices>();
            var fakeHelper = A.Fake<IHelperValidationSSN>();

            A.CallTo(() => fakeService.AllPatients()).Returns(fakeResponse);
            var sut = new PatientController(fakeService, fakeHelper);

            //ACT

            var result = sut.AllPatients();
            //ASSERT
            Assert.IsType(expected, result);
        }

    }
}
