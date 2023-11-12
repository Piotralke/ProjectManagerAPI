namespace ProjectManagerAPI.Dtos
{
	public class GanntTaskDto
	{
		public Guid uuid { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public DateTime startDate { get; set; }
		public DateTime endDate { get; set; }
		public Guid projectUuid { get; set; }
		public List<GanntTaskDto>? previousTasks { get; set; }
	}
	public class CreateGanntTaskDto
	{
		public string title { get; set; }
		public string description { get; set; }
		public DateTime startDate { get; set; }
		public DateTime endDate { get; set; }
		public Guid projectUuid { get; set; }
		public List<Guid>? previousTasksGuids { get; set; }
	}
}
