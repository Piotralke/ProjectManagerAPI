using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Models
{
	public class ProjectGrade
	{
		[Key]
		public Guid uuid { get; set; }
		public string value { get; set; }
		public string? comment { get; set; }
		public Project project { get; set; }
		public Guid projectUuid { get; set; }
	}
}
