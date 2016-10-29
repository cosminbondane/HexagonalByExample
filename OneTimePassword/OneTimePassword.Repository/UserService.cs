using OneTimePassword.Business.Dependencies;
using OneTimePassword.Domain.Entities;
using System;
using System.Data.SqlClient;
using Dapper.FastCrud;
using System.Linq;

namespace OneTimePassword.Repository
{
    public class UserService : BaseRepository<User>, IUserService
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

        public User GetInfoByUsername(string username)
        {
            User user = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                user = connection.Find<User>(statement => statement
                    .Where($"{nameof(User.Username):C}=@Username")
                    .Include<Role>(join => join.InnerJoin())
                    .WithParameters(new { Username = username })).FirstOrDefault();
            }

            return user;
        }
    }
}
