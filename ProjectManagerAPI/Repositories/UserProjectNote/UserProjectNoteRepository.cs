using ProjectManagerAPI.Data;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

public class UserProjectNoteRepository : IUserProjectNoteRepository
{
	private readonly ApplicationDbContext _context;

	public UserProjectNoteRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public UserProjectNote GetProjectNote(Guid projectId, Guid userId)
	{
		var note = _context.ProjectNotes.FirstOrDefault(n => n.projectUuid == projectId && n.userUuid == userId);
		return note;
	}
	public void AddProjectNote(UserProjectNote projectNote)
	{
		//UserProjectNote newNote = new UserProjectNote()
		//{
		//	uuid = new Guid(),
		//	userUuid = projectNote.userUuid,
		//	projectUuid = projectNote.projectUuid,
		//	value = projectNote.value
		//};
		_context.ProjectNotes.Add(projectNote);
	}
	public void UpdateProjectNote(UserProjectNote projectNote)
	{
		//var noteToUpdate = GetProjectNote(projectNote.projectUuid, projectNote.userUuid);
		//noteToUpdate.value = projectNote.value;
		_context.ProjectNotes.Update(projectNote);
	}
	public void DeleteProjectNote(UserProjectNote projectNote)
	{
		if (projectNote != null)
		{
			_context.ProjectNotes.Remove(projectNote);
		}
	}
	public bool SaveChanges()
	{
		return _context.SaveChanges()>0;
	}
}