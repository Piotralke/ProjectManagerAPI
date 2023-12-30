using Microsoft.AspNetCore.Identity;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;
using ProjectManagerAPI.Repositories;
using ProjectManagerAPI.Services;
using System;
using System.Threading.Tasks;

public class UserService : IUserService
{
	private readonly IUserRepository _userRepository;
	private readonly UserManager<User> _userManager;
	private readonly SignInManager<User> _signInManager;

	public UserService(IUserRepository userRepository, UserManager<User> userManager, SignInManager<User> signInManager)
	{
		_userRepository = userRepository;
		_userManager = userManager;
		_signInManager = signInManager;
	}

	public async Task<UserDto> GetUserByIdAsync(Guid userId)
	{
		var user = await _userRepository.GetUserByIdAsync(userId);
		var role = await _userRepository.GetUserRole(user);
		return new UserDto(user, role);
	}

	public async Task<UserDto> GetUserByEmailAsync(string email)
	{
		var user = await _userRepository.GetUserByEmailAsync(email);
		var role = await _userRepository.GetUserRole(user);
		return new UserDto(user, role);
	}

	public async Task<IdentityResult> CreateUserAsync(CreateUserDto createUserDto)
	{
		var user = new User
		{
			UserName = createUserDto.email,
			Email = createUserDto.email,
			name = createUserDto.name,
			surname = createUserDto.surname,
			createdAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)
		};

		var result = await _userManager.CreateAsync(user, createUserDto.password);

		if (result.Succeeded)
		{
			// Przypisz rolę użytkownika
			await _userManager.AddToRoleAsync(user, createUserDto.role.ToString());
		}

		return result;
	}

	public async Task UpdateUserAsync(Guid userId, UpdateUserDto updateUserDto)
	{
		var user = await _userRepository.GetUserByIdAsync(userId);

		if (user != null)
		{
			if (!string.IsNullOrEmpty(updateUserDto.name))
				user.name = updateUserDto.name;
			if (!string.IsNullOrEmpty(updateUserDto.surname))
				user.surname = updateUserDto.surname;

			if (!string.IsNullOrEmpty(updateUserDto.newPassword))
			{
				await _userManager.RemovePasswordAsync(user);
				await _userManager.AddPasswordAsync(user, updateUserDto.newPassword);
			}
			if (!string.IsNullOrEmpty(updateUserDto.ProfilePicturePath))
			{
				user.ProfilePicturePath = updateUserDto.ProfilePicturePath;
				await _userRepository.UpdateUserAsync(user);
			}

			if (updateUserDto.pinnedProjectUuid.HasValue)
				user.pinnedProjectUuid = updateUserDto.pinnedProjectUuid;

			await _userRepository.UpdateUserAsync(user);
		}
	}
	public async Task<User> ValidateUserAsync(string email, string password)
	{
		var user = await _userManager.FindByEmailAsync(email);
		
		if (user != null && await _userManager.CheckPasswordAsync(user, password))
		{
			return user;
		}
		return null;
	}
	public async Task<IEnumerable<User>> SearchUsersAsync(string query)
	{
		return await _userRepository.SearchUsersAsync(query);
	}
}
