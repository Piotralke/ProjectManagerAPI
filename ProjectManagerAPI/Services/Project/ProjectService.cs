using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

public class ProjectService : IProjectService
{
	private readonly IProjectRepository _repository;
	private readonly IProjectMembersRepository _projectMembersRepository;

	public ProjectService(IProjectRepository repository, IProjectMembersRepository projectMembersRepository)
	{
		_repository = repository;
		_projectMembersRepository = projectMembersRepository;
	}

	public IEnumerable<ProjectDto> GetAllProjects()
	{
		var projects = _repository.GetAllProjects();
		List<ProjectDto> result = new List<ProjectDto>();
		foreach (var project in projects)
		{
			ProjectDto dto = new ProjectDto(project);
			result.Add(dto);
		}
		return result;
	}
	public IEnumerable<ProjectDto> GetUserProjects(Guid userId) 
	{ 
		var projectMembersList = _projectMembersRepository.GetProjectsForUser(userId);
		List<ProjectDto> userProjects = new List<ProjectDto>();
		foreach (var projectMember in projectMembersList)
		{
			var project = GetProjectById(projectMember.projectUuid);
			userProjects.Add(project);
		}
		return userProjects;
	}
	public ProjectDto GetProjectById(Guid projectId)
	{
		var project = _repository.GetProjectById(projectId);
		ProjectDto result = new ProjectDto(project);
		return result;
	}
	public ProjectDto AddProject(CreateProjectDto project)
	{
		Project newProject = new Project
		{
			uuid = Guid.NewGuid(),
			title = project.title,
			description = project.description,
			ownerUuid = project.ownerUuid,
			createdAt = DateTime.UtcNow,
			isPrivate = project.isPrivate,
		};
		project.members.Add(project.ownerUuid);
		foreach (var member in project.members)
		{
			ProjectMembers projectMember = new ProjectMembers
			{
				uuid = Guid.NewGuid(),
				projectUuid = newProject.uuid,
				userUuid = member
			};
			AddProjectMember(projectMember);
		}
		_repository.AddProject(newProject);
		ProjectDto result = new ProjectDto(newProject);
		return result;

	}
	public void UpdateProject(UpdateProjectDto project)
	{

	}
	public void DeleteProject(Guid projectId)
	{

	}
	public bool SaveChanges()
	{
		return _repository.SaveChanges();
	}

	public void AddProjectMember(ProjectMembers members)
	{
		_projectMembersRepository.AddProjectMember(members);
	}
	public void RemoveProjectMember(Guid projectId, Guid memberId) {

		_projectMembersRepository.DeleteProjectMember(projectId, memberId);
	}
	public IEnumerable<ProjectMembers> GetProjectMembers(Guid projectId)
	{
		return _projectMembersRepository.GetProjectMembers(projectId);
	}

}