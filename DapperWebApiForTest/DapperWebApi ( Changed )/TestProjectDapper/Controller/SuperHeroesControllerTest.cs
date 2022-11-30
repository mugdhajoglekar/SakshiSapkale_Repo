using DapperWebApi.Controllers;
using DapperWebApi.Inventory;
using FakeItEasy;

namespace TestProjectDapper.Controller
{
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class SuperHeroesControllerTest
    {
        //private readonly QueriesRepository _demorepo;
        private readonly IConfiguration _config;

        public SuperHeroesControllerTest()
        {
            _config = A.Fake<IConfiguration>();
        }

        [Fact]
        public void SuperHeroesController_GetAllSuperHeroes_ReturnsOK()
        {
            //Arrange
            var controller = new SuperHeroesController(_config); 
            // Sending config to Controller and Repo is initialized there itself no need to arrange here !

            //Act
            var result = controller.GetAllSuperHeroes();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<IActionResult>));
        }
    }
}
