using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Models
{
	public class GroupSubjects
	{
		[Key]
		public Guid uuid { get; set; }
		public Guid groupUuid { get; set; }
		public Group group { get; set; }
		public Guid subjectUuid { get; set; }
		public Subject subject { get; set; }
	}
}
