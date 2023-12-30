using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Data
{
	public class ApplicationDbContext : IdentityDbContext<User,IdentityRole<Guid>, Guid>
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
				.WithMany(u => u.messages)
				.HasForeignKey(m => m.senderUuid)
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

			modelBuilder.Entity<User>()
				.HasMany(u => u.projectNotes)
				.WithOne(n => n.user)
				.HasForeignKey(n => n.userUuid);

			modelBuilder.Entity<Project>()
				.HasMany(p=>p.notes)
				.WithOne(n => n.project)
				.HasForeignKey(n=>n.projectUuid);

			modelBuilder.Entity<User>()
				.HasOne(u => u.pinnedProject)
				.WithMany(p => p.pinnedUsers)
				.HasForeignKey(u => u.pinnedProjectUuid);

			modelBuilder.Entity<Group>()
				.HasMany(g => g.members)
				.WithOne(m => m.group)
				.HasForeignKey(m => m.groupUuid);

			modelBuilder.Entity<Group>()
				.HasMany(g => g.subjects)
				.WithOne(s => s.group)
				.HasForeignKey(s => s.groupUuid);

			modelBuilder.Entity<User>()
				.HasMany(u => u.groupMembers)
				.WithOne(g => g.user)
				.HasForeignKey(g => g.userUuid);

			modelBuilder.Entity<User>()
				.HasMany(t => t.subjects)
				.WithOne(s => s.teacher)
				.HasForeignKey(s => s.teacherUuid);

			modelBuilder.Entity<ProjectProposal>()
				.HasOne(p => p.subject)
				.WithMany(s => s.proposals)
				.HasForeignKey(p => p.subjectUuid);

			modelBuilder.Entity<ProjectProposal>()
				.HasMany(p => p.proposalSquad)
				.WithOne(s => s.projectProposal)
				.HasForeignKey(s => s.projectProposalUuid);
			modelBuilder.Entity<ProposalSquad>()
				.HasOne(p => p.user)
				.WithMany(u => u.proposalSquads)
				.HasForeignKey(p => p.userUuid);
			//modelBuilder.Entity<User>()
			//	.Property(u => u.Id)
			//	.HasColumnName("uuid")
			//	.HasConversion<StringToGuidConverter>();

			//modelBuilder.Entity<User>()
			//	.HasKey(u => u.uuid)
			//	.HasName("PK_User");


			base.OnModelCreating(modelBuilder);

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
		public DbSet<UserProjectNote> ProjectNotes { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<GroupMembers> GroupMembers { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<ProjectProposal> Proposals { get; set; }
		public DbSet<ProposalSquad> ProposalsSquad { get; set;}
    }
}
