namespace DapperWebApi.Inventory
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Dapper;
    using DapperWebApi.Models;
    using Microsoft.Extensions.Configuration;

    public class QueriesRepository 
    {
        public IConfiguration Configuration { get; }
        public QueriesRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task<IEnumerable<SuperHero>> GetAll()
        {
            var sql = "select * from SuperHeroes";
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                var heroes = await connection.QueryAsync<SuperHero>(sql);
                return heroes.ToList();
            }
        }
        /*
        public async Task<IEnumerable<SuperHero>> GetSingleItem(int heroId)
        {
            var sql = "select * from SuperHeroes where id=@Id";
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                var heroe = await connection.QueryAsync<SuperHero>(sql, new { Id = heroId });
                return heroe;
            }
        }
        public async Task<IEnumerable<SuperHero>> addHero(SuperHero hero)
        {
            var sql = "insert into SuperHeroes(id,name,firstname,lastname,place) values(@Id, @Name, @FirstName, @LastName, @Place)";
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                var added_heroe = await connection.QueryAsync<SuperHero>(sql, new { Id = hero.Id, Name = hero.Name, FirstName = hero.FirstName, LastName = hero.LastName, Place = hero.Place});
                return added_heroe;
            }
        }
        public async Task<IEnumerable<SuperHero>> editHero(SuperHero hero)
        {
            var sql = "update SuperHeroes set id=@Id, name=@Name, firstname=@FirstName, lastname=@LastName, place=@Place where id=@Id";
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                var edited_heroe = await connection.QueryAsync<SuperHero>(sql, new { Id = hero.Id, Name = hero.Name, FirstName = hero.FirstName, LastName = hero.LastName, Place = hero.Place});
                return edited_heroe;
            }
        }

        public async Task<IEnumerable<SuperHero>> removeHero(int heroId)
        {
            var sql = "delete from SuperHeroes where id=@Id";
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                var removed_heroe = await connection.QueryAsync<SuperHero>(sql, new { Id = heroId });
                return removed_heroe;
            }
        }
        */

    }
}
