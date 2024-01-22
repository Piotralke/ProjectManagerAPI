using ProjectManagerAPI.Models;

public interface IProjectProposalRepository
{
	IEnumerable<ProjectProposal> GetAllProjectProposals();
	ProjectProposal GetProjectProposalById(Guid proposalId);
	ProjectProposal GetSubjectProposalForUser(Guid subjectId, Guid userId);
	IEnumerable<ProjectProposal> GetProjectProposalsBySubject(Guid subjectId);
	IEnumerable<ProjectProposal> GetAllTeacherProposals(Guid teacherId);
	IEnumerable<ProposalSquad> GetProposalSquadsByProjectProposal(Guid projectProposalId);
	void UpdateProposalSquad(List<Guid> memberIds, Guid proposalId);
	void AddProjectProposalSquad(ProposalSquad proposalSquad);
	void AddProjectProposal(ProjectProposal proposal);
	void UpdateProjectProposal(ProjectProposal proposal);
	void DeleteProjectProposal(Guid proposalId);
	bool SaveChanges();
}