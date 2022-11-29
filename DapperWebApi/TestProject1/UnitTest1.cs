namespace TestProject1
{
    using Moq;
    using DapperWebApi.Controllers;
    using DapperWebApi.Models;
    using Microsoft.AspNetCore.Mvc;
    using DapperWebApi.Inventory;
    using Microsoft.Extensions.Configuration;
    using FluentAssertions;
    using FakeItEasy;
    using DapperWebApi.Interfaces;

    public class UnitTest1
    {
        //public Mock<IConfiguration> mock = new Mock<IConfiguration>();
        private readonly SuperHeroesController _demorepo;
       // private readonly IConfiguration config;

        public UnitTest1(IConfiguration configuration)
        {
            _demorepo = new SuperHeroesController(configuration);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = _demorepo.GetAllSuperHeroes();
            Assert.NotNull(result);
        }
        /*
        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = _controller.GetAllSuperHeroes();
            Assert.IsType<ViewResult>(result);
        }*/
        
    }
}