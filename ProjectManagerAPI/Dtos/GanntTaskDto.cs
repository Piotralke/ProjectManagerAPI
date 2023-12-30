namespace ProjectManagerAPI.Dtos
{
	public class GanntTaskDto
	{
		public Guid id { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public DateTime start { get; set; }
		public DateTime end { get; set; }
		public Guid projectUuid { get; set; }
		public string type { get; set; }
		public List<Guid>? dependencies { get; set; }
	}
	public class CreateGanntTaskDto
	{
		public string title { get; set; }
		public string description { get; set; }
		public DateTime startDate { get; set; }
		public DateTime endDate { get; set; }
		public Guid projectUuid { get; set; }
		public string type { get; set; }
		public List<Guid>? previousTasksGuids { get; set; }
	}
}
