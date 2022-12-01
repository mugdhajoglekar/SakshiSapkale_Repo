namespace DapperWebApi.Controllers
{
    using Dapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Data.SqlClient;
    using System.Configuration;
    using DapperWebApi.Inventory;
    using DapperWebApi.Models;
    using DapperWebApi.Interfaces;
    using System.Security.Cryptography;
    using DapperWebApi.Dto;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authorization;
    using Serilog.AspNetCore;

    [Route("api/[controller]")]
    [ApiController]

    public class SuperHeroesController : ControllerBase
    {
        public static User user = new User();
        //Access QuriesRepository
        QueriesRepository db = new QueriesRepository();

        private readonly IConfiguration _config;
        //Add log
        private readonly ILogger<SuperHeroesController> _logger;

        public SuperHeroesController(IConfiguration config, ILogger<SuperHeroesController> logger)
        {
             _config = config;
            _logger = logger;
            ///_herorepo = new QueriesRepository(config);
        }

        //For Token
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Username = request.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(user);
        }
        
        // If User is Registered then create token for it
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            if (user.Username != request.Username)
            {
                return BadRequest("User not found !");
            }
            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Entered Credentials are wrong");
            }

            string token = CreateToken(user);

            return Ok(token);
        }
        //Methods 
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role,"Admin") // Role
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                 _config.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                 claims: claims,
                 expires: DateTime.Now.AddDays(1),
                 signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        //Read all records
        [HttpGet, Authorize]
        public IActionResult GetAllSuperHeroes()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var output = db.GetAll(connection);
            return Ok(output);
        }

        //Get record
        [HttpGet("{heroId}")]
        public ActionResult GetHero(int heroId)
        {
            //Add log
            _logger.LogInformation("Getting SuperHero with specific ID...");

            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var output = db.GetSingleItem(connection,heroId);
            return Ok(output);
        }

        //Create
        [HttpPost,Authorize(Roles = "Admin")]
        public ActionResult CreateHero(SuperHero hero)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            db.addHero(connection,hero);
            return Ok(db.GetAll(connection));
            //return Ok(1);
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
