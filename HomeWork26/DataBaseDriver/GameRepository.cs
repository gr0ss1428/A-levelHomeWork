using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseDriver.Model;
using Dapper;
using System.Data.SqlClient;

namespace DataBaseDriver
{
    public class GameRepository : IGameRepository
    {
        private readonly string _connectionBaseStr;

        public GameRepository(string connectionBaseStr)
        {
            _connectionBaseStr = connectionBaseStr;
        }

        public int Create(Game model)
        {
            var sql = "INSERT INTO Games(Name, YearPublishing, GenreId, PublicherId) VALUES(@Name,@YearPublishing,@GenreId,@PublicherId); SELECT CAST(SCOPE_IDENTITY() as int)";
            int? Id;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                sqlConnection.Open();
                Id = sqlConnection.Query<int>(sql, model).FirstOrDefault();
                sqlConnection.Close();
            }
            return Id == null ? 0 : (int)Id;
        }

        public int Delete(Game model)
        {
            string sql = "DELETE FROM Games WHERE Id=@Id";
            int result = DbExecute(sql, model);
            return result;
        }

        public IEnumerable<Game> GetAll()
        {
            List<Game> games;
            string sql = "SELECT * FROM Games";
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                sqlConnection.Open();
                games = sqlConnection.Query<Game>(sql).ToList();
                sqlConnection.Close();
            }
            return games;
        }

        public Game GetById(int id)
        {
            var sql = $"SELECT * FROM Games g WHERE g.id ={id}";
            Game result;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                sqlConnection.Open();
                result = sqlConnection.QueryFirstOrDefault<Game>(sql);
                sqlConnection.Close();
            }
            return result;
        }

        public Game GetByName(string name)
        {
            var sql = $"SELECT * FROM Games g WHERE g.Name ='{name}'";
            Game result;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                sqlConnection.Open();
                result = sqlConnection.QueryFirstOrDefault<Game>(sql);
                sqlConnection.Close();
            }
            return result;
        }

        public int Update(Game model)
        {
            var sql = "UPDATE Games SET Name = @Name, YearPublishing=@YearPublishing, GenreId=@GenreId, PublicherId=@PublicherId WHERE Id = @Id";
            int result = DbExecute(sql, model);
            return result;
        }

        public IEnumerable<Game> GetGameByGenre(int genreId)
        {
            var sql = $" SELECT * FROM Games g WHERE g.GenreId={genreId}";
            List<Game> games;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                sqlConnection.Open();
                games = sqlConnection.Query<Game>(sql).ToList();
                sqlConnection.Close();
            }
            return games;
        }

        public IEnumerable<Game> GetGameByPublisher(int publisherId)
        {
            var sql = $" SELECT * FROM Games g WHERE g.PublicherId={publisherId}";
            List<Game> games;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                sqlConnection.Open();
                games = sqlConnection.Query<Game>(sql).ToList();
                sqlConnection.Close();
            }
            return games;
        }
        public Game GetByNameYearPublishing(Game game)
        {
            var sql = $"SELECT * FROM Games g WHERE g.Name = @Name AND g.YearPublishing=@YearPublishing";
            Game result;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                sqlConnection.Open();
                result = sqlConnection.QueryFirstOrDefault<Game>(sql, game);
                sqlConnection.Close();
            }
            return result;
        }

        private int DbExecute(string sql, Game game)
        {
            int result;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                sqlConnection.Open();
                result = sqlConnection.Execute(sql, game);
                sqlConnection.Close();
            }
            return result;
        }

    }
}
