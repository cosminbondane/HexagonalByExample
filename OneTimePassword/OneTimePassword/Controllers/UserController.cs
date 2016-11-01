using OneTimePassword.Business;
using OneTimePassword.Extensions;
using OneTimePassword.Models;
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

        //[HttpGet]
        //public string CreatePassword(string username)
        //{
        //    try
        //    {
        //        var result = _userBusiness.CreatePassword(username);
        //        return result.Password;
        //    }
        //    catch (Exception ex) { }

        //    return string.Empty;
        //}

        [HttpGet]
        public UserInfo GetUserInfo(string username)
        {
            try
            {
               return _userBusiness
                    .GetInfo(username)
                    .ToUserInfo();
            }
            catch (Exception ex) { }

            return null;
        }
    }
}