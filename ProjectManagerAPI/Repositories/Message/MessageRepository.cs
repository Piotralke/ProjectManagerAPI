using ProjectManagerAPI.Data;
using ProjectManagerAPI.Models;

public class MessageRepository : IMessageRepository
{
	private readonly ApplicationDbContext _context;

	public MessageRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public IEnumerable<Message> GetProjectMessages(Guid projectId)
	{
		return _context.Messages.Where(m=>m.projectUuid==projectId).ToList();
	}

	public void AddMessage(Message message)
	{
		_context.Messages.Add(message);
	}
	public void EditMessage(Message message)
	{
		_context.Messages.Update(message);
	}
	public void DeleteMessage(Guid messageId)
	{
		var message = _context.Messages.FirstOrDefault(m=>m.uuid==messageId);
		if(message!=null)
		{
			_context.Messages.Remove(message);
		}
	}
	public bool SaveChanges()
	{
		return _context.SaveChanges() > 0;
	}

}