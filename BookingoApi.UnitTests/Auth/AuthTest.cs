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
        private Mock<IUserAdmin> _userAdminRepoMock;

        private AuthContract _authContract;

        [SetUp]
        public void SetUp()
        {
            _mockingKernel = new MoqMockingKernel();
            ModuleManager.Kernel = _mockingKernel;

            _authRepoMock = new Mock<IAuth>();
            ModuleManager.Kernel.Bind<IAuth>().ToMethod(x => _authRepoMock.Object);

            _userAdminRepoMock = new Mock<IUserAdmin>();
            ModuleManager.Kernel.Bind<IUserAdmin>().ToMethod(x => _userAdminRepoMock.Object);

            _authContract = new AuthContract();
        }

        [Test]
        public void RenewCustomToken()
        {
            // Arrange
            UserModel user = new UserModel
            {
                Uid = "my-user-uid",
                DisplayName = "Juan Perez",
                Email = "44c9adf57dd44e21887f-c970fbfa584e",
                Disabled = true,
                EmailVerified = false,
                PhoneNumber = "+573005609090",
                PhotoUrl = null,
                RoleId = 1,
                Role = new RoleModel
                {
                    Name = "Machine",
                    Id = 1,
                }
            };
            string token = "my-new-token";
            Dictionary<string, object> clains = new Dictionary<string, object>();
            clains.Add("role", user.Role.Name);
            clains.Add("roleId", user.RoleId);
            _userAdminRepoMock.Setup(x => x.GetUserByUid(user.Uid)).Returns(user);
            _authRepoMock.Setup(x => x.RenewCustomAuthToken(user.Uid, clains)).Returns(token);

            // Action
            string newToken = _authContract.RenewAuthToken(user.Uid);

            // Assert
            Assert.AreSame(newToken, token);
        }
    }
}
