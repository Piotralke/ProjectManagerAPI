using Microsoft.AspNetCore.Identity;
using ProjectManagerAPI.Data;

public static class ApplicationDbInitializer
{
	public static async Task Initialize(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
	{
		context.Database.EnsureCreated();

		// Dodaj role
		string[] roleNames = { "ADMIN", "STUDENT", "TEACHER" };

		IdentityResult roleResult;

		foreach (var roleName in roleNames)
		{
			var roleExist = await roleManager.RoleExistsAsync(roleName);
			if (!roleExist)
			{
				// Stworz nową rolę
				roleResult = await roleManager.CreateAsync(new IdentityRole<Guid>(roleName));
			}
		}
	}
}
