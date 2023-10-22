using System;
using System.Collections.Generic;
using ProjectManagerAPI.Models;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }

    public User GetUserById(Guid userId)
    {
        return _userRepository.GetUserById(userId);
    }

    public void AddUser(User user)
    {
        _userRepository.AddUser(user);
    }

    public void UpdateUser(User user)
    {
        _userRepository.UpdateUser(user);
    }

    public void DeleteUser(Guid userId)
    {
        _userRepository.DeleteUser(userId);
    }

    public bool SaveChanges()
    {
        return _userRepository.SaveChanges();
    }
}
