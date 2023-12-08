using ProjectManagerAPI.Models;

public interface IProjectMembersRepository
{
	void AddProjectMember(ProjectMembers projectMember);
	void DeleteProjectMember(Guid projectUuid, Guid memberUuid);
	IEnumerable<ProjectMembers> GetProjectMembers(Guid projectId);
	IEnumerable<ProjectMembers> GetProjectsForUser(Guid userId);
	bool SaveChanges();
}