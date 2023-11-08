using ProjectManagerAPI.Models;

public interface IProjectRepository
{
	IEnumerable<Project> GetAllProjects();
	Project GetProjectById(Guid projectId);
	void AddProject(Project project);
	void UpdateProject(Project project);
	void DeleteProject(Guid projectId);
	bool SaveChanges();
	
}
