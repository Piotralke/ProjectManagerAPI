using ProjectManagerAPI.Data;
using ProjectManagerAPI.Models;

public class SubjectRepository : ISubjectRepository
{
	private readonly ApplicationDbContext _context;

	public SubjectRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public IEnumerable<Subject> GetAllSubjects()
	{
		return _context.Subjects.ToList();
	}

	public Subject GetSubjectById(Guid subjectId)
	{
		var subject = _context.Subjects.FirstOrDefault(s => s.uuid == subjectId);
		if (subject == null)
		{
			throw new Exception("Subject not found");
		}
		return subject;
	}
	public IEnumerable<Subject> GetTeacherSubjects(Guid teacherId)
	{
		return _context.Subjects
			.Where(s => s.teacherUuid == teacherId)
			.ToList();
	}
	public IEnumerable<Subject> GetGroupSubjects(Guid groupId)
	{
		return _context.Subjects
			.Where(s => s.groupUuid == groupId)
			.ToList();
	}
	public void AddSubject(Subject subject)
	{
		_context.Subjects.Add(subject);
	}

	public void UpdateSubject(Subject subject)
	{
		_context.Subjects.Update(subject);
	}

	public void DeleteSubject(Guid subjectId)
	{
		var subject = _context.Subjects.FirstOrDefault(s => s.uuid == subjectId);
		if (subject != null)
		{
			_context.Subjects.Remove(subject);
		}
	}

	public bool SaveChanges()
	{
		return _context.SaveChanges() > 0;
	}
}