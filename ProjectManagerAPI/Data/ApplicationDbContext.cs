using Microsoft.EntityFrameworkCore;
using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Data
{
	public class ApplicationDbContext : DbContext
	{

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                        
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Project>()
                .HasOne(p => p.owner)
                .WithMany(u => u.projects)
                .HasForeignKey(p => p.ownerUuid)
                .IsRequired();

			modelBuilder.Entity<Project>()
				.HasMany(p => p.events)
				.WithOne(e => e.project)
				.HasForeignKey(e => e.projectUuid)
				.IsRequired();


			//modelBuilder.Entity<ProjectMembers>()
			//	.HasKey(pm => new { pm.projectUuid, pm.userUuid }); // Definiuje klucz główny dla tabeli łączącej ???

			modelBuilder.Entity<ProjectMembers>()
				.HasOne(pm => pm.project)
				.WithMany(p => p.members)
				.HasForeignKey(pm => pm.projectUuid); // Definiuje relację między ProjectMember i Project

			modelBuilder.Entity<ProjectMembers>()
				.HasOne(pm => pm.user)
				.WithMany(u => u.members)
				.HasForeignKey(pm => pm.userUuid); // Definiuje relację między ProjectMember i User

			modelBuilder.Entity<UserEvents>()
				.HasOne(ue => ue.projectEvents)
				.WithMany(p => p.userEvents)
				.HasForeignKey(ue => ue.eventUuid);

			modelBuilder.Entity<UserEvents>()
				.HasOne(ue => ue.user)
				.WithMany(p => p.events)
				.HasForeignKey(ue => ue.userUuid);

			modelBuilder.Entity<Message>()
				.HasOne(m => m.sender)
				.WithOne(u => u.message)
				.HasForeignKey<Message>(m => m.senderUuid)
				.IsRequired();

			modelBuilder.Entity<Message>()
				.HasOne(m => m.project)
				.WithMany(c => c.messages)
				.HasForeignKey(m => m.projectUuid)
				.IsRequired();

			modelBuilder.Entity<MessageAttachment>()
				.HasOne(a => a.message)
				.WithMany(m => m.messageAttachment)
				.HasForeignKey(a => a.messageUuid);

			modelBuilder.Entity<GanntTasks>()
				.HasOne(g => g.project)
				.WithMany(p => p.tasks)
				.HasForeignKey(g => g.projectUuid);

			modelBuilder.Entity<GanntPreviousTask>()
				.HasOne(p => p.previousTask)
				.WithMany(g => g.previousTasks)
				.HasForeignKey(p => p.previousTaskId);

			modelBuilder.Entity<GanntPreviousTask>()
				.HasOne(p => p.task)
				.WithMany()
				.HasForeignKey(p => p.taskId);

		}
		public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
		public DbSet<ProjectMembers> ProjectMembers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageAttachment> MessageAttachments { get; set; }
		public DbSet<GanntTasks> GanntTasks { get; set;}
		public DbSet<ProjectEvents> ProjectEvents { get; set; }
		public DbSet<UserEvents> UserEvents { get; set; }
        public DbSet<GanntPreviousTask> GanntPreviousTasks { get; set; }

    }
}
