
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;
using ProjectManagerAPI.Services;

public class MessageService : IMessageService
{
	private readonly IMessageRepository _messageRepository;
	private readonly IMessageAttachmentRepository _messageAttachmentRepository;
	private readonly IUserService _userService;

	public MessageService(IMessageRepository messageRepository, IMessageAttachmentRepository messageAttachmentRepository, IUserService userService)
	{
		_messageAttachmentRepository = messageAttachmentRepository;
		_messageRepository = messageRepository;
		_userService = userService;
	}
	public async Task<IEnumerable<MessageDto>> GetProjectMessagesAsync(Guid projectUuid)	//pobierać ifnormacje o uzytkowniku wysylajacym
	{
		List<MessageDto> result = new List<MessageDto>();
		var messages = _messageRepository.GetProjectMessages(projectUuid);
		if(messages == null)
		{
			return Enumerable.Empty<MessageDto>();
		}
		foreach(var message in messages)
		{
			var sender = await _userService.GetUserByIdAsync(message.senderUuid);
            MessageDto messageDto = new MessageDto
			{
				uuid = message.uuid,
				content = message.content,
				hasAttachment = message.hasAttachment,
				senderUuid = message.senderUuid,
				projectUuid = message.projectUuid,
				createdAt = message.createdAt,
				sender = sender,
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
    public Message SendMessage(CreateMessageDto message)
	{
		Message messageToSend = new Message(message);
		_messageRepository.AddMessage(messageToSend);
		return messageToSend;

	}
	public bool SaveChanges()
	{
		return _messageRepository.SaveChanges();
	}
}