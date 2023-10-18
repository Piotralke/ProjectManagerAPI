using Microsoft.EntityFrameworkCore;
using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Data
{
	public class ApplicationDbContext : DbContext
	{

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                        
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        //public DbSet<UserEvents> UserEvents { get; set; }



    }
}
