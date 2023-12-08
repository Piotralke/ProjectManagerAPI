using Microsoft.EntityFrameworkCore;
using ProjectManagerAPI.Data;
using ProjectManagerAPI.Models;

public class ProjectMembersRepository : IProjectMembersRepository
{
	private readonly ApplicationDbContext _context;

	public ProjectMembersRepository(ApplicationDbContext context)
	{
		_context = context;
	}
	public IEnumerable<ProjectMembers> GetProjectsForUser(Guid userId)
	{
		return _context.ProjectMembers.Where(m => m.userUuid == userId).ToList();
	}
	public IEnumerable<ProjectMembers> GetProjectMembers(Guid projectUuid)
	{
		return _context.ProjectMembers.Where(m => m.projectUuid == projectUuid).ToList();
	}
	public void AddProjectMember(ProjectMembers member)
	{
		_context.ProjectMembers.Add(member);
	}
	public void DeleteProjectMember(Guid projectId, Guid memberId)
	{
		var member = _context.ProjectMembers.FirstOrDefault(m => m.projectUuid == projectId && m.userUuid == memberId);
		if (member != null)
		{
			_context.ProjectMembers.Remove(member);
		}
	}
	public bool SaveChanges()
	{
		return _context.SaveChanges() > 0;
	}
}