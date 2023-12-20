using ProjectManagerAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Dtos
{
	public class MessageDto
	{
		public Guid uuid { get; set; }
		public string content { get; set; }
		public bool hasAttachment { get; set; }
		public Guid projectUuid { get; set; }
		public Guid senderUuid { get; set; }
		public DateTime createdAt { get; set; }
		public UserDto sender { get; set; }
		public ICollection<MessageAttachmentDto>? messageAttachments { get; set; }
	}
	public class CreateMessageDto
	{
        public string content { get; set; }
        public bool hasAttachment { get; set; }
        public Guid projectUuid { get; set; }
        public Guid senderUuid { get; set; }
	}
	public class MessageAttachmentDto
	{
		public Guid uuid { get; set; }
		public string fileName { get; set; }
		public string fileType { get; set; }
		public string filePath { get; set; }
	}
}
