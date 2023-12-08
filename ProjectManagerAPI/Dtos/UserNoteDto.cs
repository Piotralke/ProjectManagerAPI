using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Dtos
{

	public class UserProjectNoteDto
	{
		public Guid userUuid { get; set; }
		public Guid projectUuid { get; set; }
		public string? value { get; set; }
	}
}
