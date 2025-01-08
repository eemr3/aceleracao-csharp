using ContactList.Models;

namespace ContactList.Repositories;

public interface IContactRepository
{
  Task<IEnumerable<Contact>> GetContacts();
  Task<Contact> AddContact(Contact contact);
  Task<Contact> UpdateContact(Contact contact);
  Task DeleteContact(int ContactId);
}