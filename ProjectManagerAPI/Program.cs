using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProjectManagerAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ProjectManagerAPI.Models;
using ProjectManagerAPI.Services;
using ProjectManagerAPI.Repositories;
using ProjectManagerAPI.Services.Auth;

public class Program
{
	public static async Task Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddControllers();

		builder.Services.AddDbContext<ApplicationDbContext>(options =>
		{
			options.UseNpgsql(builder.Configuration["ConnectionString"]);
		});
		builder.Services.AddCors(options =>
		{
			options.AddDefaultPolicy(builder => builder
				.WithOrigins("http://localhost:5048", "http://localhost:5173")  // Zaktualizuj na odpowiedni¹ adresy stron, z których bêdziesz korzystaæ
				.AllowAnyHeader()
				.AllowAnyMethod()
				.AllowCredentials()
				.SetIsOriginAllowed(origin=>true)
				.SetIsOriginAllowedToAllowWildcardSubdomains()
				
				);	
		});
		builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
		{
			// Konfiguracje opcji Identity
		})
		.AddEntityFrameworkStores<ApplicationDbContext>()
		.AddDefaultTokenProviders();

		builder.Services.AddAuthentication(options =>
		{
			options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
		})
		.AddJwtBearer(options =>
		{
			options.SaveToken = true;
			options.RequireHttpsMetadata = false;
			options.TokenValidationParameters = new TokenValidationParameters()
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidIssuer = "http://localhost:5048",
				ValidAudience = "http://localhost:5173",
				ClockSkew = TimeSpan.Zero,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenSecret"]))
			};
		});
		

		builder.Services.AddScoped<IUserService, UserService>();
		builder.Services.AddScoped<IUserRepository, UserRepository>();
		builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
		builder.Services.AddScoped<IProjectService, ProjectService>();
		builder.Services.AddScoped<IProjectMembersRepository, ProjectMembersRepository>();
		builder.Services.AddScoped<IAuthService, AuthService>();
		builder.Services.AddScoped<IUserProjectNoteRepository, UserProjectNoteRepository>();
		builder.Services.AddScoped<IUserProjectNoteService, UserProjectNoteService>();
		builder.Services.AddScoped<IProjectEventRepository, ProjectEventRepository>();
		builder.Services.AddScoped<IProjectEventService, ProjectEventService>();
		builder.Services.AddScoped<IUserEventsRepository, UserEventsRepository>();
		builder.Services.AddScoped<IUserEventService, UserEventService>();
		builder.Services.AddScoped<IMessageRepository,MessageRepository>();
		builder.Services.AddScoped<IMessageAttachmentRepository,MessageAttachmentRepository>();
		builder.Services.AddScoped<IMessageService, MessageService>();
		

		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseAuthentication();
		app.UseAuthorization();
		app.UseCors();
		app.MapControllers();

		// Inicjalizacja bazy danych
		using (var scope = app.Services.CreateScope())
		{
			var services = scope.ServiceProvider;
			var context = services.GetRequiredService<ApplicationDbContext>();
			var userManager = services.GetRequiredService<UserManager<User>>();
			var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

			// Inicjalizacja bazy danych
			await context.Database.MigrateAsync();

			// Seeder dla roli
			await ApplicationDbInitializer.Initialize(context, userManager, roleManager);
		}


		app.Run();
	}
}




