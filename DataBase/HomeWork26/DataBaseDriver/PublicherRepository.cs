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
    public class PublicherRepository : IRepository<Publisher>
    {
        private readonly string _connectionBaseStr;

        public PublicherRepository(string connectionBaseStr)
        {
            _connectionBaseStr = connectionBaseStr;
        }

        public int Create(Publisher model)
        {
            var sql = "INSERT INTO Publishers (Name, License) VALUES(@Name,@License); SELECT CAST(SCOPE_IDENTITY() as int)";
            int? Id;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                Id = sqlConnection.Query<int>(sql, model).FirstOrDefault();
            }
            return Id == null ? 0 : (int)Id;
        }

        public int Delete(Publisher model)
        {
            string sql = "DELETE FROM Publishers WHERE Id=@Id";
            int result = DbExecute(sql, model);
            return result;
        }

        public IEnumerable<Publisher> GetAll()
        {
            List<Publisher> publishers;
            string sql = "SELECT * FROM Publishers";
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                publishers = sqlConnection.Query<Publisher>(sql).ToList();
            }
            return publishers;
        }

        public Publisher GetById(int id)
        {
            var sql = $"SELECT * FROM Publishers p WHERE p.id ={id}";
            Publisher result;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                sqlConnection.Open();
                result = sqlConnection.QueryFirstOrDefault<Publisher>(sql);
                sqlConnection.Close();
            }
            return result;
        }

        public Publisher GetByName(string name)
        {
            var sql = $"SELECT * FROM Publishers p WHERE p.Name ='{name}'";
            Publisher publisher;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                sqlConnection.Open();
                publisher = sqlConnection.QueryFirstOrDefault<Publisher>(sql);
                sqlConnection.Close();
            }
            return publisher;
        }

        public int Update(Publisher model)
        {
            var sql = "UPDATE Publishers SET Name = @Name, License = @License WHERE Id = @Id";
            int result = DbExecute(sql, model);
            return result;
        }

        private int DbExecute(string sql, Publisher model)
        {
            int result;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionBaseStr))
            {
                sqlConnection.Open();
                result = sqlConnection.Execute(sql, model);
                sqlConnection.Close();
            }
            return result;
        }
    }
}
