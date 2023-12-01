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
				.WithOrigins("http://localhost:5048")  // Zaktualizuj na odpowiedni¹ adresy stron, z których bêdziesz korzystaæ
				.AllowAnyHeader()
				.AllowAnyMethod());
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
			options.DefaultScheme = IdentityConstants.ApplicationScheme;
		})
		.AddJwtBearer(options =>
		{
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = "ProjectManagerBE",
				ValidAudience = "ProjectManagerFE",
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenSecret"]))
			};
		});

		builder.Services.AddScoped<IUserService, UserService>();
		builder.Services.AddScoped<IUserRepository, UserRepository>();
		builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
		builder.Services.AddScoped<IProjectService, ProjectService>();
		builder.Services.AddScoped<IProjectMembersRepository, ProjectMembersRepository>();
		builder.Services.AddScoped<IAuthService, AuthService>();

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




