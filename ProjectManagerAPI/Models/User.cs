using Microsoft.AspNetCore.Identity;
using ProjectManagerAPI.Models;

public class User : IdentityUser<Guid>
{
	public string name { get; set; }
	public string surname { get; set; }
	public DateTime createdAt { get; set; }
	public ICollection<Project>? projects { get; set; }
	public ICollection<ProjectMembers> members { get; set; }
	public ICollection<UserEvents> events { get; set; }
	public ICollection<Message> messages { get; set; }
	public Message? message { get; set; }
	public string ProfilePicturePath { get; set; } = "default.jpeg";
}
