using ProjectManagerAPI.Models;

public class SubjectService : ISubjectService
{
	private readonly ISubjectRepository _subjectRepository;

	public SubjectService(ISubjectRepository subjectRepository)
	{
		_subjectRepository = subjectRepository;
	}

	public IEnumerable<Subject> GetAllSubjects()
	{
		return _subjectRepository.GetAllSubjects();
	}

	public Subject GetSubjectById(Guid subjectId)
	{
		return _subjectRepository.GetSubjectById(subjectId);
	}

	public IEnumerable<Subject> GetTeacherSubjects(Guid teacherId)
	{
		return _subjectRepository.GetTeacherSubjects(teacherId);
	}

	public IEnumerable<Subject> GetGroupSubjects(Guid groupId)
	{
		return _subjectRepository.GetGroupSubjects(groupId);
	}

	public void AddSubject(Subject subject)
	{
		_subjectRepository.AddSubject(subject);
	}

	public void UpdateSubject(Subject subject)
	{
		_subjectRepository.UpdateSubject(subject);
	}

	public void DeleteSubject(Guid subjectId)
	{
		_subjectRepository.DeleteSubject(subjectId);
	}

	public bool SaveChanges()
	{
		return _subjectRepository.SaveChanges();
	}
	public void AddSubjectGroup(GroupSubjects subjectGroup)
	{
		_subjectRepository.AddSubjectGroup(subjectGroup);
	}
}