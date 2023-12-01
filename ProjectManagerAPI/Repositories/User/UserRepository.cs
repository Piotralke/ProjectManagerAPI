using Microsoft.AspNetCore.Identity;
using ProjectManagerAPI.Models;
using System;
using System.Threading.Tasks;

public interface IUserRepository
{
	Task<User> GetUserByIdAsync(Guid userId);
	Task<User> GetUserByEmailAsync(string email);
	Task<IdentityResult> CreateUserAsync(User user, string password);
	Task UpdateUserAsync(User user);
}

public class UserRepository : IUserRepository
{
	private readonly UserManager<User> _userManager;

	public UserRepository(UserManager<User> userManager)
	{
		_userManager = userManager;
	}

	public async Task<User> GetUserByIdAsync(Guid userId)
	{
		return await _userManager.FindByIdAsync(userId.ToString());
	}

	public async Task<User> GetUserByEmailAsync(string email)
	{
		return await _userManager.FindByEmailAsync(email);
	}

	public async Task<IdentityResult> CreateUserAsync(User user, string password)
	{
		var result = await _userManager.CreateAsync(user, password);

		if (result.Succeeded)
		{
			Console.WriteLine(result);
			// Tutaj możesz dodać dodatkowe akcje, jeśli rejestracja się powiodła.
		}

		return result;
	}

	public async Task UpdateUserAsync(User user)
	{
		await _userManager.UpdateAsync(user);
	}
}
