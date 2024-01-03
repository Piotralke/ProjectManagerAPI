using ProjectManagerAPI.Models;

public interface ISubjectService
{
	IEnumerable<Subject> GetAllSubjects();
	Subject GetSubjectById(Guid subjectId);
	IEnumerable<Subject> GetTeacherSubjects(Guid teacherId);
	IEnumerable<Subject> GetGroupSubjects(Guid groupId);
	IEnumerable<Subject> GetStudentSubjects(Guid studentId);
	void AddSubject(Subject subject);
	void UpdateSubject(Subject subject);
	void DeleteSubject(Guid subjectId);
	bool SaveChanges();
	void AddSubjectGroup(GroupSubjects subjectGroup);
}