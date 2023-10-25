using ProjectManagerAPI.Data;
using ProjectManagerAPI.Models;

public class ProjectRepository : IProjectRepository
{
	private readonly ApplicationDbContext _context;

	public ProjectRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public IEnumerable<Project> GetAllProjects()
	{
		return _context.Projects.ToList();
	}
	public Project GetProjectById(Guid projectId)
	{
		return _context.Projects.FirstOrDefault(p => p.uuid == projectId);
	}
	public void AddProject(Project project)
	{
		_context.Projects.Add(project);
	}
	public void UpdateProject(Project project)
	{
		_context.Projects.Update(project);
	}
	public void DeleteProject(Guid projectId)
	{
		var project = _context.Projects.FirstOrDefault(p=>p.uuid == projectId);
        if (project!=null)
        {
			_context.Projects.Remove(project);
        }
    }
	public bool SaveChanges()
	{
		return _context.SaveChanges() > 0;
	}
}