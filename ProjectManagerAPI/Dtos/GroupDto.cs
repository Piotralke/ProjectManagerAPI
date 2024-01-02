using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Dtos
{
	public class CreateGroupDto
	{
		public string name { get; set; }
		public List<Guid> members { get; set; }
	}
}
