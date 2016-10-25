using Dapper.FastCrud;
using Dapper.FastCrud.Mappings;
using OneTimePassword.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePassword.Repository
{
    public static class RepositorySetup
    {
        public static void Register()
        {
            OrmConfiguration.DefaultDialect = SqlDialect.MsSql;

            SetupUser();
        }

        private static void SetupUser()
        {
            OrmConfiguration.GetDefaultEntityMapping<User>()
                .SetTableName("User")
                .SetProperty(user => user.UserId,
                    prop => prop.SetPrimaryKey().SetDatabaseGenerated(DatabaseGeneratedOption.Identity));
        }
    }
}
