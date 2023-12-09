using ProjectManagerAPI.Data.Enum;
using ProjectManagerAPI.Models;

public interface IProjectEventRepository
{
    IEnumerable<ProjectEvents> GetAllProjectEvents(Guid projectId);
    IEnumerable<ProjectEvents> GetProjectEventsOnly(Guid projectId);
    IEnumerable<ProjectEvents> GetProjectTasksOnly(Guid projectId);
    ProjectEvents GetEventByUuid(Guid eventUuid);
    void AddEvent(ProjectEvents projectEvent);
    void UpdateEvent(ProjectEvents projectEvent);
    void DeleteEvent(Guid eventId);
    bool SaveChanges();
}