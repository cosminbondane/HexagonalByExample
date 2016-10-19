using OneTimePassword.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OneTimePassword.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly UserBusiness _userBusiness;

        public UserController(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet]
        public bool Get()
        {
            return true;
        }
    }
}