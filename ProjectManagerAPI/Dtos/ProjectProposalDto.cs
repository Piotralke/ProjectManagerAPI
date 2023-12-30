using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Dtos
{
	public class CreateProjectProposalDto
	{
		[Required]
		public Guid SubjectUuid { get; set; }

		[Required]
		public string Title { get; set; }

		public string Description { get; set; }
		public List<Guid> MembersIds { get; set; }
		// ... inne pola, jeśli są wymagane przy tworzeniu propozycji projektu
	}
}
