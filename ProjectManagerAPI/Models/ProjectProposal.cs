using ProjectManagerAPI.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Models
{
	public class ProjectProposal
	{
		[Key]
		public Guid uuid { get; set; }
		public Guid subjectUuid { get; set; }
		public DateTime cretedAt { get; set; }
		public DateTime? editedAt { get; set; }
		public Subject subject { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public ICollection<ProposalSquad> proposalSquad { get; set; }
		public ProposalState state { get; set; }
	}
}
