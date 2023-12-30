﻿using Microsoft.EntityFrameworkCore;
using ProjectManagerAPI.Data;
using ProjectManagerAPI.Models;

public class ProjectProposalRepository : IProjectProposalRepository
{
	private readonly ApplicationDbContext _context;

	public ProjectProposalRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public IEnumerable<ProjectProposal> GetAllProjectProposals()
	{
		return _context.ProjectProposals
			.Include(p => p.subject)
			.Include(p => p.proposalSquad)
			.ToList();
	}

	public ProjectProposal GetProjectProposalById(Guid proposalId)
	{
		return _context.ProjectProposals
			.Include(p => p.subject)
			.Include(p => p.proposalSquad)
			.FirstOrDefault(p => p.uuid == proposalId);
	}

	public IEnumerable<ProjectProposal> GetProjectProposalsBySubject(Guid subjectId)
	{
		return _context.ProjectProposals
			.Include(p => p.subject)
			.Include(p => p.proposalSquad)
			.Where(p => p.subjectUuid == subjectId)
			.ToList();
	}
	public IEnumerable<ProposalSquad> GetProposalSquadsByProjectProposal(Guid projectProposalId)
	{
		return _context.ProposalSquads
			.Include(ps => ps.user)
			.Where(ps => ps.projectProposalUuid == projectProposalId)
			.ToList();
	}
	public void AddProjectProposalSquad(ProposalSquad proposalSquad)
	{
		_context.ProposalSquads.Add(proposalSquad);
	}
	public void AddProjectProposal(ProjectProposal proposal)
	{
		_context.ProjectProposals.Add(proposal);
	}

	public void UpdateProjectProposal(ProjectProposal proposal)
	{
		_context.ProjectProposals.Update(proposal);
	}

	public void DeleteProjectProposal(Guid proposalId)
	{
		var proposal = _context.ProjectProposals.FirstOrDefault(p => p.uuid == proposalId);
		if (proposal != null)
		{
			_context.ProjectProposals.Remove(proposal);
		}
	}

	public bool SaveChanges()
	{
		return _context.SaveChanges() > 0;
	}
}