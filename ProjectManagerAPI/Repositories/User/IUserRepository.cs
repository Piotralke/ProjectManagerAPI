﻿using Microsoft.AspNetCore.Identity;
using ProjectManagerAPI.Data.Enum;
using ProjectManagerAPI.Models;


namespace ProjectManagerAPI.Repositories
{
	public interface IUserRepository
	{
		Task<User> GetUserByIdAsync(Guid userId);
		Task<User> GetUserByEmailAsync(string email);
		Task<IdentityResult> CreateUserAsync(User user, string password);
		Task UpdateUserAsync(User user);
		Task<IEnumerable<User>> SearchUsersAsync(string query);
		Task<List<string>> GetUserRole(User user);
		Task<IEnumerable<User>> GetUsersByRoleAsync(Role role);
	}
}
