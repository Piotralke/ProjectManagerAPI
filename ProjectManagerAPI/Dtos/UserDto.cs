﻿using ProjectManagerAPI.Data.Enum;
using ProjectManagerAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Dtos
{
	public class UserDto
	{
		public Guid uuid {  get; set; }
		public string name { get; set; }
		public string surname { get; set; }
		public string email { get; set; }
		public DateTime createdAt { get; set; }
		public Role role { get; set; }
		public string ProfilePicturePath { get; set; }
		public UserDto(User user) {
			uuid = user.Id;
			name = user.name;
			surname = user.surname;
			email = user.Email;
			createdAt = user.createdAt;
			ProfilePicturePath = user.ProfilePicturePath;
		}
	}
	public class CreateUserDto
	{
		public string name { get; set; }
		public string surname { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public Role role { get; set; }
	}
	public class UpdateUserDto
	{
		public string name { get; set; }
		public string surname { get; set;}
		public string? newPassword { get; set; }
		public string? ProfilePicturePath { get; set; }
		
	}
	public class LoginDto
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
	}

}
