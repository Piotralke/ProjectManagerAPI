using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Services.Auth
{
	public interface IAuthService
	{
		Task<string> GenerateJwtToken(User user);
	}
}
