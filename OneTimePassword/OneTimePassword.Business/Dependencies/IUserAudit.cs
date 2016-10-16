using OneTimePassword.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePassword.Business.Dependencies
{
    public interface IUserAudit
    {
        void LoginFailed(string username, LoginFailedReason reason);
    }
}
