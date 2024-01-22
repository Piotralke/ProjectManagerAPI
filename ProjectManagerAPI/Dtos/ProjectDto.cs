using ProjectManagerAPI.Data.Enum;
using ProjectManagerAPI.Models;
using System.Text.Json.Serialization;

namespace ProjectManagerAPI.Dtos
{
	public class ProjectDto
	{
		public Guid uuid { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public ProjectStatus status { get; set; }
		public DateTime createdAt { get; set; }
		public bool isPrivate { get; set; }
		public Guid ownerUuid { get; set; }
		
		public ProjectDto(Project project)
		{
			uuid = project.uuid;
			title = project.title;
			description = project.description;
			status = project.status;
			createdAt = project.createdAt;
			isPrivate = project.isPrivate;
			ownerUuid = project.ownerUuid;
		}
	}
	public class CreateProjectDto
	{
		public string title { get; set; }
		public string description { get; set; }
		public Guid ownerUuid { get; set; }
		public List<Guid> members { get; set; }
		public bool isPrivate { get; set; }
		[JsonPropertyName("groupSubjectUuid")]
		public Guid? groupSubjectUuid { get; set; }
	}
	public class UpdateProjectDto
	{
		public string? title { get; set; }
		public string? description { get; set; }
		public bool? isPrivate { get; set; }
	}
	public class CreateProjectMemberDto
	{
		public Guid projectUuid { get; set; }
		public Guid memberUuid { get; set; }
	}
	public class RateProjectDto
	{
		[JsonPropertyName("projectUuid")]
		public Guid projectUuid { get; set; }
		[JsonPropertyName("gradeValue")]
		public string gradeValue { get; set; }
		[JsonPropertyName("comment")]
		public string? comment { get; set; }
	}
}
