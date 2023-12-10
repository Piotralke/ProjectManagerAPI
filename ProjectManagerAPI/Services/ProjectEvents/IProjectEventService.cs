using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

public interface IProjectEventService
{
    IEnumerable<ProjectEvents> GetAllProjectEvents(Guid projectId);
    IEnumerable<ProjectEvents> GetProjectEventsOnly(Guid projectId);
    IEnumerable<ProjectEvents> GetProjectTasksOnly(Guid projectId);
    ProjectEventDto GetEventByUuid(Guid eventUuid);
    void AddEvent(ProjectEventDto projectEvent);
    void UpdateEvent(ProjectEvents projectEvent);
    void DeleteEvent(Guid eventId);
    bool SaveChanges();
}