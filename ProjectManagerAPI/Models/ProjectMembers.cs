using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Models
{
	public class ProjectMembers
	{
		[Key]
		public Guid uuid { get; set; }
		public Guid projectUuid { get; set; }
		public Project project { get; set; }
		public Guid userUuid { get; set; }
		public User user { get; set; }
	}
}
