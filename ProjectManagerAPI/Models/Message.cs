using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Models
{
	public class Message
	{
		[Key]
		public Guid uuid { get; set; }
		public string content { get; set; }
		[Required]
		public bool hasAttachment { get; set; }
		public Project project { get; set; }
		public Guid projectUuid { get; set; }
		public User sender { get; set; }
		public Guid senderUuid { get; set; }

		public ICollection<MessageAttachment> ? messageAttachment { get; set; }
	}
}
