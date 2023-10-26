using ProjectManagerAPI.Data.Enum;
using ProjectManagerAPI.Models;

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

		public UserDto(User user) {
			uuid = user.uuid;
			name = user.name;
			surname = user.surname;
			email = user.email;
			role = user.role;
			createdAt = user.createdAt;
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
	}
}
