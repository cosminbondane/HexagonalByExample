using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePassword.Business.Model
{
    public enum LoginFailedReason
    {
        UserNotFound = 1,
        IncorrectPassword = 2,
        ExpiredPassword = 3
    }
}
