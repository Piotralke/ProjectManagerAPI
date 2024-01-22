using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectManagerAPI.Services.Auth;
using ProjectManagerAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ProjectManagerAPI.Dtos;

namespace ProjectManagerAPITests
{
	[TestFixture]
	public class UserControllerTests
	{
		private Mock<IUserService> _mockUserService;
		private Mock<IAuthService> _mockAuthService;
		private Mock<SignInManager<User>> _mockSignInManager;
		private Mock<UserManager<User>> _mockUserManager;
		private UserController _userController;

		[SetUp]
		public void Setup()
		{
			var userStoreMock = new Mock<IUserStore<User>>();
			_mockUserManager = new Mock<UserManager<User>>(userStoreMock.Object, null, null, null, null, null, null, null, null);
			_mockSignInManager = new Mock<SignInManager<User>>(_mockUserManager.Object, new Mock<IHttpContextAccessor>().Object, new Mock<IUserClaimsPrincipalFactory<User>>().Object, null, null, null, null);
			_mockUserService = new Mock<IUserService>();
			_mockAuthService = new Mock<IAuthService>();
			_userController = new UserController(_mockUserService.Object, _mockAuthService.Object, _mockSignInManager.Object, _mockUserManager.Object);
		}

		[Test]
		public async Task Login_ValidCredentials_ReturnsToken()
		{
			var loginDto = new LoginDto { Email = "username@gmail.com", Password = "Qwerty!23" };
			var user = new User {  };
			
			_mockUserService.Setup(service => service.ValidateUserAsync(loginDto.Email, loginDto.Password))
				.ReturnsAsync(user);

			var result = await _userController.Login(loginDto);

			Assert.IsNotNull(result);
		}
		[Test]
		public async Task Login_InvalidCredentials_ReturnsUnauthorized()
		{
			var loginDto = new LoginDto { Email = "zlymail@blad.com", Password = "zleHaslo" };

			_mockUserService.Setup(service => service.ValidateUserAsync(loginDto.Email, loginDto.Password))
				.ReturnsAsync((User)null); 


			var result = await _userController.Login(loginDto);

			Assert.IsNotNull(result);
			var unauthorizedResult = result as UnauthorizedObjectResult;
			Assert.IsNotNull(unauthorizedResult);
			Assert.AreEqual("Invalid email or password " + loginDto.Email + ";" + loginDto.Password, unauthorizedResult.Value);
		}
	}
}
