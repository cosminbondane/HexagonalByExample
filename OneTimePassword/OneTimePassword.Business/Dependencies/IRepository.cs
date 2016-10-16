using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePassword.Business.Dependencies
{
    public interface IRepository<T> where T : new()
    {
        T Get(string key);

        void Update(T entity);
    }
}
