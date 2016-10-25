using OneTimePassword.Business.Dependencies;
using OneTimePassword.Domain.Entities;
using System;
using System.Data.SqlClient;
using Dapper.FastCrud;
using System.Linq;

namespace OneTimePassword.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public User GetByUsername(string username)
        {
            User user = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                user = connection.Find<User>(statement => statement
                    .Where($"{nameof(User.Username):C}=@Username")
                    .WithParameters(new { Username = username })).FirstOrDefault();
            }

            return user;
        }

        public bool Update(User user)
        {
            if (user == null)
            {
                return false;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Update(user);
            }
        }
    }
}
