using ProjectManagerAPI.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Models
{
	public class MessageAttachment
	{
		[Key]
		public Guid uuid { get; set; }
		public string fileName { get; set; }
		public string fileType { get; set; }
	    public string filePath { get; set; }
		public Message message { get; set; }
		public Guid messageUuid { get; set; }
		public MessageAttachment() { }
		public MessageAttachment(MessageAttachmentDto messageDto, Guid messageId)
		{
			uuid = messageDto.uuid;
			fileName = messageDto.fileName;
			fileType = messageDto.fileType;
			filePath = messageDto.filePath;
			messageUuid = messageId;
		}
	}
}
