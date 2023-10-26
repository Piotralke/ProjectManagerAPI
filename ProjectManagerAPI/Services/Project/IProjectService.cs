using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;


public interface IProjectService
{
	IEnumerable<ProjectDto> GetAllProjects();
	ProjectDto GetProjectById(Guid projectId);
	ProjectDto AddProject(CreateProjectDto project);
	void UpdateProject(UpdateProjectDto project);
	void DeleteProject(Guid projectId);
	bool SaveChanges();
	void AddProjectMember(ProjectMembers member);
	void RemoveProjectMember(Guid projectId, Guid memberId);
}