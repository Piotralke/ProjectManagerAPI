using System;
using System.Collections.Generic;
using ProjectManagerAPI.Models;
public interface IUserRepository
{
    IEnumerable<User> GetAllUsers();
    User GetUserById(Guid userId);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(Guid userId);
    bool SaveChanges();
}