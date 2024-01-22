using Microsoft.AspNetCore.Mvc;
using ProjectManagerAPI.Data.Enum;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;
using System;
using System.Collections.Generic;

[Route("api/project-proposals")]
[ApiController]
public class ProjectProposalController : ControllerBase
{
	private readonly IProjectProposalService _projectProposalService;

	public ProjectProposalController(IProjectProposalService projectProposalService)
	{
		_projectProposalService = projectProposalService;
	}

	[HttpGet("{proposalId}")]
	public ActionResult<ProjectProposal> GetProjectProposal(Guid proposalId)
	{
		var projectProposal = _projectProposalService.GetProjectProposalById(proposalId);
		if (projectProposal == null)
		{
			return NotFound();
		}
		return Ok(projectProposal);
	}
	[HttpGet("get-user-proposal-for-subject")]
	public ActionResult<ProjectProposal> GetSubjectProposalForUser([FromQuery]Guid subjectId, [FromQuery]Guid userId)
	{
		var result = _projectProposalService.GetSubjectProposalForUser(subjectId, userId);
		return Ok(result);
	}
	[HttpGet("get-by-subject/{subjectId}")]
	public ActionResult<IEnumerable<ProjectProposal>> GetProjectProposalsBySubject([FromRoute] Guid subjectId)
	{
		var projectProposals = _projectProposalService.GetProjectProposalsBySubject(subjectId);
		if (projectProposals == null)
		{
			return NotFound();
		}
		return Ok(projectProposals);
	}

	[HttpGet("get-all-teacher-proposals/{teacherId}")]
	public ActionResult<IEnumerable<ProjectProposal>> GetAllTeacherProposals([FromRoute] Guid teacherId)
	{
		var projectProposals = _projectProposalService.GetAllTeacherProposals(teacherId);
		if(projectProposals == null)
		{
			return NotFound();
		}
		return Ok(projectProposals);
	}

	[HttpGet("{projectProposalId}/get-squads")]
	public ActionResult<IEnumerable<ProposalSquad>> GetProposalSquadsByProjectProposal([FromRoute] Guid projectProposalId)
	{
		var proposalSquads = _projectProposalService.GetProposalSquadsByProjectProposal(projectProposalId);
		if (proposalSquads == null)
		{
			return NotFound();
		}
		return Ok(proposalSquads);
	}

	[HttpPost]
	public ActionResult<ProjectProposal> AddProjectProposal([FromBody] CreateProjectProposalDto projectProposalDto)
	{
		// Mapowanie DTO na model
		var projectProposal = new ProjectProposal
		{
			uuid = Guid.NewGuid(),
			subjectUuid = projectProposalDto.SubjectUuid,
			title = projectProposalDto.Title,
			description = projectProposalDto.Description,
			cretedAt = DateTime.UtcNow,
			editedAt = null,
			state = 0,
			// ... inne pola
		};

		_projectProposalService.AddProjectProposal(projectProposal);

		// Dodanie członków do ProposalSquad
		if (projectProposalDto.MembersIds != null && projectProposalDto.MembersIds.Any())
		{
			foreach (var memberId in projectProposalDto.MembersIds)
			{
				var proposalSquad = new ProposalSquad
				{
					uuid = Guid.NewGuid(),
					projectProposalUuid = projectProposal.uuid,
					userUuid = memberId,
					// ... inne pola
				};

				_projectProposalService.AddProjectProposalSquad(proposalSquad);
			}
		}

		if (_projectProposalService.SaveChanges())
		{
			return CreatedAtAction("GetProjectProposal", new { proposalId = projectProposal.uuid }, projectProposal);
		}

		return BadRequest("Failed to create project proposal.");
	}

	[HttpPut]
	public ActionResult UpdateProjectProposal([FromBody]UpdateProjectProposalDto projectProposal)
	{
		_projectProposalService.UpdateProjectProposal(projectProposal);
		if (!_projectProposalService.SaveChanges() )
		{
			return BadRequest("Could not update the proposal");
		}
		return Ok();
	}
	[HttpPut("update-status")]
	public ActionResult SetProposalStatus([FromBody] UpdateProjectProposalStateDto proposalState)
	{
		_projectProposalService.SetProposalState(proposalState);
		if (!_projectProposalService.SaveChanges())
		{
			return BadRequest("Could not update the proposal");
		}
		return Ok();
	}
}