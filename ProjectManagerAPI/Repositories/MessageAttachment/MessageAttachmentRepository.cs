using ProjectManagerAPI.Data;
using ProjectManagerAPI.Models;

public class MessageAttachmentRepository : IMessageAttachmentRepository
{
	private readonly ApplicationDbContext _context;

	public MessageAttachmentRepository(ApplicationDbContext context)
	{
		_context = context;
	}	
	public IEnumerable<MessageAttachment> GetMessageAttachments(Guid messageUuid)
	{
		return _context.MessageAttachments.Where(a=>a.messageUuid == messageUuid).ToList();
	}
	public void AddAttachment (MessageAttachment attachment)
	{
		_context.MessageAttachments.Add(attachment);
	}
}