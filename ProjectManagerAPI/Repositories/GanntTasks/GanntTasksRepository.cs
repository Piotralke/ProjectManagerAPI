using ProjectManagerAPI.Data;
using ProjectManagerAPI.Models;

public class GanntTasksRepository : IGanntTasksRepository
{
	private readonly ApplicationDbContext _context;

	public GanntTasksRepository(ApplicationDbContext context)
	{
		_context = context;
	}
	public IEnumerable<GanntTasks> GetProjectGanntTasks(Guid projectUuid)
	{
		return _context.GanntTasks.Where(g=>g.projectUuid == projectUuid).ToList();

	}
	public GanntTasks GetGanntTaskByUuid(Guid taskUuid)
	{
		var task = _context.GanntTasks.FirstOrDefault(g => g.uuid == taskUuid);
		if(task == null)
		{
			throw new Exception("Gannt task not found");
		}
		return task;
	}
	public void AddGanntTaks(GanntTasks task)
	{
		_context.GanntTasks.Add(task);
	}
	public void DeleteGanntTaks(Guid taskUuid)
	{
		var task = GetGanntTaskByUuid(taskUuid);
		_context.GanntTasks.Remove(task);
	}
	public void UpdateGanntTaks(GanntTasks task)
	{
		_context.GanntTasks.Update(task);
	}
	public bool SaveChanges()
	{
		return _context.SaveChanges() > 0;
	}
}