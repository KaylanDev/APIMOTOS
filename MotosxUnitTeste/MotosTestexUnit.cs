using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Motos.API.Controllers;
using MotosxUnitTeste.xUnitTeste;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MotosxUnitTeste
{
   public class MotosTestexUnit : IClassFixture<MotosxUnitController>
    {
        private readonly MotosMController controller;

        public MotosTestexUnit(MotosxUnitController conntroler)
        {
            controller = new MotosMController(conntroler.uof);
        }

        [Fact]
        public async Task Get_return_OkResult()
        {
            //Act
            var data = await controller.Get();

            //Assert
            data.Result.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be(200);

        }
    }
}
