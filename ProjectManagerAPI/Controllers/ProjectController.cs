using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagerAPI.Controllers
{
	[Route("projects")]
	[Authorize]
	[ApiController]
	public class ProjectController : ControllerBase
	{
		private readonly IProjectService _projectService;

		public ProjectController(IProjectService projectService)
		{
			_projectService = projectService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<ProjectDto>> GetAllProjects()
		{
			var projects = _projectService.GetAllProjects();
			return Ok(projects);
		}

		[HttpGet("{uuid}")]
		public ActionResult<ProjectDto> GetProject(Guid uuid)
		{
			var project = _projectService.GetProjectById(uuid);
			if(project == null)
			{
				return NotFound();
			}
			return Ok(project);
		}

		[HttpPost]
		public ActionResult<ProjectDto> CreateProject(CreateProjectDto project)
		{
			var createdProject = _projectService.AddProject(project);
			if (_projectService.SaveChanges())
			{
				return CreatedAtAction("GetProject", new { uuid = createdProject.uuid }, createdProject);
			}
			return BadRequest("Failed to create user.");
		}

		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		[HttpDelete("{id}")]
		public void  Delete(int id)
		{
		}

		[HttpDelete("{projectId}/RemoveMmeber/{memberId}")]
		public ActionResult RemoveProjectMember(Guid projectId, Guid memberId)
		{
			_projectService.RemoveProjectMember(projectId, memberId);
			if(_projectService.SaveChanges())
			{
				return NoContent();
			}
			return BadRequest("Failed to delete project member");

		}
		[HttpPost("AddProjectMember")]
		public ActionResult AddProjectMember([FromBody] CreateProjectMemberDto member)
		{
			ProjectMembers newMember = new ProjectMembers
			{
				uuid = new Guid(),
				projectUuid = member.projectUuid,
				userUuid = member.memberUuid
			};
			_projectService.AddProjectMember(newMember);
			if (_projectService.SaveChanges())
			{
				return Ok();
			}
			return BadRequest("Failed to create user.");
		}

		//Zwraca ProjectMember (user, project jako null) zrobic join gdy potrzebne
		[HttpGet("{projectId}/GetProjectMembers")]	
		public ActionResult<IEnumerable<ProjectMembers>> GetProjectMembers(Guid projectId)
		{
			var members = _projectService.GetProjectMembers(projectId);
			if (members == null)
			{
				return NotFound();
			}
			return Ok(members);
		}
	}
}
