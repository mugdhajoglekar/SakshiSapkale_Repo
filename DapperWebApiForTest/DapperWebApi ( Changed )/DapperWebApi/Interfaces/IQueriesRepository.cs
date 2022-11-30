namespace DapperWebApi.Interfaces
{
    using Dapper;
    using DapperWebApi.Models;
    using System.Data.SqlClient;

    public interface IQueriesRepository
    {
        public IEnumerable<SuperHero> GetAll(SqlConnection connection);
        /*
        public IEnumerable<SuperHero> GetSingleItem(SqlConnection connection, int heroId);
        public IEnumerable<SuperHero> addHero(SqlConnection connection, SuperHero hero);
        public IEnumerable<SuperHero> editHero(SqlConnection connection, SuperHero hero);
        public IEnumerable<SuperHero> removeHero(SqlConnection connection, int heroId);
        */
    }
}
