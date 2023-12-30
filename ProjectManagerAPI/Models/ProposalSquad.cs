using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Models
{
	public class ProposalSquad
	{
		[Key]
		public Guid uuid { get; set; }
		public ProjectProposal projectProposal { get; set; }
		public Guid projectProposalUuid { get; set; }
		public Guid userUuid { get; set; }
		public User user { get; set; }
	}
}
