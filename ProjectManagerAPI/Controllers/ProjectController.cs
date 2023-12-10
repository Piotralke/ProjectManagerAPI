using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using ProjectManagerAPI.Data.Enum;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagerAPI.Controllers
{
	[Route("api/projects")]
	[Authorize]
	[ApiController]
	public class ProjectController : ControllerBase
	{
		private readonly IProjectService _projectService;
		private readonly IProjectEventService _projectEventService;
		public ProjectController(IProjectService projectService, IProjectEventService projectEventService)
		{
			_projectService = projectService;
			_projectEventService = projectEventService;
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
		[HttpGet("get-for-user/{userId}")]
		public ActionResult<List<ProjectDto>> GetUserProjects([FromRoute] Guid userId)
		{
			var projects = _projectService.GetUserProjects(userId);
			if (projects == null)
			{
				return NotFound();
			}
			return Ok(projects);
		}

		[HttpPost]
		public ActionResult<ProjectDto> CreateProject([FromBody] CreateProjectDto project)
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
		[HttpGet("{$projectId}/GetProjectEvents")]
		public ActionResult<IEnumerable<ProjectEventDto>> GetProjectEvents([FromRoute] Guid projectId, [FromQuery] EventType eventType)
		{
			switch (eventType)
			{
				case EventType.TASK:
					return Ok(_projectEventService.GetProjectTasksOnly(projectId));
				case EventType.EVENT:
					return Ok(_projectEventService.GetProjectEventsOnly(projectId));
				default:
					return Ok(_projectEventService.GetAllProjectEvents(projectId));
			}
		}
		[HttpGet("GetProjectEvent")]
		public ActionResult<ProjectEventDto> GetProjectEvent([FromQuery] Guid eventId)
		{
			return _projectEventService.GetEventByUuid(eventId);
		}
		[HttpPost("AddProjectEvent")]
		public ActionResult AddProjectEvent([FromBody]CreateProjectEventDto projectEvent) 
		{
			_projectEventService.AddEvent(projectEvent);
			if(_projectEventService.SaveChanges())
			{
				return Ok();
			}
			return BadRequest("Failed to create event");
		}
		[HttpPut("UpdateProjectEvent")]
		public ActionResult UpdateProjectEvent([FromBody]UpdateProjectEventDto updateProject)
		{
			_projectEventService.UpdateEvent(updateProject);
			if (_projectEventService.SaveChanges())
			{
				return Ok();
			}
			return BadRequest("Failed to update event");
		}
		[HttpDelete("DeleteProjectEvent/{eventId}")]
		public ActionResult DeleteProjectEvent([FromRoute] Guid eventId)	//jak beda podpieci uzytkownicy do zadania to trzeba sprawdzac i usuwac dowiazania
		{
			_projectEventService.DeleteEvent(eventId);
			if( _projectEventService.SaveChanges())
			{
				return Ok();
			}
			return BadRequest("Failed to delete event");
		}
	}
}
