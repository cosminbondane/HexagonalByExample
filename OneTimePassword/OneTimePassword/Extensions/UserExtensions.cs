using OneTimePassword.Domain.Entities;
using OneTimePassword.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTimePassword.Extensions
{
    public static class UserExtensions
    {
        public static UserInfo ToUserInfo(this User user)
        {
            return new UserInfo
            {
                Role = user?.Role?.Name,
                Username = user.Username
            };
        }
    }
}