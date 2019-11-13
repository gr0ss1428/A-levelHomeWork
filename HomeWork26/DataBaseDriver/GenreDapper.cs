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
    public class GenreDapper : IGenreRepository
    {
        private readonly string _connectionBaseStr;

        public GenreDapper(string connectionBaseStr)
        {
            _connectionBaseStr = connectionBaseStr;
        }

        public Genre Create(Genre genre)
        {
            var sql = $"INSERT INTO Genres(Name, Description) VALUES('{genre.Name}','{genre.Description}')";
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                sqlConnection.Open();
                var result =(int)sqlConnection.Execute(sql);
                genre.Id = result;
                sqlConnection.Close();
            }
            return genre;
        }

        public void Delete(Genre genre)
        {
            throw new NotImplementedException();
        }

        public Genre GetById(int id)
        {
            var sql = $"SELECT * FROM Genres g WHEN g.id ={id}";
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                sqlConnection.Open();
                var result = sqlConnection.QueryFirst(sql);
                sqlConnection.Close();

                return result;
            }
        }

        public void Update(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
