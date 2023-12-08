using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;
public class GanntTaskService : IGanntTaskService
{
	private readonly GanntPreviousTaskRepository _previousTaskRepository;
	private readonly GanntTasksRepository _tasksRepository;

	public GanntTaskService(GanntPreviousTaskRepository previousTaskRepository, GanntTasksRepository tasksRepository)
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
			newTask.previousTasks = GetPreviousTasksRecursive(task.uuid);
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
		};
		_tasksRepository.AddGanntTask(ganntTasks);
		if(taskDto.previousTasksGuids.Count() > 0) 
		{ 
			foreach(var previousTaskUuid in taskDto.previousTasksGuids)
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
		if(taskToDelete == null)
		{
			throw new Exception("Task not found");
		}
		foreach(var previousTask in taskToDelete.previousTasks)
		{
			_previousTaskRepository.RemoveGanntTask(previousTask.uuid);
		}
		var followingTasks = _previousTaskRepository.GetFollowingGanntTasks(taskUuid);
		foreach(var followingTask in followingTasks)
		{
			_previousTaskRepository.RemoveGanntTask(followingTask.uuid);
		}
		_tasksRepository.DeleteGanntTask(taskUuid); 
		_tasksRepository.SaveChanges();
	}


	private List<GanntTaskDto> GetPreviousTasksRecursive(Guid taskId)
	{
		var previousTasks = new List<GanntTaskDto>();
		var tasks = _previousTaskRepository.GetPreviousGanntTasks(taskId);

		foreach (var previousTask in tasks)
		{
			var task = _tasksRepository.GetGanntTaskByUuid(previousTask.previousTaskId);
			var taskDto = MapTaskDto(task);
			taskDto.previousTasks = GetPreviousTasksRecursive(task.uuid);
			previousTasks.Add(taskDto);
		}

		return previousTasks;
	}
	private GanntTaskDto MapTaskDto(GanntTasks task)
	{
		return new GanntTaskDto
		{
			uuid = task.uuid,
			title = task.title,
			description = task.description,
			startDate = task.startDate,
			endDate = task.endDate,
			projectUuid = task.projectUuid,
			previousTasks = new List<GanntTaskDto>()
		};
	}
}