using ApiFilterExample.Models;


namespace MyApp.Database
{
  public class CharacterDatabase
  {
    private List<Character> _characters;

    public CharacterDatabase()
    {
      // Inicializando a "base de dados"
      _characters = new List<Character>
            {
                new Character { Id = 1, Name = "Invoker", Tag = "Mage" },
                new Character { Id = 2, Name = "Juggernaut", Tag = "Carry" },
                new Character { Id = 3, Name = "Axe", Tag = "Tank" },
                new Character { Id = 4, Name = "Sniper", Tag = "Ranged" },
                new Character { Id = 5, Name = "Crystal Maiden", Tag = "Support" },
                new Character { Id = 6, Name = "Pudge", Tag = "Hooker" },
                new Character { Id = 7, Name = "Phantom Assassin", Tag = "Assassin" },
                new Character { Id = 8, Name = "Tiny", Tag = "Nuker" },
                new Character { Id = 9, Name = "Tinker", Tag = "Pusher" },
                new Character { Id = 10, Name = "Spectre", Tag = "Late-Game" }
            };
    }

    public List<Character> CharactersData => _characters;
  }
}
