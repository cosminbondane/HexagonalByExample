using Dapper.FastCrud;
using OneTimePassword.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePassword.Repository
{
    public abstract class BaseRepository<T> where T : class, new()
    {
        protected string connectionString;

        public BaseRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
        }

        public void Insert(T entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Insert(entity);
            }
        }

        public bool Update(T entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Update(entity);
            }
        }

        public bool Delete(T entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Delete(entity);
            }
        }
    }
}
