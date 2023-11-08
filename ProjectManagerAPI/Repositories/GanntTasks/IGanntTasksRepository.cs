using ProjectManagerAPI.Models;

public interface IGanntTasksRepository
{
	IEnumerable<GanntTasks> GetProjectGanntTasks(Guid projectUuid);
	GanntTasks GetGanntTaskByUuid(Guid taskUuid);
	void AddGanntTaks(GanntTasks task);
	void DeleteGanntTaks(Guid taskUuid);
	void UpdateGanntTaks(GanntTasks task);
	bool SaveChanges();
}