using ProjectManagerAPI.Dtos;

public interface IMessageService
{
	IEnumerable<MessageDto> GetProjectMessages(Guid projectUuid);
	void SendMessage(CreateMessageDto message);
	bool SaveChanges();
}