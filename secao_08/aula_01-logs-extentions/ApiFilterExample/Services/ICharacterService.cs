using ApiFilterExample.Models;

namespace ApiFilterExample.Services;

public interface ICharacterService
{
  public List<Character> GetCharacters();
  public Character GetCharacterById(int id);
}