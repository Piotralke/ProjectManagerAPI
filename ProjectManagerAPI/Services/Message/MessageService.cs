
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

public class MessageService : IMessageService
{
	private readonly MessageRepository _messageRepository;
	private readonly MessageAttachmentRepository _messageAttachmentRepository;

	public MessageService(MessageRepository messageRepository, MessageAttachmentRepository messageAttachmentRepository)
	{
		_messageAttachmentRepository = messageAttachmentRepository;
		_messageRepository = messageRepository;
	}
	public IEnumerable<MessageDto> GetProjectMessages(Guid projectUuid)
	{
		List<MessageDto> result = new List<MessageDto>();
		var messages = _messageRepository.GetProjectMessages(projectUuid);
		if(messages == null)
		{
			return Enumerable.Empty<MessageDto>();
		}
		foreach(var message in messages)
		{
			MessageDto messageDto = new MessageDto
			{
				uuid = message.uuid,
				content = message.content,
				hasAttachment = message.hasAttachment,
				senderUuid = message.senderUuid,
				messageAttachments = new List<MessageAttachmentDto>()
			};

			if(message.hasAttachment)
			{
				var attachments = _messageAttachmentRepository.GetMessageAttachments(message.uuid);
				foreach(var attachment in attachments)
				{
					MessageAttachmentDto attachmentDto = new MessageAttachmentDto
					{
						uuid=attachment.uuid,
						fileName = attachment.fileName,
						fileType = attachment.fileType,
						filePath = attachment.filePath,
					};
					messageDto.messageAttachments.Add(attachmentDto);
				}
			}
			result.Add(messageDto);
		}
		return result;
	}
    public void SendMessage(CreateMessageDto message)
	{
		Message messageToSend = new Message(message);
		_messageRepository.AddMessage(messageToSend);

	}
	public bool SaveChanges()
	{
		return _messageRepository.SaveChanges();
	}
}