using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.Dtos;

[Route("api/user-events")]
[ApiController]
[Authorize]
public class UserEventsController : ControllerBase
{
	private readonly IUserEventService _userEventService;
	private readonly IProjectEventService _projectEventService;
	private readonly IProjectService _projectService;
	public UserEventsController(IUserEventService userEventService, IProjectEventService projectEventService, IProjectService projectService)
	{
		_userEventService = userEventService;
		_projectEventService = projectEventService;
		_projectService = projectService;
	}
	[HttpGet("get-events-for-user/{userId}")]
	public ActionResult<IEnumerable<ProjectEventDto>> GetUserEvents([FromRoute] Guid userId)
	{
		var userEvents = _userEventService.GetUserEvents(userId);
		List<ProjectEventDto> result = new List<ProjectEventDto>();
		foreach (var userEvent in userEvents)
		{
			var ev = _projectEventService.GetEventByUuid(userEvent.eventUuid);
			var project = _projectService.GetProjectById(ev.projectUuid);
			ev.projectTitle = project.title;
			result.Add(ev);
		}
		return result;
	}

}