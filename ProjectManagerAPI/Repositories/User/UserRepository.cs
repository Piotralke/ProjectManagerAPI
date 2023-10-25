using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Npgsql.Internal.TypeHandlers;
using ProjectManagerAPI.Data; // Dodaj odpowiednią przestrzeń nazw związana z kontekstem bazy danych
using ProjectManagerAPI.Dtos;
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
        return _context.Users.ToList();
	}

    public User GetUserById(Guid userId)
    {
        var user = _context.Users.FirstOrDefault(u => u.uuid == userId);
        if(user == null) 
        {
            throw new Exception("User not found");
        }
        return user;
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
