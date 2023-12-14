using ProjectManagerAPI.Models;

public interface IUserEventsRepository
{
	IEnumerable<UserEvents> GetUserEvents(Guid userId);
	IEnumerable<UserEvents> GetEventUsers(Guid eventId);
	UserEvents GetEventByUuid(Guid uuid);
	void AddUserEvents(UserEvents userEvents);
	void UpdateUserEvents(UserEvents userEvents);
	void DeleteUserEvents(Guid userId);
	bool SaveChanges();
}