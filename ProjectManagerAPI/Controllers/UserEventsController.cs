using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Services;

[Route("api/user-events")]
[ApiController]
[Authorize]
public class UserEventsController : ControllerBase
{
	private readonly IUserEventService _userEventService;
	private readonly IProjectEventService _projectEventService;
	private readonly IProjectService _projectService;
	private readonly IUserService _userService;
	public UserEventsController(IUserEventService userEventService, IProjectEventService projectEventService, IProjectService projectService, IUserService userService)
	{
		_userEventService = userEventService;
		_projectEventService = projectEventService;
		_projectService = projectService;
		_userService = userService;
		
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
	[HttpGet("get-users-for-event/{eventId}")]
	public async Task<ActionResult<IEnumerable<UserDto>>> GetEventUsers([FromRoute] Guid eventId) 
	{
		var eventUsers = _userEventService.GetEventUsers(eventId);
		List<UserDto> result = new List<UserDto>();
		foreach (var userEvent in eventUsers)
		{
			var user = await _userService.GetUserByIdAsync(userEvent.userUuid);
			result.Add(user);
		}
		return result;
	}
}