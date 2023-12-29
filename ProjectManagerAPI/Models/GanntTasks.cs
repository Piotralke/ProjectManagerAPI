using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Models
{
	public class GanntTasks
	{
		[Key]
		public Guid uuid { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public DateTime startDate { get; set; }
		public DateTime endDate { get; set; }
		public Project project { get; set; }
		public Guid projectUuid { get; set; }
		public string type { get; set; }
		public ICollection<GanntPreviousTask> previousTasks { get; set; }
	}
}
