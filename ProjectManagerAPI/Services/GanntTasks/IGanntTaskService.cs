using ProjectManagerAPI.Dtos;

public interface IGanntTaskService
{
	IEnumerable<GanntTaskDto> GetProjectGanntTasks(Guid projectUuid);
	void AddTask(CreateGanntTaskDto taskDto);
	void DeleteTask(Guid taskUuid);
}