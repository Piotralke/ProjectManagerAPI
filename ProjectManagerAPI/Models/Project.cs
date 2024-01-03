using ProjectManagerAPI.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagerAPI.Models
{
	public class Project
	{
		[Key]
		public Guid uuid {  get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public ProjectStatus status { get; set; }
		public DateTime createdAt { get; set; }
		public bool isPrivate { get; set; }
		public Guid ownerUuid { get; set; }
		[ForeignKey("ownerUuid")]
		public User owner { get; set; }
		public Guid? groupSubjectUuid { get; set; }
		public GroupSubjects? groupSubject { get; set; }
		public ICollection<User> pinnedUsers { get; set; }
		public ICollection<ProjectMembers> members { get; set; }
		public ICollection<ProjectEvents> events { get; set; }
		public ICollection<GanntTasks> tasks { get; set; }

		public ICollection<Message> messages { get; set; }

		public ICollection<UserProjectNote> notes { get; set; }

	}
}
