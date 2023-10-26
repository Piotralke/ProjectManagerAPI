using ProjectManagerAPI.Data.Enum;

namespace ProjectManagerAPI.Dtos
{
	public class ProjectDto
	{
		public Guid uuid { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public ProjectStatus status { get; set; }
		public DateTime createdAt { get; set; }
		public string gitLink { get; set; }
	}
	public class CreateProjectDto
	{
		public string title { get; set; }
		public string description { get; set; }
		public string gitLink { get; set; }
		public Guid ownerUuid { get; set; }
		public List<Guid> members { get; set; }
	}
	//public class UpdateProjectDto
	//{
	//	public 
	//}
}
