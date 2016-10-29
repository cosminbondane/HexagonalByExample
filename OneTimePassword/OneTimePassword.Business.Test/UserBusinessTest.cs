using Moq;
using OneTimePassword.Business.Dependencies;
using OneTimePassword.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OneTimePassword.Business.Test
{
    public class UserBusinessTest
    {
        Mock<IUserService> mockUserRepository = new Mock<IUserService>();
        Mock<IUserAudit> mockAudit = new Mock<IUserAudit>();

        public UserBusinessTest()
        {
            mockUserRepository
                .Setup(f => f.GetByUsername("myusername"))
                .Returns(() =>
                {
                    return new User
                    {
                        Username = "myusername",
                        Password = "mypass",
                        PasswordExpiration = DateTime.UtcNow.AddSeconds(30)
                    };
                });

            mockUserRepository
               .Setup(f => f.GetByUsername("myusername3"))
               .Returns(() =>
               {
                   return new User
                   {
                       Username = "myusername3",
                       Password = "mypass",
                       PasswordExpiration = DateTime.UtcNow.AddSeconds(-30)
                   };
               });
        }

        [Fact]
        public void User_Should_Exist_Test()
        {
            UserBusiness business = new UserBusiness(
                mockUserRepository.Object,
                mockAudit.Object);

            var user = business.FindUser("myusername");

            Assert.NotNull(user);
            Assert.Equal("myusername", user.Username);
        }

        [Fact]
        public void User_Should_Not_Exist_Test()
        {
            UserBusiness business = new UserBusiness(
                mockUserRepository.Object,
                mockAudit.Object);

            var user = business.FindUser("myusername2");

            Assert.Null(user);
        }

        [Fact]
        public void Should_Set_Password_Test()
        {
            UserBusiness business = new UserBusiness(
                mockUserRepository.Object,
                mockAudit.Object);

            User user = business.CreatePassword("myusername");

            Assert.NotEmpty(user.Password);
            Assert.Equal("myusername", user.Username);
            Assert.InRange((user.PasswordExpiration - DateTime.UtcNow).TotalSeconds, 0, 30);
        }

        [Fact]
        public void Should_Login_WithSuccess_Test()
        {
            UserBusiness business = new UserBusiness(
                mockUserRepository.Object,
                mockAudit.Object);

            bool success = business.Login("myusername", "mypass");

            Assert.Equal(true, success);
        }

        [Fact]
        public void Should_LoginWrongPassword_WithError_Test()
        {
            UserBusiness business = new UserBusiness(
                mockUserRepository.Object,
                mockAudit.Object);

            bool success = business.Login("myusername", "mypass2");

            Assert.Equal(false, success);
        }

        [Fact]
        public void Should_LoginPasswordExpired_WithError_Test()
        {
            UserBusiness business = new UserBusiness(
                mockUserRepository.Object,
                mockAudit.Object);

            bool success = business.Login("myusername3", "mypass");

            Assert.Equal(false, success);
        }

        [Fact]
        public void Should_Get_User_Info()
        {

        }
    }
}
