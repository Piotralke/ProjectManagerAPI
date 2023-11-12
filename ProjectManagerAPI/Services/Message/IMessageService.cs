using ProjectManagerAPI.Dtos;

public interface IMessageService
{
	IEnumerable<MessageDto> GetProjectMessages(Guid projectUuid);
}