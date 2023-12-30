using ProjectManagerAPI.Models;

public interface IProjectProposalRepository
{
	IEnumerable<ProjectProposal> GetAllProjectProposals();
	ProjectProposal GetProjectProposalById(Guid proposalId);
	IEnumerable<ProjectProposal> GetProjectProposalsBySubject(Guid subjectId);
	IEnumerable<ProposalSquad> GetProposalSquadsByProjectProposal(Guid projectProposalId);
	void AddProjectProposalSquad(ProposalSquad proposalSquad);
	void AddProjectProposal(ProjectProposal proposal);
	void UpdateProjectProposal(ProjectProposal proposal);
	void DeleteProjectProposal(Guid proposalId);
	bool SaveChanges();
}