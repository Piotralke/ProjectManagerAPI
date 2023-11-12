using ProjectManagerAPI.Data;
using ProjectManagerAPI.Models;

public class GanntPreviousTaskRepository : IGanntPreviousTaskRepository
{
	private readonly ApplicationDbContext _context;

	public GanntPreviousTaskRepository(ApplicationDbContext context)
	{
		_context = context;
	}
	public IEnumerable<GanntPreviousTask> GetPreviousGanntTasks(Guid taskId)
	{
		return _context.GanntPreviousTasks.Where(g=>g.taskId == taskId).ToList();
	}
	public GanntPreviousTask GetPreviousTaskByUuid(Guid uuid)
	{
		var task = _context.GanntPreviousTasks.FirstOrDefault(g => g.uuid == uuid);
		if (task == null)
		{
			throw new Exception("Previous gannt task not found");
		}
		return task;
	}
	public IEnumerable<GanntPreviousTask> GetFollowingGanntTasks(Guid taskId)
	{
		return _context.GanntPreviousTasks.Where(g => g.previousTaskId == taskId).ToList();
	}
	public void AddGanntTask(GanntPreviousTask task)
	{
		_context.Add(task);
	}
	public void RemoveGanntTask(Guid uuid)
	{
		var task = GetPreviousTaskByUuid(uuid);
		if (task != null)
		{
			_context.Remove(task);
		}
	}
	public bool SaveChanges()
	{
		return _context.SaveChanges() > 0;
	}
}