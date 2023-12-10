using ProjectManagerAPI.Data;
using ProjectManagerAPI.Models;
using ProjectManagerAPI.Repositories.ProjectEvent;

public class ProjectEventRepository : IProjectEventRepository
{
    private readonly ApplicationDbContext _context;
    public ProjectEventRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public IEnumerable<ProjectEvents> GetAllProjectEvents(Guid projectId)
    {
        return _context.ProjectEvents.Where(e=>e.projectUuid== projectId).ToList();
      
    }
    public IEnumerable<ProjectEvents> GetProjectEventsOnly(Guid projectId)
    {
        return _context.ProjectEvents.Where(e => e.projectUuid == projectId && e.type == ProjectManagerAPI.Data.Enum.EventType.EVENT).ToList();
    }
    public IEnumerable<ProjectEvents> GetProjectTasksOnly(Guid projectId)
    {
        return _context.ProjectEvents.Where(e => e.projectUuid == projectId && e.type == ProjectManagerAPI.Data.Enum.EventType.TASK).ToList();
    }
    public ProjectEvents GetEventByUuid(Guid eventUuid)
    {
        return _context.ProjectEvents.FirstOrDefault(e => e.uuid == eventUuid);
    }
    public void AddEvent(ProjectEvents projectEvent)
    {
        _context.ProjectEvents.Add(projectEvent);
    }
    public void UpdateEvent(ProjectEvents projectEvent)
    {
        _context.ProjectEvents.Update(projectEvent);
    }
    public void DeleteEvent(Guid eventId)
    {
        var ev = GetEventByUuid(eventId);
        if(ev != null)
        {
            _context.ProjectEvents.Remove(ev);
        }
    }
    public bool SaveChanges()
    {
        return _context.SaveChanges() > 0;
    }
}