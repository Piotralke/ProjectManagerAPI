using Microsoft.EntityFrameworkCore;
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
		var subject = _context.Subjects
			.Include(s=>s.group)
			.ThenInclude(g=>g.group)
			.ThenInclude(g=>g.members)
			.ThenInclude(g=>g.user)
			.Include(s => s.proposals)
			.Include(s=>s.teacher)
			.FirstOrDefault(s => s.uuid == subjectId);
		if (subject == null)
		{
			throw new Exception("Subject not found");
		}
		return subject;
	}
	public IEnumerable<Subject> GetStudentSubjects(Guid studentId)
	{
		var groupIds = _context.GroupMembers.Where(m=>m.userUuid == studentId).ToList();
		List<Subject> subjects = new List<Subject>();
		foreach (var group in groupIds)
		{
			var result = GetGroupSubjects(group.groupUuid);
			subjects.AddRange(result);
		}
		return subjects.Distinct().ToList();
	}
	//public GroupSubjects GetGroupSubjectForUsersSubject(List<Guid> usersIds,Guid subjectId)
	//{
		
	//}
	public IEnumerable<Subject> GetTeacherSubjects(Guid teacherId)
	{
		return _context.Subjects
			.Where(s => s.teacherUuid == teacherId)
			.Include(s=>s.group)
			.ThenInclude(g=>g.group)
			.Include(s=>s.proposals)
			.ToList();
	}
	public IEnumerable<Subject> GetGroupSubjects(Guid groupId)
	{
		var subjects = _context.GroupSubjects
		.Where(gs => gs.groupUuid == groupId)
		.Include(gs=>gs.subject)
		.ThenInclude(s=>s.group)
		.ThenInclude(g=>g.group)
		.Select(gs => gs.subject)	
		.ToList();

		return subjects;
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
	public void AddSubjectGroup(GroupSubjects subjectGroup)
	{
		_context.GroupSubjects.Add(subjectGroup);
	}
}