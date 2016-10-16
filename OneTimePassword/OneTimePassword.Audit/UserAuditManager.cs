using OneTimePassword.Business.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneTimePassword.Business.Model;

namespace OneTimePassword.Audit
{
    public class UserAuditManager : IUserAudit
    {
        public void LoginFailed(string username, LoginFailedReason reason)
        {
            throw new NotImplementedException();
        }
    }
}
