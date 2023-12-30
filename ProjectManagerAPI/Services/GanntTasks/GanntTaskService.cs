using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;
public class GanntTaskService : IGanntTaskService
{
	private readonly IGanntPreviousTaskRepository _previousTaskRepository;
	private readonly IGanntTasksRepository _tasksRepository;

	public GanntTaskService(IGanntPreviousTaskRepository previousTaskRepository, IGanntTasksRepository tasksRepository)
	{
		_previousTaskRepository = previousTaskRepository;
		_tasksRepository = tasksRepository;
	}

	public IEnumerable<GanntTaskDto> GetProjectGanntTasks(Guid projectUuid)
	{
		List<GanntTaskDto> result = new List<GanntTaskDto>();
		var tasks = _tasksRepository.GetProjectGanntTasks(projectUuid);
		if (tasks == null)
		{
			throw new Exception("Gannt tasks not found for this project");
		}

		foreach (var task in tasks)
		{
			var newTask = MapTaskDto(task);
			newTask.dependencies = GetPreviousTasks(task.uuid).ToList();
			result.Add(newTask);
		}

		return result;
	}

	public void AddTask(CreateGanntTaskDto taskDto)
	{
		GanntTasks ganntTasks = new GanntTasks
		{
			uuid = new Guid(),
			title = taskDto.title,
			description = taskDto.description,
			startDate = taskDto.startDate,
			endDate = taskDto.endDate,
			projectUuid = taskDto.projectUuid,
			type = taskDto.type,
		};
		_tasksRepository.AddGanntTask(ganntTasks);
		if (taskDto.previousTasksGuids.Count() > 0)
		{
			foreach (var previousTaskUuid in taskDto.previousTasksGuids)
			{
				GanntPreviousTask previousTask = new GanntPreviousTask
				{
					uuid = new Guid(),
					taskId = ganntTasks.uuid,
					previousTaskId = previousTaskUuid
				};
				_previousTaskRepository.AddGanntTask(previousTask);
			}
		}
		_tasksRepository.SaveChanges();
	}

	public void DeleteTask(Guid taskUuid)
	{
		var taskToDelete = _tasksRepository.GetGanntTaskByUuid(taskUuid);
		if (taskToDelete == null)
		{
			throw new Exception("Task not found");
		}
		foreach (var previousTask in taskToDelete.previousTasks)
		{
			_previousTaskRepository.RemoveGanntTask(previousTask.uuid);
		}
		var followingTasks = _previousTaskRepository.GetFollowingGanntTasks(taskUuid);
		foreach (var followingTask in followingTasks)
		{
			_previousTaskRepository.RemoveGanntTask(followingTask.uuid);
		}
		_tasksRepository.DeleteGanntTask(taskUuid);
		_tasksRepository.SaveChanges();
	}

	private IEnumerable<Guid> GetPreviousTasks(Guid taskId)
	{
		return _previousTaskRepository
			.GetPreviousGanntTasks(taskId)
			.Select(previousTask => previousTask.previousTaskId);
	}

	private GanntTaskDto MapTaskDto(GanntTasks task)
	{
		return new GanntTaskDto
		{
			id = task.uuid,
			name = task.title,
			description = task.description,
			start = task.startDate,
			end = task.endDate,
			projectUuid = task.projectUuid,
			type = task.type,
			dependencies = new List<Guid>()
		};
	}

	public bool SaveChanges()
	{
		return _tasksRepository.SaveChanges();
	}
}