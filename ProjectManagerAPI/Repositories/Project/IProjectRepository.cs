using ProjectManagerAPI.Models;

public interface IProjectRepository
{
	IEnumerable<Project> GetAllProjects();
	Project GetProjectById(Guid projectId);
	IEnumerable<Project> GetGroupSubjectProjects(Guid groupId, Guid subjectId);
	void AddProject(Project project);
	void UpdateProject(Project project);
	void DeleteProject(Guid projectId);
	bool SaveChanges();
	
}
