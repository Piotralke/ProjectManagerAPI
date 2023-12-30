using Microsoft.AspNetCore.Http.HttpResults;
using ProjectManagerAPI.Data;
using ProjectManagerAPI.Models;

public class GroupRepository : IGroupRepository
{
	private readonly ApplicationDbContext _context;
	public GroupRepository(ApplicationDbContext context)
	{
		_context = context;
	}
	public IEnumerable<Group> GetUserGroups(Guid userId)
	{
		var groupMembers = _context.GroupMembers.Where(g=>g.userUuid == userId).ToList();
		List<Group> result = new List<Group>();
		foreach (var groupMember in groupMembers)
		{
			var group = _context.Groups.Where(g=>g.uuid== groupMember.groupUuid).FirstOrDefault();
			result.Add(group);
		}
		return result;
	}
	public Group GetGroup(Guid groupId)
	{
		return _context.Groups.Where(g => g.uuid == groupId).FirstOrDefault();

	}
	public void AddGroup(Group group)
	{
		_context.Groups.Add(group);
	}
	public bool SaveChanges()
	{
		return _context.SaveChanges()>0;
	}
}