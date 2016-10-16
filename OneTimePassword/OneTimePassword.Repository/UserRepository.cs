using OneTimePassword.Business.Dependencies;
using OneTimePassword.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePassword.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public User GetByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
