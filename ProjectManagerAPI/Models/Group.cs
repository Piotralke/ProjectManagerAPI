using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Models
{
	public class Group
	{
		[Key]
		public Guid uuid { get; set; }
		public string name { get; set; }
		public ICollection<GroupMembers> members { get; set; }
		public ICollection<Subject> subjects { get; set; }
	}
}
