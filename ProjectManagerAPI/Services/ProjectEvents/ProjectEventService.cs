using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

public class ProjectEventService : IProjectEventService
{
    private readonly IProjectEventRepository _projectEventRepository;
    public ProjectEventService(IProjectEventRepository projectEventRepository)
    {
        _projectEventRepository = projectEventRepository;
    }
    public IEnumerable<ProjectEventDto> GetAllProjectEvents(Guid projectId)
    {
		var projects = _projectEventRepository.GetAllProjectEvents(projectId);
		List<ProjectEventDto> result = new List<ProjectEventDto>();
		foreach (var project in projects)
		{
			ProjectEventDto newProject = new ProjectEventDto(project);
			result.Add(newProject);
		}
		return result;
	}
    public IEnumerable<ProjectEventDto> GetProjectEventsOnly(Guid projectId)
    {
		var projects = _projectEventRepository.GetProjectEventsOnly(projectId);
		List<ProjectEventDto> result = new List<ProjectEventDto>();
		foreach (var project in projects)
		{
			ProjectEventDto newProject = new ProjectEventDto(project);
			result.Add(newProject);
		}
		return result;
	}
    public IEnumerable<ProjectEventDto> GetProjectTasksOnly(Guid projectId)
    {
        var projects = _projectEventRepository.GetProjectTasksOnly(projectId);
        List<ProjectEventDto> result = new List<ProjectEventDto>();
        foreach (var project in projects)
        {
            ProjectEventDto newProject = new ProjectEventDto(project);
            result.Add(newProject);
        }
        return result;

	}
    public ProjectEventDto GetEventByUuid(Guid eventUuid)
    {
        var ev = _projectEventRepository.GetEventByUuid(eventUuid);
        if(ev==null)
        {
            throw new Exception("Event not found");

        }
        ProjectEventDto result = new ProjectEventDto(ev);
        return result;
    }
    public void AddEvent(CreateProjectEventDto projectEvent)
    {
        ProjectEvents newEvent = new ProjectEvents
        {
            uuid = new Guid(),
            title = projectEvent.title,
            description = projectEvent.description,
            dueTo = projectEvent.dueTo,
            startTime = projectEvent.startTime,
            projectUuid = projectEvent.projectUuid,
            status = ProjectManagerAPI.Data.Enum.EventStatus.PLANNED,
            type = projectEvent.type
        };
        _projectEventRepository.AddEvent(newEvent);
    }
    public void UpdateEvent(UpdateProjectEventDto projectEvent)
    {
        var ev = _projectEventRepository.GetEventByUuid(projectEvent.uuid);
        if(ev==null)
        {
            throw new Exception("Event not found");
        }
        ev.title = projectEvent.title;
        ev.description = projectEvent.description;
        ev.dueTo = projectEvent.dueTo;
        ev.startTime = projectEvent.startTime;
        ev.status = projectEvent.status;
		
        _projectEventRepository.UpdateEvent(ev);

	}
    public void DeleteEvent(Guid eventId)
    {
        _projectEventRepository.DeleteEvent(eventId);
	}
    public bool SaveChanges()
    {
        return _projectEventRepository.SaveChanges();
    }

}