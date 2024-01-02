using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;
using System;
using System.Collections.Generic;

namespace ProjectManagerAPI.Controllers
{
	[Route("api/groups")]
	[ApiController]
	public class GroupController : ControllerBase
	{
		private readonly IGroupService _groupService;

		public GroupController(IGroupService groupService)
		{
			_groupService = groupService;
		}
		[HttpGet("get-all")]
		public ActionResult<IEnumerable<Group>> GetAllGroups()
		{
			var userGroups = _groupService.GetAllGroups();
			return Ok(userGroups);
		}
		[HttpGet("user/{userId}")]
		public ActionResult<IEnumerable<Group>> GetUserGroups(Guid userId)
		{
			var userGroups = _groupService.GetUserGroups(userId);
			return Ok(userGroups);
		}

		[HttpGet("{groupId}")]
		public ActionResult<Group> GetGroup(Guid groupId)
		{
			var group = _groupService.GetGroup(groupId);
			if (group == null)
			{
				return NotFound();
			}
			return Ok(group);
		}

		[HttpGet("get-teacher-groups/{teacherId}")]
		public ActionResult<IEnumerable<Group>> GetTeacherGroups([FromRoute] Guid teacherId)
		{
			var teacherGroups = _groupService.GetTeacherGroups(teacherId);
			return Ok(teacherGroups);
		}

		[HttpGet("get-groups-by-subject/{subjectId}")]
		public ActionResult<IEnumerable<Group>> GetGroupsBySubject([FromRoute] Guid subjectId)
		{
			var groupsBySubject = _groupService.GetGroupsBySubject(subjectId);
			return Ok(groupsBySubject);
		}

		[HttpPost("create-group")]
		public ActionResult<Group> CreateGroup([FromBody] CreateGroupDto groupDto)
		{
			_groupService.AddGroup(groupDto);
			if (_groupService.SaveChanges())
			{
				return Ok(groupDto);
			}
			return BadRequest("Failed to create group.");
		}
	}
}
