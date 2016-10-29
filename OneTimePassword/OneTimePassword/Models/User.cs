using OneTimePassword.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTimePassword.Models
{
    public class UserInfo
    {
        public string Username { get; set; }

        public string Role { get; set; }
    }

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