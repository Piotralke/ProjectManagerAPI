using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagerAPI.Controllers
{
	[Route("projects")]
	[ApiController]
	public class ProjectController : ControllerBase
	{
		private readonly IProjectService _projectService;

		public ProjectController(IProjectService projectService)
		{
			_projectService = projectService;
		}

		// GET: api/<ProjectController>
		[HttpGet]
		public ActionResult<IEnumerable<ProjectDto>> GetAllProjects()
		{
			var projects = _projectService.GetAllProjects();
			return Ok(projects);
		}

		// GET api/<ProjectController>/5
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

		// POST api/<ProjectController>
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

		// PUT api/<ProjectController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<ProjectController>/5
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

	}
}
