using ProjectManagerAPI.Models;

public interface IGroupRepository
{
	IEnumerable<Group> GetUserGroups(Guid userId);
	Group GetGroup(Guid groupId);
	void AddGroup(Group group);
	bool SaveChanges();
}