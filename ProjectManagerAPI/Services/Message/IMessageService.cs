using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

public interface IMessageService
{
	Task<IEnumerable<MessageDto>> GetProjectMessagesAsync(Guid projectUuid);
	Message SendMessage(CreateMessageDto message);
	bool SaveChanges();
}