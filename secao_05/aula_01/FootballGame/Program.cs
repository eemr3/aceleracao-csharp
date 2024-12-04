using FootballGame;

// Usando o operador de junção JOIN e clausua ON
class Program
{
  public static void Main(string[] args)
  {
    List<Team> teams = new List<Team>(){
      new Team{TeamId = "PAL", TeamName= "Palmeiras"},
      new Team{TeamId = "FLA", TeamName="Flamengo"},
      new Team{TeamId = "CRU", TeamName="Cruzeiro"},
      new Team{ TeamId = "INT", TeamName="Internacional"}
    };

    List<Match> matches = new List<Match>(){
      new Match{HomeTeamId = "PAL", AwayTeamId = "CRU", HomeTeamGoals = 2, AwayTeamGoals = 1},
      new Match{HomeTeamId = "INT", AwayTeamId = "FLA", HomeTeamGoals = 3, AwayTeamGoals = 0}
    };

    var matchesLinq = from match in matches
                      join homeTeam in teams
                      on match.HomeTeamId equals homeTeam.TeamId
                      join awayTeam in teams
                      on match.AwayTeamId equals awayTeam.TeamId
                      select new
                      {
                        HomeTeamName = homeTeam.TeamName,
                        AwayTeamName = awayTeam.TeamName,
                        match.HomeTeamGoals,
                        match.AwayTeamGoals
                      };

    foreach (var match in matchesLinq)
    {
      Console.WriteLine($"{match.HomeTeamName} {match.HomeTeamGoals} X {match.AwayTeamName} {match.AwayTeamGoals}");
    }
  }
}