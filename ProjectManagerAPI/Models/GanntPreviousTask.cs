using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Models
{
	public class GanntPreviousTask
	{
		[Key]
		public Guid uuid { get; set; }
		public GanntTasks task { get; set; }
		public Guid taskId { get; set; }
		public GanntTasks previousTask { get; set; }
		public Guid previousTaskId { get; set; }
	}
}
