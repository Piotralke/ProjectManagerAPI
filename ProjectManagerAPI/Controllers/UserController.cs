using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;
using ProjectManagerAPI.Services;
using ProjectManagerAPI.Services.Auth;
using System.Security.Claims;
using System.Threading.Tasks;

[Route("api/users")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
	private readonly IUserService _userService;
	private readonly IAuthService _authService;
	private readonly SignInManager<User> _signInManager;
	private readonly UserManager<User> _userManager;
	public UserController(IUserService userService, IAuthService authService, SignInManager<User> signInManager, UserManager<User> userManager)
	{
		_userService = userService;
		_authService = authService;
		_signInManager = signInManager;
		_userManager = userManager;
	}
	[HttpGet("current")]
	public async Task<IActionResult> GetCurrentUserInfo()
	{

		// Pobierz identyfikator użytkownika z claima
		var userIdClaim = User.FindFirstValue("userId");
		if (userIdClaim == null)
		{
			return Unauthorized("Unable to retrieve user information");
		}

		Guid userId;
		if (!Guid.TryParse(userIdClaim, out userId))
		{
			return Unauthorized("Invalid user ID format");
		}

		// Pobierz użytkownika na podstawie identyfikatora
		var user = await _userService.GetUserByIdAsync(userId);

		if (user == null)
		{
			return NotFound("User not found");
		}

		return Ok(user);
	}

	[HttpGet("{userId}")]
	public async Task<IActionResult> GetUserById(Guid userId)
	{
		var user = await _userService.GetUserByIdAsync(userId);
		return Ok(user);
	}
	[HttpGet("by-email/{email}")]
	public async Task<IActionResult> GetUserByEmail(string email)
	{
		var user = await _userService.GetUserByEmailAsync(email);
		return Ok(user);
	}
	[AllowAnonymous]
	[HttpPost("register")]
	public async Task<IActionResult> Register([FromBody] CreateUserDto createUserDto)
	{
		await _userService.CreateUserAsync(createUserDto);
		return Ok();
	}
	[AllowAnonymous]
	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
	{
		var user = await _userService.ValidateUserAsync(loginDto.Email, loginDto.Password);

		if (user == null)
		{
			return Unauthorized("Invalid email or password " + loginDto.Email + ";" + loginDto.Password );
		}

		// Użyj SignInManager do zalogowania użytkownika
		var signInResult = await _signInManager.PasswordSignInAsync(user, loginDto.Password, isPersistent: false, lockoutOnFailure: false);

		if (!signInResult.Succeeded)
		{
			return Unauthorized("Invalid email or password");
		}

		var token = await _authService.GenerateJwtToken(user);

		return Ok(new { Token = token });
	}
	[HttpPut("{userId}")]
	public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UpdateUserDto updateUserDto)
	{
		await _userService.UpdateUserAsync(userId, updateUserDto);
		return Ok();
	}
}
