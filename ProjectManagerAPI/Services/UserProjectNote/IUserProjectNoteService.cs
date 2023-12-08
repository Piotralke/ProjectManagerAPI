using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

public interface IUserProjectNoteService
{
	UserProjectNote GetProjectNote(Guid projectId, Guid userId);
	void AddProjectNote(UserProjectNoteDto projectNote);
	void DeleteProjectNote(Guid projectId, Guid userId);
	void UpdateProjectNote(UserProjectNoteDto projectNote);
	bool SaveChanges();
}