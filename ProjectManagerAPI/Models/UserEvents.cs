using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Models
{
	public class UserEvents
	{
		[Key]
		public Guid uuid { get; set; }
		public ProjectEvents projectEvents { get; set; }
		public Guid eventUuid { get; set; }
		public User user { get; set; }
		public Guid userUuid { get; set; }

	}
}
