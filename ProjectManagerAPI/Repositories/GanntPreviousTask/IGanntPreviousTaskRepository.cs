using ProjectManagerAPI.Models;

public interface IGanntPreviousTaskRepository
{
	IEnumerable<GanntPreviousTask> GetPreviousGanntTasks(Guid taskId);
	GanntPreviousTask GetPreviousTaskByUuid(Guid uuid);
	IEnumerable<GanntPreviousTask> GetFollowingGanntTasks(Guid taskId);
	void AddGanntTask(GanntPreviousTask ganntTask);
	void RemoveGanntTask(Guid uuid);
	bool SaveChanges();
}