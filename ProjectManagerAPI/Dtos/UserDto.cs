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
	}
	public class CreateUserDto
	{
		public string name { get; set; }
		public string surname { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public Role role { get; set; }
	}
}
