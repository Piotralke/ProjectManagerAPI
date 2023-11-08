using ProjectManagerAPI.Models;

public interface IMessageAttachmentRepository
{
	IEnumerable<MessageAttachment> GetMessageAttachments(Guid messageUuid);

}