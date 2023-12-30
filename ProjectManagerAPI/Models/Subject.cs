using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Models
{
	public class Subject
	{
		[Key]
		public Guid uuid { get; set; }
		public string name { get; set; }
		public Guid teacherUuid { get; set; }
		public User teacher { get; set; }
		public string requirements { get; set; }
		public Guid groupUuid { get; set; }
		public Group group { get; set; }
		public ICollection<ProjectProposal> proposals { get; set; }

	}
}
