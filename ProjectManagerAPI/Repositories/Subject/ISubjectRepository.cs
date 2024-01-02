using ProjectManagerAPI.Models;

public interface ISubjectRepository
{
	IEnumerable<Subject> GetAllSubjects();
	IEnumerable<Subject> GetTeacherSubjects(Guid teacherId);
	IEnumerable<Subject> GetGroupSubjects(Guid groupId);
	Subject GetSubjectById(Guid subjectId);
	void AddSubject(Subject subject);
	void UpdateSubject(Subject subject);
	void DeleteSubject(Guid subjectId);
	bool SaveChanges();
	void AddSubjectGroup(GroupSubjects subjectGroup);
}