﻿using OneTimePassword.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePassword.Business.Dependencies
{
    public interface IUserRepository
    {
        User GetByUsername(string username);

        bool Update(User user);
    }
}
