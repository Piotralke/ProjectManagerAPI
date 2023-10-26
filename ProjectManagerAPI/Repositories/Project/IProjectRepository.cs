using ProjectManagerAPI.Models;

public interface IProjectRepository
{
	IEnumerable<Project> GetAllProjects();
	Project GetProjectById(Guid projectId);
	void AddProject(Project project);
	void UpdateProject(Project project);
	void DeleteProject(Guid projectId);
	bool SaveChanges();
	void AddProjectMember(ProjectMembers projectMember);
	void DeleteProjectMember(Guid projectUuid, Guid memberUuid);
}
