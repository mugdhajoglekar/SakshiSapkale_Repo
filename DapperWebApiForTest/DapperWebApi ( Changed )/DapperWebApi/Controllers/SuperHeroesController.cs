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


        public SuperHeroesController(IConfiguration config)
        {
            _herorepo = new QueriesRepository(config);
        }

        //Read all records
        [HttpGet]
        public async Task<IActionResult> GetAllSuperHeroes()
        {
            
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
