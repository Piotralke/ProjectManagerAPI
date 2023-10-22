using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectManagerAPI.Data; // Dodaj odpowiednią przestrzeń nazw związana z kontekstem bazy danych
using ProjectManagerAPI.Models;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _context.Users.Include(u => u.project).ToList();
    }

    public User GetUserById(Guid userId)
    {
        return _context.Users.Include(u => u.project)
                             .FirstOrDefault(u => u.uuid == userId);
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
    }

    public void UpdateUser(User user)
    {
        _context.Users.Update(user);
    }

    public void DeleteUser(Guid userId)
    {
        var user = _context.Users.FirstOrDefault(u => u.uuid == userId);
        if (user != null)
        {
            _context.Users.Remove(user);
        }
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() > 0;
    }
}
