using ProjectManagerAPI.Models;

public interface IMessageAttachmentService
{
	IEnumerable<MessageAttachment> GetMessageAttachments(Guid messageUuid);
	void AddAttachment(MessageAttachment attachment);
}