using OneTimePassword.Business.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePassword.Repository
{
    public class Repository<T> : IRepository<T> where T : new()
    {
        public T Get(string key)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
