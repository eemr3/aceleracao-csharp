using AuthService.Data;
using AuthService.Dto;
using AuthService.Exceptions;
using AuthService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Repositories;

public class UserRepository : IUserRepository
{
  private readonly AuthDbContext _context;

  public UserRepository(AuthDbContext context)
  {
    _context = context;
  }
  public async Task<UserDtoResponse> AddUserAsync(User user)
  {
    var userExists = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(user.Email));

    if (userExists is not null) throw new ConflictException("O usuário já foi cadastrado.");

    var userAdd = await _context.Users.AddAsync(user);
    await _context.SaveChangesAsync();

    var result = userAdd.Entity;
    return new UserDtoResponse
    {
      Id = result.Id,
      Name = result.Name,
      Email = result.Email,
      Role = result.Role
    };
  }

  public async Task<User?> GetUserByEmail(string email)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));

    if (user is null) return null;

    return user;
  }

}