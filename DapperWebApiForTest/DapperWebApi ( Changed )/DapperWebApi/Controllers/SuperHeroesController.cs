namespace DapperWebApi.Controllers
{
    using Dapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Data.SqlClient;
    using System.Configuration;
    using DapperWebApi.Inventory;
    using DapperWebApi.Models;

    [Route("api/[controller]")]
    [ApiController]

    public class SuperHeroesController : ControllerBase
    {
        private readonly QueriesRepository _herorepo;
        //Add log
        private readonly ILogger<SuperHeroesController> _logger;

        public SuperHeroesController(IConfiguration config, ILogger<SuperHeroesController> logger)
        {
            _herorepo = new QueriesRepository(config);
            _logger = logger;
        }

        //Read all records
        [HttpGet]
        public async Task<IActionResult> GetAllSuperHeroes()
        {
            //Add log
            _logger.LogInformation("Getting SuperHero with specific ID...");
            try
            {
                var heroes = await _herorepo.GetAll();
                return Ok(heroes);
            }
            catch (Exception err)
            { return StatusCode(500, err.Message); }
        }

    }
}
