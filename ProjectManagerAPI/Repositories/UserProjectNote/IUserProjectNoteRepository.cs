using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

public interface IUserProjectNoteRepository
{
	UserProjectNote GetProjectNote(Guid projectId, Guid userId);
	void AddProjectNote(UserProjectNote projectNote);
	void DeleteProjectNote(UserProjectNote projectNote);
	void UpdateProjectNote(UserProjectNote projectNote);
	bool SaveChanges();
}