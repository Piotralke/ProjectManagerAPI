using ProjectManagerAPI.Models;

public interface IProjectRepository
{
	IEnumerable<Project> GetAllProjects();
	Project GetProjectById(Guid projectId);
	Project GetUserProjectForSubject(Guid userId, Guid SubjectId);
	IEnumerable<Project> GetGroupSubjectProjects(Guid groupId, Guid subjectId);
	void RateProject(ProjectGrade projectGrade);
	void AddProject(Project project);
	void UpdateProject(Project project);
	void DeleteProject(Guid projectId);
	ProjectGrade GetProjectGrade(Guid projectId);
	bool SaveChanges();
	
}
