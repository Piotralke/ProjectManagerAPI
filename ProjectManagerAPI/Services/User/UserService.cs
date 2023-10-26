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
			UserDto userDto = new UserDto(user);
			result.Add(userDto);
		}
        return result;

	}
	public User GetFullUserByUuid(Guid userId)
	{
		return _userRepository.GetUserById(userId);
	}
	public UserDto GetUserById(Guid userId)
    {
        var user = _userRepository.GetUserById(userId);
		UserDto userDto = new UserDto(user);
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
		return new UserDto(newUser);
    }

    public void UpdateUser(User user, UpdateUserDto updatedUser)
    {
		user.name = updatedUser.name;
		user.surname = updatedUser.surname;

		if(updatedUser.newPassword!= null)
		{
			user.password = updatedUser.newPassword;
		}
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
