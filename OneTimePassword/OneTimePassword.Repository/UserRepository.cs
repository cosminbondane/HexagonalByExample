using OneTimePassword.Business.Dependencies;
using OneTimePassword.Domain.Entities;
using System;
using System.Data.SqlClient;
using Dapper.FastCrud;
using System.Linq;

namespace OneTimePassword.Repository
{
    public class UserRepository : IUserRepository
    {
        public User GetByUsername(string username)
        {
            User user = null;
            using (SqlConnection connection = new SqlConnection())
            {
                user = connection.Get(new User { Username = username });
            }

            return user;
        }

        public bool Update(User user)
        {
            if (user == null)
            {
                return false;
            }

            using (SqlConnection connection = new SqlConnection())
            {
                return connection.Update(user);
            }
        }
    }
}
