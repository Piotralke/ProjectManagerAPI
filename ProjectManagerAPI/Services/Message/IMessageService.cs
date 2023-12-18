using ProjectManagerAPI.Dtos;

public interface IMessageService
{
	Task<IEnumerable<MessageDto>> GetProjectMessagesAsync(Guid projectUuid);
	void SendMessage(CreateMessageDto message);
	bool SaveChanges();
}