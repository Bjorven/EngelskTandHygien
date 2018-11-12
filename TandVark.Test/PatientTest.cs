using System;
using Xunit;
using FakeItEasy;
using TandVark.Domain.Repositories.Interfaces;
using TandVark.Domain.Models.Interfaces;
using TandVark.Domain.Models;
using System.Collections.Generic;

using TandVark_ASP.NETCORE_REACT.Controllers;

using System.ComponentModel.DataAnnotations;
using TandVark.Domain.Services.Interfaces;
using TandVark.Domain.Services;

using Microsoft.AspNetCore.Mvc;
using System.Net;
using TandVark.Domain.DTO;
using TandVark.Data.Data1;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TandVark.Domain.Helpers;

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

            var fakeUserDTOInput= A.Fake<PatientDTO>();
            fakeUserDTOInput.FldSSnumber = "210301230123";
            var fakeUserDTOResult = A.Fake<PatientDTO>();
            var fakeService = A.Fake<IPatientServices>();
            
            A.CallTo(() => fakeService.SingelPatientAsync(fakeUserDTOInput)).Returns(fakeUserDTOResult);

            var sut = new PatientController(fakeService);

            //ACT
            var result = await sut.SingelPatientDetailsAsync(fakeUserDTOInput) as OkObjectResult;
            
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
            var message = "Patient does not exist";

            var fakeUserInputDTO = A.Fake<PatientDTO>();
            fakeUserInputDTO.FldSSnumber = "210301230123";

            var fakeException = new NullReferenceException (message);
            
            var fakeService = A.Fake<IPatientServices>();

            A.CallTo(() => fakeService.SingelPatientAsync(fakeUserInputDTO)).Throws(fakeException);

            var sut = new PatientController(fakeService);

            //ACT
            
            var result = await sut.SingelPatientDetailsAsync(fakeUserInputDTO) as BadRequestObjectResult;

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
            var fakeUserInputDTO = A.Fake<PatientDTO>();
            var message = $"Parameter {nameof(fakeUserInputDTO.FldSSnumber)} cannot be null";
            var fakeException = new NullReferenceException(message);

            var fakeService = A.Fake<IPatientServices>();
            A.CallTo(() => fakeService.SingelPatientAsync(fakeUserInputDTO)).Throws(fakeException);

            var sut = new PatientController(fakeService);

            //ACT

            var result = await sut.SingelPatientDetailsAsync(fakeUserInputDTO) as BadRequestObjectResult;

            //ASSERT
            Assert.IsType(expectedType, result);
            Assert.Equal(message, result.Value);
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }

        [Fact]
        public async void GetValidSinglePatient_WillOnlyWorkWithValidInput()
        {
            //Arrange
            var fakeUserInput = A.Fake<PatientDTO>();
            fakeUserInput.FldSSnumber = "198901263999";
            var fakeRepository = A.Fake<IPatientRepository>();

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

            A.CallTo(() => fakeRepository.SingelPatientAsync(fakeUserInput)).Returns(fakeTblPatient);
           
            var sut = new PatientServices(fakeRepository);

            //ACT
            var result = await sut.SingelPatientAsync(fakeUserInput);

            //ASSERT
            Assert.IsType<PatientDTO>(result);

            Assert.True(expectedResult.FldId == result.FldId && expectedResult.FldFirstName == result.FldFirstName);

        }
        [Fact]
        public void validateSSNrTrue()
        {
            //Arrange
            var UserInputSSNrDTO = A.Fake<PatientDTO>();
            UserInputSSNrDTO.FldSSnumber = "198901263999";

            var sut = new HelperValidationSSN();
            //ACT
            var result = sut.validate(UserInputSSNrDTO);
            //ASSERT
            Assert.True(result);
           
        }

        [Fact]
        public void validateSSNrFalse()
        {
            //Arrange
            var UserInputSSNrDTO = A.Fake<PatientDTO>();
            UserInputSSNrDTO.FldSSnumber = "198901263995";

            var sut = new HelperValidationSSN();
            //ACT
            var result = sut.validate(UserInputSSNrDTO);
            //ASSERT
            Assert.False(result);

        }

    }
}
