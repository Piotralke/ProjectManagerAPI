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

		[HttpPost]
		public ActionResult<Group> CreateGroup([FromBody] Group groupDto)
		{
			_groupService.AddGroup(groupDto);
			if (_groupService.SaveChanges())
			{
				return CreatedAtAction("GetGroup", new { groupId = groupDto.uuid }, groupDto);
			}
			return BadRequest("Failed to create group.");
		}

		
	}
}
