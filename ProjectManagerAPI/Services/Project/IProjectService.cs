using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;


public interface IProjectService
{
	IEnumerable<ProjectDto> GetAllProjects();
	ProjectDto GetProjectById(Guid projectId);
	void AddProject(CreateProjectDto project);
	void UpdateProject(Project project);
	void DeleteProject(Guid projectId);
	bool SaveChanges();
}