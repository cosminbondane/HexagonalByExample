using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePassword.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime PasswordExpiration { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
