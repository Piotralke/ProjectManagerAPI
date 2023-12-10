using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

public class ProjectEventService : IProjectEventService
{
    private readonly ProjectEventRepository _projectEventRepository;
    public ProjectEventService(ProjectEventRepository projectEventRepository)
    {
        _projectEventRepository = projectEventRepository;
    }
    public IEnumerable<ProjectEvents> GetAllProjectEvents(Guid projectId)
    {
        return _projectEventRepository.GetAllProjectEvents(projectId);
    }
    public IEnumerable<ProjectEvents> GetProjectEventsOnly(Guid projectId)
    {
        return _projectEventRepository.GetProjectEventsOnly(projectId);
    }
    public IEnumerable<ProjectEvents> GetProjectTasksOnly(Guid projectId)
    {
        return _projectEventRepository.GetProjectTasksOnly(projectId);
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
        
    }
    public void DeleteEvent(Guid eventId)
    {

    }
    public bool SaveChanges()
    {
        return _projectEventRepository.SaveChanges();
    }

}