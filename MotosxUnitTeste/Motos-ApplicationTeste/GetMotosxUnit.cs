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
   public class GetMotosxUnit : IClassFixture<MotosxUnitController>
    {
        private readonly MotosMController controller;

        public GetMotosxUnit(MotosxUnitController conntroler)
        {
            controller = new MotosMController(conntroler.motos);
        }

        [Fact]
        public async Task Get_return_OkResult()
        {
            //Act
            var data = await controller.Get();

            //Assert
            //data.Result.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be(200);
            data.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be(200);

        }
        [Fact]
        public async Task Get_return_BadRequest()
        {
            //Act
            var data = await controller.Get();
            //Assert
            data.Should().BeOfType<BadRequestObjectResult>().Which.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task GetById_return_OkResult()
        {
            //Act
            var data = await controller.GetById(1);
            //Assert
            data.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetById_return_BadRequest()
        {
            //Act
            var data = await controller.GetById(0);
            //Assert
            data.Should().BeOfType<BadRequestObjectResult>().Which.StatusCode.Should().Be(400);
        }


    }
}
