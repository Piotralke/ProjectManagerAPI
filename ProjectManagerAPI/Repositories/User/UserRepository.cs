using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectManagerAPI.Models;
using ProjectManagerAPI.Repositories;
using System;
using System.Threading.Tasks;

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
	public async Task<IEnumerable<User>> SearchUsersAsync(string query)
	{
		// Sprawdzamy, czy zapytanie jest dłuższe niż 2 znaki
		if (query.Length < 3)
		{
			return Enumerable.Empty<User>();
		}

		var lowerQuery = query.ToLower(); // lub Upper dla ignorowania wielkości liter

		// Szukamy użytkowników po adresie email i nazwie (imię + nazwisko)
		var usersByEmail = await _userManager.Users
			.Where(u => u.Email.ToLower().Contains(lowerQuery))
			.ToListAsync();

		var usersByName = await _userManager.Users
			.Where(u => (u.name + " " + u.surname).ToLower().Contains(lowerQuery))
			.ToListAsync();

		// Łączymy wyniki z obu zapytań
		var result = usersByEmail.Concat(usersByName).Distinct();

		return result;
	}
}
