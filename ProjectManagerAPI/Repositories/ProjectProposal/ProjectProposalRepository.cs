using Microsoft.EntityFrameworkCore;
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
	public ProjectProposal GetSubjectProposalForUser(Guid subjectId, Guid userId)
	{
		var proposal = _context.ProjectProposals
			.Include(p => p.proposalSquad)
			.ThenInclude(ps => ps.user)
			.FirstOrDefault(p => p.subjectUuid == subjectId &&
								 p.proposalSquad.Any(ps => ps.userUuid == userId));

		return proposal;
	}
	public IEnumerable<ProjectProposal> GetProjectProposalsBySubject(Guid subjectId)
	{
		return _context.ProjectProposals
			.Include(p => p.subject)
			.ThenInclude(s => s.group)
			.ThenInclude(g => g.group)
			.ThenInclude(gr => gr.members)
			.Include(p => p.proposalSquad)
			.ThenInclude(s=>s.user)
			.Where(p => p.subjectUuid == subjectId)
			.ToList();
	}
	public IEnumerable<ProjectProposal> GetAllTeacherProposals(Guid teacherId)
	{
		return _context.ProjectProposals
			.Include(p=>p.subject)
			.ThenInclude(s=>s.group)
			.ThenInclude(g=>g.group)
			.ThenInclude(gr=>gr.members)
			.Include(p=>p.proposalSquad)
			.ThenInclude(s => s.user)
			.Where(p=>p.subject.teacherUuid == teacherId)
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
	public void UpdateProposalSquad(List<Guid> memberIds, Guid proposalId)
	{
		var proposalSquads = _context.ProposalSquads.Where(p=>p.projectProposalUuid.Equals(proposalId)).ToList();
		_context.ProposalSquads.RemoveRange(proposalSquads);
		List<ProposalSquad> data = new List<ProposalSquad>();
		foreach(var member in  memberIds)
		{
			ProposalSquad proposalSquad = new ProposalSquad
			{
				uuid = new Guid(),
				projectProposalUuid = proposalId,
				userUuid = member
			};
			data.Add(proposalSquad);
		}
		_context.ProposalSquads.AddRange(data);
	}
	public bool SaveChanges()
	{
		return _context.SaveChanges() > 0;
	}
}