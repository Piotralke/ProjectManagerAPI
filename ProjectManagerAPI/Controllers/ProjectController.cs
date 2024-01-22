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
		private readonly IUserEventService _userEventService;
		private readonly IGanntTaskService _ganntTaskService;
		public ProjectController(IProjectService projectService,IGanntTaskService ganntTaskService, IProjectEventService projectEventService, IUserEventService userEventService)
		{
			_projectService = projectService;
			_projectEventService = projectEventService;
			_userEventService = userEventService;
			_ganntTaskService = ganntTaskService;
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
		public async Task<ActionResult<IEnumerable<UserDto>>> GetProjectMembers(Guid projectId)
		{
			var members = await _projectService.GetProjectMembers(projectId);
			if (members == null)
			{
				return NotFound();
			}
			return Ok(members);
		}
		[HttpGet("{projectId}/GetProjectEvents")]
		public ActionResult<IEnumerable<ProjectEventDto>> GetProjectEvents([FromRoute] Guid projectId, [FromQuery] EventType eventType = EventType.Default)
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
		[HttpGet("{projectId}/GetNearestEvent")]
		public ActionResult<ProjectEventDto> GetNearestEvent([FromRoute] Guid projectId, [FromQuery] Guid userId, [FromQuery] EventType eventType)
		{
			List<ProjectEventDto> projectEvents = new List<ProjectEventDto>();
			
			switch (eventType)
			{
				case EventType.TASK:
					projectEvents.AddRange(_projectEventService.GetProjectTasksOnly(projectId));
					break;
				case EventType.EVENT:
					projectEvents.AddRange(_projectEventService.GetProjectEventsOnly(projectId));
					break;
				default:
					projectEvents.AddRange( _projectEventService.GetAllProjectEvents(projectId));
					break;
			}
			var userEvents = _userEventService.GetUserEvents(userId);
			var currentDate = DateTime.Now;

			ProjectEventDto nearestEvent = null;
			TimeSpan? nearestTimeDifference = null;

			foreach (var userEvent in userEvents)
			{
				var projectEvent = projectEvents.FirstOrDefault(pe => pe.uuid == userEvent.eventUuid);

				// Pomijaj wydarzenia, których nie ma w projekcie
				if (projectEvent == null)
				{
					continue;
				}

				DateTime eventTime;

				// Wybór odpowiedniego pola czasowego w zależności od typu wydarzenia
				if (eventType == EventType.TASK)
				{
					eventTime = projectEvent.dueTo;
					if (projectEvent.status == EventStatus.FINISHED)
					{
						continue;
					}
				}
				else if (eventType == EventType.EVENT)
				{
					if (!projectEvent.startTime.HasValue)
					{
						// Ignoruj wydarzenia bez ustalonej daty rozpoczęcia
						continue;
					}

					eventTime = projectEvent.startTime.Value;
				}
				else
				{
					// Obsługa innych typów wydarzeń, jeśli są dostępne
					continue;
				}

				// Sprawdzenie, czy wydarzenie jest po dzisiejszej dacie
				if (eventTime > currentDate)
				{
					// Obliczenie różnicy czasu
					var timeDifference = eventTime - currentDate;

					// Aktualizacja najbliższego wydarzenia, jeśli jest bliższe niż poprzednie
					if (!nearestTimeDifference.HasValue || timeDifference < nearestTimeDifference)
					{
						nearestTimeDifference = timeDifference;
						nearestEvent = projectEvent;
					}
				}
			}

			return nearestEvent;
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
		public ActionResult UpdateProjectEvent([FromBody] UpdateProjectEventDto updateProject)
		{
			_projectEventService.UpdateEvent(updateProject);
			if (_projectEventService.SaveChanges())
			{
				return Ok();
			}
			return BadRequest("Failed to update event");
		}

		[HttpGet("GetProjectGanttTasks/{projectId}")]
		public ActionResult<IEnumerable<GanntTaskDto>> GetProjectGanttTasks([FromRoute] Guid projectId)
		{
			var result = _ganntTaskService.GetProjectGanntTasks(projectId);
			if(result == null)
			{
				return BadRequest("Tasks not found");
			}
			return Ok(result);
		}
		[HttpPost("AddGanttTask")]
		public ActionResult AddGanttTask([FromBody]CreateGanntTaskDto createGanntTaskDto)
		{
			_ganntTaskService.AddTask(createGanntTaskDto);
			if (_ganntTaskService.SaveChanges())
			{
				return Ok();
			}
			return BadRequest("Failed to add gantt task");

		}
		[HttpGet("GetGroupSubjectProjects")]
		public ActionResult<IEnumerable<ProjectDto>> GetGroupSubjectProjects([FromQuery] Guid GroupId, [FromQuery] Guid SubjectId)
		{
			var result = _projectService.GetGroupSubjectProjects(GroupId, SubjectId);
			if (result == null)
			{
				return BadRequest("Projeccts not found");
			}
			return Ok(result);
		}
		[HttpGet("GetUserProjectForSubject")]
		public ActionResult<ProjectDto> GetUserProjectForSubject([FromQuery] Guid userId, [FromQuery] Guid subjectId)
		{
			var result =  _projectService.GetUserProjectForSubject(userId, subjectId);
			if( result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}
		[HttpPost("RateProject")]
		public ActionResult RateProject([FromBody] RateProjectDto rateProjectDto)
		{
			ProjectGrade grade = new ProjectGrade
			{
				uuid = Guid.NewGuid(),
				projectUuid = rateProjectDto.projectUuid,
				comment = rateProjectDto.comment,
				value = rateProjectDto.gradeValue
			};
			_projectService.RateProject(grade);
			if(_projectService.SaveChanges())
			{
				return Ok();
			}
			return BadRequest("Failed to rate project");
		}
		[HttpGet("GetProjectGrade/{projectId}")]
		public ActionResult<ProjectGrade> GetProjectGrade([FromRoute] Guid projectId)
		{
			var result = _projectService.GetProjectGrade(projectId);
			if(result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}
	}
}
