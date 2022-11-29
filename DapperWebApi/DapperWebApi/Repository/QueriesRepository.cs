namespace DapperWebApi.Inventory
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Dapper;
    using DapperWebApi.Interfaces;
    using DapperWebApi.Models;

    public class QueriesRepository
    {
        public IEnumerable<SuperHero> GetAll(SqlConnection connection)
        {
            return connection.Query<SuperHero>("select * from SuperHeroes");
        }
        public IEnumerable<SuperHero> GetSingleItem(SqlConnection connection,int heroId)
        {
            return connection.Query<SuperHero>("select * from SuperHeroes where id=@Id", new { Id = heroId });
        }
        public IEnumerable<SuperHero> addHero(SqlConnection connection, SuperHero hero)
        {
            return connection.Query<SuperHero>("insert into SuperHeroes(id,name,firstname,lastname,place) values(@Id, @Name, @FirstName, @LastName, @Place)",
                new { Id = hero.Id, Name=hero.Name ,FirstName=hero.FirstName, LastName=hero.LastName, Place=hero.Place,});
        }
        public IEnumerable<SuperHero> editHero(SqlConnection connection, SuperHero hero)
        {
            return connection.Query<SuperHero>("update SuperHeroes set id=@Id, name=@Name, firstname=@FirstName, lastname=@LastName, place=@Place where id=@Id",
                new { Id = hero.Id, Name = hero.Name, FirstName = hero.FirstName, LastName = hero.LastName, Place = hero.Place, });
        }
        public IEnumerable<SuperHero> removeHero(SqlConnection connection, int heroId)
        {
            return connection.Query<SuperHero>("delete from SuperHeroes where id=@Id", new { Id = heroId });
        }

    }
}
