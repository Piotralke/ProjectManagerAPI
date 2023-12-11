using ProjectManagerAPI.Models;

public class UserEventService : IUserEventService
{
	private readonly IUserEventsRepository _userEventsRepository;
	public UserEventService(IUserEventsRepository userEventsRepository)
	{
		_userEventsRepository = userEventsRepository;
	}

	public List<UserEvents> GetUserEvents(Guid userId)
	{
		var userEvents =  _userEventsRepository.GetUserEvents(userId).ToList();
		return userEvents;
	}
	public UserEvents GetUserEventByUuid(Guid uuid)
	{
		var userEvent = _userEventsRepository.GetEventByUuid(uuid);
		return userEvent;
	}
	public void AddUserEvents(UserEvents userEvents)
	{
		_userEventsRepository.AddUserEvents(userEvents);
	}
	public void UpdateUserEvents(UserEvents userEvents)
	{
		_userEventsRepository.UpdateUserEvents(userEvents);
	}
	public void DeleteUserEvents(Guid eventId)
	{
		_userEventsRepository.DeleteUserEvents(eventId);
	}
	public bool SaveChanges()
	{
		return _userEventsRepository.SaveChanges();
	}
}