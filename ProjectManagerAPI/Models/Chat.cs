using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Models
{
	public class Chat
	{
		[Key]
		public Guid uuid { get; set; }
		public User? memberOne { get; set; }
		public Guid? memberOneUuid { get; set; }
        public User? memberTwo { get; set; }
        public Guid? memberTwoUuid { get; set; }
		[Required]
		public bool isGroupChat { get; set; }
		public Project? project { get; set; }
		public Guid? projectUuid { get; set; }

		public ICollection<Message> messages { get; set; }
    }
}
