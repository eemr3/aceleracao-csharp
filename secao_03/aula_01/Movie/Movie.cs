namespace Movie
{
  public class Movie
  {
    private string _category;

    public string Title { get; set; }
    public string Category
    {
      get
      {
        return Category = $"Categoria: {_category}";
      }

      set
      {
        if (value != "Fantasia" && value != "Ficção científica")
        {
          throw new Exception("Categoria não permitida!");
        }

        _category = value;
      }
    }

    public Movie(string title, string category)
    {
      Title = title;
      Category = category;
    }
  }
}