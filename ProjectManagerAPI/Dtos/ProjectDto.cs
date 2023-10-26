using ProjectManagerAPI.Data.Enum;
using ProjectManagerAPI.Models;

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
		public bool isPrivate { get; set; }

		public ProjectDto(Project project)
		{
			uuid = project.uuid;
			title = project.title;
			description = project.description;
			status = project.status;
			createdAt = project.createdAt;
			gitLink = project.gitLink;
			isPrivate = project.isPrivate;
		}
	}
	public class CreateProjectDto
	{
		public string title { get; set; }
		public string description { get; set; }
		public string? gitLink { get; set; }
		public Guid ownerUuid { get; set; }
		public List<Guid> members { get; set; }
		public bool isPrivate { get; set; }
	}
	public class UpdateProjectDto
	{
		public string? title { get; set; }
		public string? description { get; set; }
		public string? gitLink { get; set; }
		public bool? isPrivate { get; set; }
	}
	public class CreateProjectMemberDto
	{
		public Guid projectUuid { get; set; }
		public Guid memberUuid { get; set; }
	}
}
