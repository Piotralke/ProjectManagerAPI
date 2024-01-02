
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

public interface IGroupService
{
	IEnumerable<Group> GetUserGroups(Guid userId);
	Group GetGroup(Guid groupId);
	IEnumerable<Group> GetAllGroups();
	IEnumerable<Group> GetTeacherGroups(Guid teacherId);
	IEnumerable<Group> GetGroupsBySubject(Guid subjectId);
	void AddGroup(CreateGroupDto group);
	bool SaveChanges();
}
