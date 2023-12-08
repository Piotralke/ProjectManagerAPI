using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

public class UserProjectNoteService : IUserProjectNoteService
{
	private readonly IUserProjectNoteRepository _userProjectNoteRepository;

	public UserProjectNoteService(IUserProjectNoteRepository userProjectNoteRepository)
	{
		_userProjectNoteRepository = userProjectNoteRepository;
	}

	public UserProjectNote GetProjectNote(Guid projectId, Guid userId)
	{
		var note = _userProjectNoteRepository.GetProjectNote(projectId, userId);
		return note;
	}
	public void AddProjectNote(UserProjectNoteDto projectNote)
	{
		UserProjectNote newNote = new UserProjectNote()
		{
			uuid = new Guid(),
			userUuid = projectNote.userUuid,
			projectUuid = projectNote.projectUuid,
			value = projectNote.value
		};
		_userProjectNoteRepository.AddProjectNote(newNote);
	}
	public void UpdateProjectNote(UserProjectNoteDto projectNote)
	{
		var noteToUpdate = GetProjectNote(projectNote.projectUuid, projectNote.userUuid);
		if(noteToUpdate != null)
		{
			noteToUpdate.value = projectNote.value;
			_userProjectNoteRepository.UpdateProjectNote(noteToUpdate);
		}
		else
		{
			AddProjectNote(projectNote);
		}
		
	}
	public void DeleteProjectNote(Guid projectId, Guid userId)
	{
		var noteToDelete = _userProjectNoteRepository.GetProjectNote(projectId,userId);
		if (noteToDelete != null)
		{
			_userProjectNoteRepository.DeleteProjectNote(noteToDelete);
		}
	}
	public bool SaveChanges()
	{
		return _userProjectNoteRepository.SaveChanges();
	}
}