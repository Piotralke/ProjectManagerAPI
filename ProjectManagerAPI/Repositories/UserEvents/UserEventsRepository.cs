using ProjectManagerAPI.Data;
using ProjectManagerAPI.Models;

public class UserEventsRepository : IUserEventsRepository
{
	private readonly ApplicationDbContext _context;
	public UserEventsRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public IEnumerable<UserEvents> GetUserEvents(Guid userId)
	{
		return _context.UserEvents.Where(e=>e.userUuid == userId).ToList();
	}
	public UserEvents GetEventByUuid(Guid uuid)
	{
		var userEvent = _context.UserEvents.FirstOrDefault(e=>e.userUuid == uuid);
		if (userEvent == null)
		{
			throw new Exception("Event not found");
		}
		return userEvent;
	}
	public void AddUserEvents(UserEvents userEvents)
	{
		_context.UserEvents.Add(userEvents);
	}
	public void UpdateUserEvents(UserEvents userEvents)
	{
		_context.UserEvents.Update(userEvents);
	}
	public void DeleteUserEvents(Guid eventUuid)
	{
		var userEvent = GetEventByUuid(eventUuid);
		if (userEvent != null)
		{
			_context.UserEvents.Remove(userEvent);
		}
	}
	public bool SaveChanges()
	{
		return _context.SaveChanges() > 0;
	}
}