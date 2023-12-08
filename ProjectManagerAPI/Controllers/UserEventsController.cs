using Microsoft.AspNetCore.Mvc;

public class UserEventsController : ControllerBase
{
	private readonly IUserEventService _userEventService;

	public UserEventsController(IUserEventService userEventService)
	{
		_userEventService = userEventService;
	}

}