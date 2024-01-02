using System;
using System.Collections.Generic;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

public class GroupService : IGroupService
{
	private readonly IGroupRepository _groupRepository;

	public GroupService(IGroupRepository groupRepository)
	{
		_groupRepository = groupRepository;
	}

	public IEnumerable<Group> GetUserGroups(Guid userId)
	{
		return _groupRepository.GetUserGroups(userId);
	}

	public Group GetGroup(Guid groupId)
	{
		return _groupRepository.GetGroup(groupId);
	}
	public IEnumerable<Group> GetAllGroups()
	{
		return _groupRepository.GetAllGroups();
	}
	public void AddGroup(CreateGroupDto group)
	{
		Group newGroup = new Group {
			uuid = Guid.NewGuid(),
			name = group.name,
		};
		_groupRepository.AddGroup(newGroup);
		_groupRepository.AddGroupMembers(newGroup.uuid, group.members);
	}

	public bool SaveChanges()
	{
		return _groupRepository.SaveChanges();
	}

	public IEnumerable<Group> GetTeacherGroups(Guid teacherId)
	{
		return _groupRepository.GetTeacherGroups(teacherId);
	}

	public IEnumerable<Group> GetGroupsBySubject(Guid subjectId)
	{
		return _groupRepository.GetGroupsBySubject(subjectId);
	}
}
