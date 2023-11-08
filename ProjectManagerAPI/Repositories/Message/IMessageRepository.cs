using ProjectManagerAPI.Models;

public interface IMessageRepository
{
	IEnumerable<Message> GetProjectMessages(Guid projectUuid);
	void AddMessage(Message message);
	void EditMessage(Message message);
	void DeleteMessage(Guid messageUuid);
	bool SaveChanges();
}