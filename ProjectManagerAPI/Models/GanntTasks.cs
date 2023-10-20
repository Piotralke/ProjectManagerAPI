using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Models
{
	public class GanntTasks
	{
		[Key]
		public Guid uuid { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public uint howLong { get; set; }
		public DateTime startDate { get; set; }
		public Project project { get; set; }
		public Guid projectUuid { get; set; }
	}
}
