using ProjectManagerAPI.Models;

public interface IGroupRepository
{
	IEnumerable<Group> GetUserGroups(Guid userId);
	Group GetGroup(Guid groupId);
	IEnumerable<Group> GetAllGroups();
	IEnumerable<Group> GetTeacherGroups(Guid teacherId);
	IEnumerable<Group> GetGroupsBySubject(Guid subjectId);
	void AddGroup(Group group);
	bool SaveChanges();
	void AddGroupMembers(Guid groupId,List<Guid> memberIds);
}