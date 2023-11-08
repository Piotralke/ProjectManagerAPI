namespace ProjectManagerAPI.Dtos
{
	public class GanntTaskDto
	{
		public Guid uuid { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public uint howLong { get; set; }
		public DateTime startDate { get; set; }
		public Guid projectUuid { get; set; }
	}
}
