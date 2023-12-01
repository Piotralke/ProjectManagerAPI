using ProjectManagerAPI.Models;
using System;
using System.Threading.Tasks;

namespace ProjectManagerAPI.Repositories
{
	public interface IUserRepository
	{
		Task<User> GetUserByIdAsync(Guid userId);
		Task<User> GetUserByEmailAsync(string email);
		Task CreateUserAsync(User user, string password);
		Task UpdateUserAsync(User user);
	}
}
