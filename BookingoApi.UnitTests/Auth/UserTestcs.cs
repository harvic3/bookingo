using BookingoApi.Modules.AppSettings;
using BookingoApi.Modules.Auth;
using BookingoApi.Modules.UserAdmin;
using BoxAgileDev;
using Moq;
using Ninject.MockingKernel.Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingoApi.UnitTests.Auth
{
    [TestFixture]
    public class UserTestcs
    {
        private MoqMockingKernel _mockingKernel;
        private Mock<IUserAdmin> _userAdminRepoMock;
        private Mock<IAuth> _authRepoMock;

        private UserAdminContract _userAdminContract;
        
        [SetUp]
        public void SetUp()
        {
            _mockingKernel = new MoqMockingKernel();
            ModuleManager.Kernel = _mockingKernel;

            _userAdminRepoMock = new Mock<IUserAdmin>();
            ModuleManager.Kernel.Bind<IUserAdmin>().ToMethod(x => _userAdminRepoMock.Object);

            _authRepoMock = new Mock<IAuth>();
            ModuleManager.Kernel.Bind<IAuth>().ToMethod(x => _authRepoMock.Object);

            _userAdminContract = new UserAdminContract();
        }

        [Test]
        public void UpdateAuthUserInfo()
        {
            // Arrange           
            UserModel updatedUser = new UserModel
            {
                Uid = "My-user-uid",
                DisplayName = "Juan Perez",
                Email = "44c9adf57dd44e21887f-c970fbfa584e",
                Disabled = true,
                EmailVerified = false,
                PhoneNumber = "+573005609090",
                PhotoUrl = null,
                RoleId = 1
            };
            _userAdminRepoMock.Setup(x => x.UpdateUser(updatedUser)).Returns(updatedUser);
            _authRepoMock.Setup(x => x.UpdateUserAuth(updatedUser)).Returns(updatedUser);

            // Action
            Result result = _userAdminContract.UpdateUser(updatedUser);

            // Assert
            Assert.IsTrue(result.FlowControl == FlowOptions.Success);
        }
    }
}
