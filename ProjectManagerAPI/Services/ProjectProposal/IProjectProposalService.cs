using ProjectManagerAPI.Data.Enum;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

public interface IProjectProposalService
{
	IEnumerable<ProjectProposal> GetAllProjectProposals();
	ProjectProposal GetProjectProposalById(Guid proposalId);
	ProjectProposal GetSubjectProposalForUser(Guid subjectId, Guid userId);
	IEnumerable<ProjectProposal> GetAllTeacherProposals(Guid teacherId);
	IEnumerable<ProjectProposal> GetProjectProposalsBySubject(Guid subjectId);
	IEnumerable<ProposalSquad> GetProposalSquadsByProjectProposal(Guid projectProposalId);
	void AddProjectProposalSquad(ProposalSquad proposalSquad);
	void AddProjectProposal(ProjectProposal proposal);
	void UpdateProjectProposal(UpdateProjectProposalDto proposal);
	void SetProposalState(UpdateProjectProposalStateDto proposalState);
	void DeleteProjectProposal(Guid proposalId);
	bool SaveChanges();
}