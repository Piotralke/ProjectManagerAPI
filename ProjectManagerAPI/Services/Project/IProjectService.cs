using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;


public interface IProjectService
{
	IEnumerable<ProjectDto> GetAllProjects();
	IEnumerable<ProjectDto> GetUserProjects(Guid userUuid);
	IEnumerable<ProjectDto> GetGroupSubjectProjects(Guid groupId, Guid subjectId);
	ProjectDto GetUserProjectForSubject(Guid userId, Guid SubjectId);
	ProjectDto GetProjectById(Guid projectId);
	ProjectDto AddProject(CreateProjectDto project);
	void UpdateProject(UpdateProjectDto project);
	void DeleteProject(Guid projectId);
	bool SaveChanges();
	void AddProjectMember(ProjectMembers member);
	void RemoveProjectMember(Guid projectId, Guid memberId);
    Task<IEnumerable<UserDto>> GetProjectMembers(Guid projectId);
	void RateProject(ProjectGrade projectGrade);
	ProjectGrade GetProjectGrade(Guid projectId);
}