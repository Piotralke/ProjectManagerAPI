using ProjectManagerAPI.Data.Enum;

namespace ProjectManagerAPI.Dtos
{
	public class UpdateProjectProposalDto
	{
		public Guid uuid { get; set; }
		public string? title { get; set; }
		public string? description { get; set; }
		public ProposalState state { get; set; }
	}
}
