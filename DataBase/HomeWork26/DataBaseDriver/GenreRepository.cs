using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseDriver.Model;
using Dapper;


namespace DataBaseDriver
{
    public class GenreRepository : IRepository<Genre>
    {
        private readonly string _connectionBaseStr;

        public GenreRepository(string connectionBaseStr)
        {
            _connectionBaseStr = connectionBaseStr;
        }

        public int Create(Genre genre)
        {
            var sql = "INSERT INTO Genres(Name, Description) VALUES(@Name,@Description); SELECT CAST(SCOPE_IDENTITY() as int)";
            int? Id;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                Id = sqlConnection.Query<int>(sql, genre).FirstOrDefault();
            }
            return Id==null?0:(int)Id;
        }

        public Genre GetByName(string name)
        {
            var sql = $"SELECT * FROM Genres g WHERE g.Name ='{name}'";
            Genre genre;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                sqlConnection.Open();
                genre = sqlConnection.QueryFirstOrDefault<Genre>(sql);
                sqlConnection.Close();
            }
            return genre;
        }

        public int Delete(Genre genre)
        {
            string sql = "DELETE FROM Genres WHERE Id=@Id";
            int result = DbExecute(sql, genre);
            return result;
        }

        public Genre GetById(int id)
        {
            var sql = $"SELECT * FROM Genres g WHERE g.id ={id}";
            Genre result;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                sqlConnection.Open();
                result = sqlConnection.QueryFirstOrDefault<Genre>(sql);
                sqlConnection.Close();
            }
            return result;
        }

        public IEnumerable<Genre> GetAll()
        {
            List<Genre> genres;
            string sql = "SELECT * FROM Genres";
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                genres = sqlConnection.Query<Genre>(sql).ToList();
            }
            return genres;
        }

        public int Update(Genre genre)
        {
            var sql = "UPDATE Genres SET Name = @Name, Description = @Description WHERE Id = @Id";
            int result = DbExecute(sql, genre);
            return result;
        }

        private int DbExecute(string sql, Genre genre)
        {
            int result;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                sqlConnection.Open();
                result = sqlConnection.Execute(sql, genre);
                sqlConnection.Close();
            }
            return result;
        }
    }
}
