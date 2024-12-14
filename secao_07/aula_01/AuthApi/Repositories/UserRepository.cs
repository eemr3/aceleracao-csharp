using AuthApi.Data;
using AuthApi.DTO;
using AuthApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Repositories;

public class UserRepository : IUserRepository
{

  private readonly IDatabaseContext _context;

  public UserRepository(IDatabaseContext context)
  {
    _context = context;
  }

  public async Task<User> AddUser(User user)
  {
    await _context.Users.AddAsync(user);
    await _context.SaveChangesAsync();
    var newUser = _context.Users.Where(u => u.UserId == user.UserId).First();

    return newUser;
  }

  public async Task<UserDTO> GetUserById(int userId)
  {
    var user = await _context.Users.Where(u => u.UserId == userId).FirstOrDefaultAsync();

    if (user == null) throw new KeyNotFoundException($"User with ID {userId} not found.");

    return new UserDTO
    {
      UserId = user.UserId,
      Name = user.Name,
      Email = user.Email,
      Access = user.Access
    };
  }

  public async Task<User> GetUserByEmail(string email)
  {
    var user = await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();

    if (user == null) throw new KeyNotFoundException();

    return user;
  }
}