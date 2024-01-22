using Microsoft.IdentityModel.Tokens;
using ProjectManagerAPI.Data.Enum;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

public class ProjectProposalService : IProjectProposalService
{
	private readonly IProjectProposalRepository _projectProposalRepository;

	public ProjectProposalService(IProjectProposalRepository projectProposalRepository)
	{
		_projectProposalRepository = projectProposalRepository;
	}

	public IEnumerable<ProjectProposal> GetAllProjectProposals()
	{
		return _projectProposalRepository.GetAllProjectProposals();
	}

	public ProjectProposal GetProjectProposalById(Guid proposalId)
	{
		return _projectProposalRepository.GetProjectProposalById(proposalId);
	}
	public ProjectProposal GetSubjectProposalForUser(Guid subjectId, Guid userId)
	{
		return _projectProposalRepository.GetSubjectProposalForUser(subjectId, userId);
	}
	public IEnumerable<ProjectProposal> GetProjectProposalsBySubject(Guid subjectId)
	{
		return _projectProposalRepository.GetProjectProposalsBySubject(subjectId);
	}
	public IEnumerable<ProjectProposal> GetAllTeacherProposals(Guid teacherId)
	{
		return _projectProposalRepository.GetAllTeacherProposals(teacherId);
	}
	public IEnumerable<ProposalSquad> GetProposalSquadsByProjectProposal(Guid projectProposalId)
	{
		return _projectProposalRepository.GetProposalSquadsByProjectProposal(projectProposalId);
	}
	public void AddProjectProposalSquad(ProposalSquad proposalSquad)
	{
		_projectProposalRepository.AddProjectProposalSquad(proposalSquad);
	}
	public void AddProjectProposal(ProjectProposal proposal)
	{
		_projectProposalRepository.AddProjectProposal(proposal);
	}
	public void SetProposalState(UpdateProjectProposalStateDto proposalState)
	{
		var proposalToUpdate = GetProjectProposalById(proposalState.uuid);
		if (proposalToUpdate == null)
		{
			throw new Exception("Could not find project with given ID");
		}
		proposalToUpdate.state = proposalState.state;
		_projectProposalRepository.UpdateProjectProposal(proposalToUpdate);
	}
	public void UpdateProjectProposal(UpdateProjectProposalDto proposal)
	{
		var proposalToUpdate = GetProjectProposalById(proposal.uuid);
		if(proposalToUpdate == null)
		{
			throw new Exception("Could not find project with given ID");
		}
		proposalToUpdate.title = proposal.title;
		proposalToUpdate.description = proposal.description;
		proposalToUpdate.state = ProjectManagerAPI.Data.Enum.ProposalState.EDITED;
		proposalToUpdate.editedAt = DateTime.UtcNow;
		_projectProposalRepository.UpdateProposalSquad(proposal.MembersIds, proposal.uuid);
		_projectProposalRepository.UpdateProjectProposal(proposalToUpdate);
	}

	public void DeleteProjectProposal(Guid proposalId)
	{
		_projectProposalRepository.DeleteProjectProposal(proposalId);
	}

	public bool SaveChanges()
	{
		return _projectProposalRepository.SaveChanges();
	}
}