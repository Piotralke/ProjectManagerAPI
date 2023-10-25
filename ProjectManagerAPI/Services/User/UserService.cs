using System;
using System.Collections.Generic;
using ProjectManagerAPI.Dtos;
using ProjectManagerAPI.Models;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IEnumerable<UserDto> GetAllUsers()
    {
        var users = _userRepository.GetAllUsers();
		List<UserDto> result = new List<UserDto>();
		foreach (var user in users)
		{
			UserDto userDto = new UserDto
			{
				uuid = user.uuid,
				name = user.name,
				surname = user.surname,
				email = user.email,
				createdAt = user.createdAt,
				role = user.role
			};
			result.Add(userDto);
		}
        return result;

	}

    public UserDto GetUserById(Guid userId)
    {
        var user = _userRepository.GetUserById(userId);
		UserDto userDto = new UserDto
		{
			uuid = user.uuid,
			name = user.name,
			surname = user.surname,
			email = user.email,
			createdAt = user.createdAt,
			role = user.role
		};
		return userDto;
    }

    public UserDto AddUser(CreateUserDto user)
    {
		User newUser = new User
		{
			uuid = Guid.NewGuid(),
			name = user.name,
			surname = user.surname,
			password = user.password,
			email = user.email,
			role = user.role,
			createdAt = DateTime.UtcNow
		};
		_userRepository.AddUser(newUser);
		return new UserDto { 
			uuid = newUser.uuid,
			name = newUser.name,
			surname=newUser.surname,
			email = newUser.email,
			role = newUser.role,
			createdAt = DateTime.UtcNow
		};
    }

    public void UpdateUser(UserDto user)
    {
		User updatedUser = new User
		{
			uuid = user.uuid,
			name = user.name,
			surname = user.surname,
			email = user.email,
			role = user.role,
			createdAt = user.createdAt
		};
		_userRepository.UpdateUser(updatedUser);
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
