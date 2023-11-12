using ProjectManagerAPI.Models;

public interface IGanntTasksRepository
{
	IEnumerable<GanntTasks> GetProjectGanntTasks(Guid projectUuid);
	GanntTasks GetGanntTaskByUuid(Guid taskUuid);
	void AddGanntTask(GanntTasks task);
	void DeleteGanntTask(Guid taskUuid);
	void UpdateGanntTask(GanntTasks task);
	bool SaveChanges();
}