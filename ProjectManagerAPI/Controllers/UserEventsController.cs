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

	public UserEventsController(IUserEventService userEventService, IProjectEventService projectEventService)
	{
		_userEventService = userEventService;
		_projectEventService = projectEventService;
	}
	[HttpGet("get-events-for-user/{userId}")]
	public ActionResult<IEnumerable<ProjectEventDto>> GetUserEvents([FromRoute] Guid userId)
	{
		var userEvents = _userEventService.GetUserEvents(userId);
		List<ProjectEventDto> result = new List<ProjectEventDto>();
		foreach (var userEvent in userEvents)
		{
			var ev = _projectEventService.GetEventByUuid(userEvent.eventUuid);
			result.Add(ev);
		}
		return result;
	}

}