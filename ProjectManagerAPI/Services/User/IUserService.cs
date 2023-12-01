﻿using Microsoft.AspNetCore.Identity;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;
using System;
using System.Threading.Tasks;

namespace ProjectManagerAPI.Services
{
	public interface IUserService
	{
		Task<UserDto> GetUserByIdAsync(Guid userId);
		Task<UserDto> GetUserByEmailAsync(string email);
		Task<IdentityResult> CreateUserAsync(CreateUserDto createUserDto);
		Task UpdateUserAsync(Guid userId, UpdateUserDto updateUserDto);
		Task<User> ValidateUserAsync(string email, string password);
	}

}
