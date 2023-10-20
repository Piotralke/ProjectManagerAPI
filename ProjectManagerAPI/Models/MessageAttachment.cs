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
	}
}
