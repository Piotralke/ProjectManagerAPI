using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

public interface IProjectEventService
{
    IEnumerable<ProjectEventDto> GetAllProjectEvents(Guid projectId);
    IEnumerable<ProjectEventDto> GetProjectEventsOnly(Guid projectId);
    IEnumerable<ProjectEventDto> GetProjectTasksOnly(Guid projectId);
    ProjectEventDto GetEventByUuid(Guid eventUuid);
    void AddEvent(CreateProjectEventDto projectEvent);
    void UpdateEvent(UpdateProjectEventDto projectEvent);
    void DeleteEvent(Guid eventId);
    bool SaveChanges();
}