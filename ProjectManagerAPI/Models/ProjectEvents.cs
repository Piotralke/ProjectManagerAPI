using ProjectManagerAPI.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Models
{
	public class ProjectEvents
	{
		[Key]
		public Guid uuid { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public DateTime dueTo { get; set; }
		public DateTime? startTime { get; set;}
		public DateTime? endDate { get; set; }
		public EventStatus status { get; set; }
		public EventType type { get; set; }

		public Project project { get; set; }
		public Guid projectUuid { get; set; }

		public ICollection<UserEvents> userEvents { get; set; }
	}
}
