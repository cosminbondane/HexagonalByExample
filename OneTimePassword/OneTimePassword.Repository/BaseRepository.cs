using Dapper.FastCrud;
using OneTimePassword.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePassword.Repository
{
    public abstract class BaseRepository
    {
        protected string connectionString;

        public BaseRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
        }
    }
}
