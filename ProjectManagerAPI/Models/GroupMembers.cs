using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Models
{
	public class GroupMembers
	{
		[Key]
		public Guid uuid { get; set; }
		public Guid groupUuid { get; set; }
		public Group group { get; set; }
		public Guid userUuid { get; set; }
		public User user { get; set; }
	}
}
