using AuthService.Data;
using AuthService.Exceptions;
using AuthService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Repositories;

public class UserRepository : IUserRepository
{
  private readonly AppDBContext _context;

  public UserRepository(AppDBContext context)
  {
    _context = context;
  }

  public async Task<User> AddUserAsync(User user)
  {
    var userExists = await _context.Users.FirstOrDefaultAsync(usr => usr.Email.Equals(user.Email));

    if (userExists is not null) throw new ConflictException($"O usuário com o email {user.Email} já esta cadastrado");

    var userAdd = await _context.Users.AddAsync(user!);
    await _context.SaveChangesAsync();

    return userAdd.Entity;
  }

  public async Task<User?> GetUserByEmailAsync(string email)
  {
    var user = await _context.Users.FirstOrDefaultAsync(user => user.Email.Equals(email));

    if (user is null) return null;

    return user;
  }

  public async Task<User?> GetUserByIdAsync(int userId)
  {
    var user = await _context.Users.FindAsync(userId);

    if (user is null) return null;

    return user;
  }

  public async Task<User?> UpdateUserAsync(User user)
  {
    var userExists = await _context.Users.FindAsync(user.UserId);

    if (userExists is null) return null;

    _context.Entry(userExists).State = EntityState.Detached;

    _context.Users.Update(userExists);

    await _context.SaveChangesAsync();

    return user;
  }
}