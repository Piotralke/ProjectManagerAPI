using ProjectManagerAPI.Models;

public class MessageAttachmentService : IMessageAttachmentService
{
	private readonly IMessageAttachmentRepository _messageAttachmentRepository;

	public MessageAttachmentService(IMessageAttachmentRepository messageAttachmentRepository)
	{
		_messageAttachmentRepository = messageAttachmentRepository;
	}
	public IEnumerable<MessageAttachment> GetMessageAttachments(Guid messageUuid)
	{
		return _messageAttachmentRepository.GetMessageAttachments(messageUuid);
	}
	public void AddAttachment(MessageAttachment attachment)
	{
		_messageAttachmentRepository.AddAttachment(attachment);
	}
}