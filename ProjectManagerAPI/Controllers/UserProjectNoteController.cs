using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Controllers
{
	[Route("api/notes")]
	[Authorize]
	[ApiController]
	public class UserProjectNoteController : ControllerBase
	{
		private readonly IUserProjectNoteService _userProjectNoteService;
		public UserProjectNoteController(IUserProjectNoteService userProjectNoteService)
		{
			_userProjectNoteService = userProjectNoteService;
		}

		[HttpGet]
		public ActionResult<UserProjectNote> GetUserProjectNote([FromQuery] Guid projectId, [FromQuery] Guid userId)
		{
			var note = _userProjectNoteService.GetProjectNote(projectId, userId);
			if (note == null)
			{
				return NotFound();
			}
			return Ok(note);
		}
		[HttpPost]
		public ActionResult AddProjectNote([FromBody] UserProjectNoteDto note) 
		{
			_userProjectNoteService.AddProjectNote(note);
			if(_userProjectNoteService.SaveChanges())
			{
				return Ok();
			}
			return BadRequest("Cannot save note to db");
		}
		[HttpPut]
		public ActionResult UpdateProjectNote([FromBody] UserProjectNoteDto note)
		{
			_userProjectNoteService.UpdateProjectNote(note);
			if (_userProjectNoteService.SaveChanges())
			{
				return Ok();
			}
			return BadRequest("Cannot update note in db");
		}
	}
}
