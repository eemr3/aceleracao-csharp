using ContactList.Data;
using ContactList.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Repositories;
public class ContactRepository : IContactRepository
{
  private readonly ContactDbContext _context;

  public ContactRepository(ContactDbContext context)
  {
    _context = context;
  }

  public async Task<Contact> AddContact(Contact contact)
  {
    await _context.Contacts.AddAsync(contact);
    await _context.SaveChangesAsync();

    return contact;
  }

  public async Task DeleteContact(int ContactId)
  {
    var contactExists = await _context.Contacts.FirstOrDefaultAsync(c => c.ContactId == ContactId);

    if (contactExists is null) throw new KeyNotFoundException($"Contact with ID {ContactId} not found!");

    _context.Contacts.Remove(contactExists);

    await _context.SaveChangesAsync();
  }

  public async Task<IEnumerable<Contact>> GetContacts()
  {
    return await _context.Contacts.ToListAsync();
  }

  public async Task<Contact> UpdateContact(Contact contact)
  {
    var contactExists = await _context.Contacts.FindAsync(contact.ContactId);

    if (contactExists is null) throw new KeyNotFoundException($"Contact with ID {contact.ContactId} not found!");

    _context.Contacts.Entry(contactExists).CurrentValues.SetValues(contact);
    await _context.SaveChangesAsync();

    return contactExists;
  }
}