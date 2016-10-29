using OneTimePassword.Business.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OneTimePassword.Business.Test
{
    public class PasswordGeneratorTest
    {
        [Fact]
        public void Should_Generate_Unique_Test()
        {
            PasswordGenerator generator = new PasswordGenerator();

            var pass1 = generator.GenerateUnique();
            var pass2 = generator.GenerateUnique();

            Assert.NotEqual(pass1, pass2);
        }
    }
}
