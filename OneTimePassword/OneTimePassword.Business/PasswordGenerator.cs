using OneTimePassword.Business.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePassword.Business
{
    public class PasswordGenerator
    {
        public string GenerateUnique()
        {
            Guid part1 = Guid.NewGuid();
            Guid part2 = Guid.NewGuid();

            return part1.ToString("N") + part2.ToString("N");
        }
    }
}
