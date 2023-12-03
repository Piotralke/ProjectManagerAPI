using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ProjectManagerAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectManagerAPI.Services.Auth
{
	public class AuthService : IAuthService
	{
		private readonly IConfiguration _configuration;
		private readonly UserManager<User> _userManager;

		public AuthService(IConfiguration configuration, UserManager<User> userManager)
		{
			_configuration = configuration;
			_userManager = userManager;
		}

		public async Task<string> GenerateJwtToken(User user)
		{
			var claims = new List<Claim>
		{
			new Claim("userId", user.Id.ToString()),
			new Claim("email", user.Email),
		};

			var roles = await _userManager.GetRolesAsync(user);
			foreach (var role in roles)
			{
				claims.Add(new Claim("role", role));
			}

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenSecret"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				"http://localhost:5048",
				"http://localhost:5173",
				claims,
				expires: DateTime.Now.AddMinutes(Convert.ToDouble(60)),
				signingCredentials: creds
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}

}
