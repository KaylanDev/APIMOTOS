using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Motos.API.Controllers;
using Motos.Application.DTO;
using MotosxUnitTeste.xUnitTeste;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotosxUnitTeste.Motos_ApplicationTeste
{
   public class PostMotosxUnit : IClassFixture<MotosxUnitController>
    {
        private readonly MotosMController controller;

        public PostMotosxUnit(MotosxUnitController controller)
        {

           this.controller = new MotosMController(controller.motos,controller.cacheService);
        }

        [Fact]
        public async Task Post_return_OkResult()
        {
            //Act
            var data = await controller.Post(new MotosDTO() {  Modelo = "Hornet", Imagem = "dadsdaaadsdasda", Marca = "Honda",Potencia = 0,Preco = 42000});
            //Assert
            data.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be(200);
        }

    }
}
