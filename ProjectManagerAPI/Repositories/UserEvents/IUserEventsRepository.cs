using ProjectManagerAPI.Models;

public interface IUserEventsRepository
{
	IEnumerable<UserEvents> GetUserEvents(Guid userId);
	UserEvents GetEventByUuid(Guid uuid);
	void AddUserEvents(UserEvents userEvents);
	void UpdateUserEvents(UserEvents userEvents);
	void DeleteUserEvents(Guid userId);
	bool SaveChanges();
}