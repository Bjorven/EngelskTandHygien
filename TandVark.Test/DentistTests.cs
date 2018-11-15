using System;
using Xunit;
using FakeItEasy;
using System.Collections.Generic;
using TandVark_ASP.NETCORE_REACT.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TandVark.Domain.Services.Interfaces;

namespace TandVark.UnitTest
{
    public class DentistTests
    {

        [Fact]
        public void HttpGetAllAppointments()
        {
            //ARRANGE
            var fakeService = A.Fake<IDentistServices>();
            var sut = new DentistController(fakeService);
            //ACT
            var result = sut.AllDentistFutureAppointments(1);
            //ASSERT
        }
    }
}
