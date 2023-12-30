﻿using ProjectManagerAPI.Models;

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

	public void AddGroup(Group group)
	{
		_groupRepository.AddGroup(group);
	}

	public bool SaveChanges()
	{
		return _groupRepository.SaveChanges();
	}

	IEnumerable<Group> IGroupService.GetUserGroups(Guid userId)
	{
		throw new NotImplementedException();
	}

	Group IGroupService.GetGroup(Guid groupId)
	{
		throw new NotImplementedException();
	}

	public void AddGroup(Group group)
	{
		throw new NotImplementedException();
	}
}