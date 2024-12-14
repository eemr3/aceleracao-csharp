using Microsoft.EntityFrameworkCore;
using TrybeStore.Data;
using TrybeStore.DTO;
using TrybeStore.Exceptions;
using TrybeStore.Models;

namespace TrybeStore.Repositories;

public class UserRepository : IUserRepository
{
  private readonly IDatabaseContext _context;
  public UserRepository(IDatabaseContext context)
  {
    _context = context;
  }
  public async Task<User> AddUserAsync(User user)
  {
    var userExists = await _context.Users.Where(u => u.Email == user.Email).FirstOrDefaultAsync();

    if (userExists != null) throw new ConflictException("A user with this email already exists.");

    var userCreated = await _context.Users.AddAsync(user);
    await _context.SaveChangesAsync();

    return userCreated.Entity;
  }

  public async Task<User> GetuserByEmailAsync(string email)
  {
    var user = await _context.Users.Where(user => user.Email == email).FirstOrDefaultAsync();

    if (user == null) throw new UnauthorizedException("Email address or password provided is incorrect.");

    return user;
  }

  public async Task<UserDTO> GetUserByIdAsync(int userId)
  {
    var user = await _context.Users.Where(user => user.UserId == userId).FirstOrDefaultAsync();

    if (user == null) throw new KeyNotFoundException($"User with ID {userId} not found!");

    return new UserDTO
    {
      UserId = user.UserId,
      Name = user.Name,
      Email = user.Email,
      Access = user.Access
    };
  }
}