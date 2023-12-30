using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Dtos
{
	public class CreateSubjectDto
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public Guid TeacherUuid { get; set; }

		public string Requirements { get; set; }

		[Required]
		public Guid GroupUuid { get; set; }
	}
}
