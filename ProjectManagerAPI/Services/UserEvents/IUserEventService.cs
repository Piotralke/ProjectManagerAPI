using ProjectManagerAPI.Models;

public interface IUserEventService
{
	List<UserEvents> GetUserEvents(Guid userId);
	UserEvents GetUserEventByUuid(Guid uuid);
	void AddUserEvents(UserEvents userEvents);
	void UpdateUserEvents(UserEvents userEvents);
	void DeleteUserEvents(Guid eventId);
	bool SaveChanges();
}