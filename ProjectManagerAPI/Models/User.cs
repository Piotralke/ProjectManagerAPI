﻿using ProjectManagerAPI.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerAPI.Models
{
	public class User
	{
		[Key]
		public Guid uuid { get; set; }
		public string name { get; set; }
		public string surname { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public DateTime createdAt { get; set; }
		public Role role { get; set; }
		public Project? project { get; set; }

		public ICollection<ProjectMembers> members { get; set; }
		public ICollection<UserEvents> events { get; set; }

		public User() {
			uuid = Guid.NewGuid();
		}
	}
}
