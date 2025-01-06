using ApiFilterExample.Models;
using ApiFilterExample.Services;
using MyApp.Database;

namespace ApiFilterExample.Services;
public class CharacterService : ICharacterService
{
  private readonly CharacterDatabase _database;

  public CharacterService(CharacterDatabase database)
  {
    _database = database;
  }
  public Character GetCharacterById(int id)
  {
    var character = _database.CharactersData.Find(c => c.Id == id);

    if (character == null) throw new KeyNotFoundException("Character not found!");

    return character;

  }

  public List<Character> GetCharacters()
  {
    return _database.CharactersData.ToList();
  }
}