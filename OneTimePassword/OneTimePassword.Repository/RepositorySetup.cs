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
            SetupRole();
        }

        private static void SetupUser()
        {
            OrmConfiguration.GetDefaultEntityMapping<User>()
                .SetTableName("User")
                .SetProperty(user => user.Id,
                    prop => prop.SetPrimaryKey().SetDatabaseGenerated(DatabaseGeneratedOption.Identity))
                .SetProperty(user => user.RoleId,
                    prop => prop.SetChildParentRelationship<Role>("Role"));
        }

        private static void SetupRole()
        {
            OrmConfiguration.GetDefaultEntityMapping<Role>()
                .SetTableName("Role")
                .SetProperty(role => role.Id,
                    prop => prop.SetPrimaryKey().SetDatabaseGenerated(DatabaseGeneratedOption.Identity));
        }
    }
}
