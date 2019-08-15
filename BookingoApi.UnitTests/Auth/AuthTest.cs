using BoxAgileDev;
using Moq;
using Ninject.MockingKernel.Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingoApi.Modules.AppSettings;
using BookingoApi.Modules.Auth;
using BookingoApi.Modules.UserAdmin;

namespace BookingoApi.UnitTests.Auth
{
    [TestFixture]
    public class AuthTest
    {
        private MoqMockingKernel _mockingKernel;
        private Mock<IAuth> _authRepoMock;

        private AuthContract _authContract;

        [SetUp]
        public void SetUp()
        {
            _mockingKernel = new MoqMockingKernel();
            ModuleManager.Kernel = _mockingKernel;
            _authRepoMock = new Mock<IAuth>();

            _authContract = new AuthContract();
        }

        [Test]
        public void UpdateAuthUserInfo()
        {
            // Arrange
            UserModel user = new UserModel
            {
                DisplayName = "Juan Perez",
                Email = "44c9adf57dd44e21887f-c970fbfa584e",
                Disabled = true,
                EmailVerified = false,
                PhoneNumber = "+573005609090",
                PhotoUrl = null
            };
            _authRepoMock.Setup(x => x.UpdateUserAuth(user)).Returns(user);

            // Action
            Result result = _authContract.UpdateAuthUserInfo(user);

            // Assert
            Assert.IsTrue(result.FlowControl == FlowOptions.Success);
        }
    }
}
