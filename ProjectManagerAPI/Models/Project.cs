using ProjectManagerAPI.Data.Enum;
using System.ComponentModel.DataAnnotations;

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
		public string gitLink { get; set; }
		public bool isPrivate { get; set; }
		public Guid ownerUuid { get; set; }
		public User owner { get; set; }

		public ICollection<ProjectMembers> members { get; set; }
		public ICollection<ProjectEvents> events { get; set; }
		public ICollection<GanntTasks> tasks { get; set; }

		public Chat? chat { get; set; }
	}
}
