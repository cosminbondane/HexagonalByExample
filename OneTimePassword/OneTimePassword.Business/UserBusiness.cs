using OneTimePassword.Business.Dependencies;
using OneTimePassword.Business.Util;
using OneTimePassword.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePassword.Business
{
    public class UserBusiness
    {
        private const int ExpirationTime = 30;

        public IUserService UserService;

        public IUserAudit Audit;

        private PasswordGenerator Password = new PasswordGenerator();

        public UserBusiness(
            IUserService UserService,
            IUserAudit Audit)
        {
            this.UserService = UserService;
            this.Audit = Audit;
        }

        public User FindUser(string username)
        {
            return UserService.GetByUsername(username);
        }

        public User CreatePassword(string username)
        {
            User user = FindUser(username);
            if (user == null)
            {
                return null;
            }

            user.Password = Password.GenerateUnique();
            user.PasswordExpiration = DateTime.UtcNow.AddSeconds(ExpirationTime);
            UserService.Update(user);

            return user;
        }

        public bool Login(string username, string password)
        {
            User user = FindUser(username);
            if (user == null)
            {
                Audit.LoginFailed(username, Model.LoginFailedReason.UserNotFound);
                return false;
            }

            if (user.Password != password)
            {
                Audit.LoginFailed(username, Model.LoginFailedReason.IncorrectPassword);
                return false;
            }

            if (user.PasswordExpiration < DateTime.UtcNow)
            {
                Audit.LoginFailed(username, Model.LoginFailedReason.ExpiredPassword);
                return false;
            }

            return true;
        }

        public User GetInfo(string username)
        {
            return UserService.GetInfoByUsername(username);
        }
    }
}
