using OneTimePassword.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePassword.Business.Dependencies
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);
    }
}
