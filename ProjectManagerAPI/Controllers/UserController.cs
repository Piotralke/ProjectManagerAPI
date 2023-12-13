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
	[HttpPost("{userId}/profile-picture")]
	public async Task<IActionResult> AddUserProfilePicture(Guid userId, IFormFile file)
	{
		var user = await _userService.GetUserByIdAsync(userId);

		if (user == null)
		{
			return NotFound("User not found");
		}

		// Wygeneruj unikalną nazwę pliku na podstawie uuid użytkownika
		var fileName = $"{user.uuid}_profile_pic.{Path.GetExtension(file.FileName)}";
		var filePath = Path.Combine("UserImages", fileName);

		// Zapisz przesłane zdjęcie
		using (var stream = new FileStream(filePath, FileMode.Create))
		{
			await file.CopyToAsync(stream);
		}

		// Aktualizuj ścieżkę zdjęcia profilowego w modelu użytkownika
		user.ProfilePicturePath = fileName;
		UpdateUserDto updateUser = new UpdateUserDto()
		{
			name = user.name,
			surname = user.surname,
			ProfilePicturePath = filePath
		};
		
		await _userService.UpdateUserAsync(user.uuid, updateUser);

		return Ok(new { Message = "Profile picture added successfully" });
	}
	[HttpGet("profile-picture")]
	public async Task<IActionResult> GetUserProfilePictureAsync([FromQuery] Guid? userId = null)
	{
		Guid targetUserId;

		// Sprawdź, czy został dostarczony parametr userId
		if (userId.HasValue)
		{
			targetUserId = userId.Value;
		}
		else
		{
			// Jeśli nie, pobierz identyfikator użytkownika z claima
			var userIdClaim = User.FindFirstValue("userId");
			if (userIdClaim == null || !Guid.TryParse(userIdClaim, out targetUserId))
			{
				return Unauthorized("Unable to retrieve user information");
			}
		}

		var user = await _userService.GetUserByIdAsync(targetUserId);

		if (user == null)
		{
			return NotFound("User not found");
		}

		// Jeśli ścieżka do zdjęcia profilowego jest null, użyj domyślnego zdjęcia
		var imagePath = string.IsNullOrEmpty(user.ProfilePicturePath)
			? Path.Combine("UserImages", "default.jpeg")
			: Path.Combine("UserImages", user.ProfilePicturePath);

		// Pobierz plik zdjęcia profilowego
		var imageFileStream = System.IO.File.OpenRead(imagePath);

		using (MemoryStream memoryStream = new MemoryStream())
		{
			// Skopiuj zawartość pliku do pamięci
			await imageFileStream.CopyToAsync(memoryStream);

			// Konwertuj obraz do formatu base64
			var base64Image = Convert.ToBase64String(memoryStream.ToArray());

			// Zwróć base64 jako JSON
			return Ok(base64Image);
		}
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
	[HttpGet]
	public async Task<IActionResult> SearchUser([FromQuery] string searchCondition)
	{
		var users = await _userService.SearchUsersAsync(searchCondition);
		return Ok(users);
	}
}
