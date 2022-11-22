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
        //Access QuriesRepository
        QueriesRepository db = new QueriesRepository();

        private readonly IConfiguration _config;

        public SuperHeroesController(IConfiguration config)
        {
            _config = config;
        }

        //Read all records
        [HttpGet]
        public ActionResult GetAllSuperHeroes()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var output = db.GetAll(connection);
            return Ok(output);
        }

        //Get record
        [HttpGet("{heroId}")]
        public ActionResult GetHero(int heroId)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var output = db.GetSingleItem(connection,heroId);
            return Ok(output);
        }

        //Create
        [HttpPost]
        public ActionResult CreateHero(SuperHero hero)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            db.addHero(connection,hero);
            return Ok(db.GetAll(connection));
        }

        //Update 
        [HttpPut]
        public ActionResult UpdateHero(SuperHero hero)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            db.editHero(connection, hero);
            return Ok(db.GetAll(connection));
        }

        //delete
        [HttpDelete("{heroId}")]
        public ActionResult DeleteHero(int heroId)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            db.removeHero(connection, heroId);
            return Ok(db.GetAll(connection));
        }

    }
}
