using System;
using System.Collections.Generic;
using System.Linq;
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
		var groupMembers = _context.GroupMembers.Where(g => g.userUuid == userId).ToList();
		List<Group> result = new List<Group>();
		foreach (var groupMember in groupMembers)
		{
			var group = _context.Groups.Where(g => g.uuid == groupMember.groupUuid).FirstOrDefault();
			result.Add(group);
		}
		return result;
	}
	public IEnumerable<Group> GetAllGroups()
	{
		return _context.Groups.ToList();
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
		return _context.SaveChanges() > 0;
	}

	public IEnumerable<Group> GetTeacherGroups(Guid teacherId)
	{
		return _context.Groups
			.Where(g => g.subjects.Any(s => s.subject.teacherUuid == teacherId))
			.ToList();
	}

	public IEnumerable<Group> GetGroupsBySubject(Guid subjectId)
	{
		return _context.GroupSubjects
			.Where(gs => gs.subjectUuid == subjectId)
			.Select(gs => gs.group)
			.ToList();
	}
	public void AddGroupMembers(Guid groupId, List<Guid> memberIds)
	{
		List<GroupMembers> values = new List<GroupMembers>();
		foreach (Guid memberId in memberIds)
		{
			GroupMembers member = new GroupMembers
			{
				uuid = new Guid(),
				groupUuid = groupId,
				userUuid = memberId
			};
			values.Add(member);
		}
		_context.GroupMembers.AddRange(values);
	}
}
