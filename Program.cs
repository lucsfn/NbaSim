using System;

class Program
{
    public static void Main(string[] args)
    {
        // Função para obter o nome do jogador

        string playerName = GetPlayerName();

        string[] AllNbaTeams = new string[]
        {
            "Atlanta Hawks",
            "Boston Celtics",
            "Brooklyn Nets",
            "Charlotte Hornets",
            "Chicago Bulls",
            "Cleveland Cavaliers",
            "Dallas Mavericks",
            "Denver Nuggets",
            "Detroit Pistons",
            "Golden State Warriors",
            "Houston Rockets",
            "Indiana Pacers",
            "LA Clippers",
            "Los Angeles Lakers",
            "Memphis Grizzlies",
            "Miami Heat",
            "Milwaukee Bucks",
            "Minnesota Timberwolves",
            "New Orleans Pelicans",
            "New York Knicks",
            "Oklahoma City Thunder",
            "Orlando Magic",
            "Philadelphia 76ers",
            "Phoenix Suns",
            "Portland Trail Blazers",
            "Sacramento Kings",
            "San Antonio Spurs",
            "Toronto Raptors",
            "Utah Jazz",
            "Washington Wizards"
        };

        int PickDraft = 0;
        string NbaTeamSelected = "";

        Draft(ref PickDraft, ref NbaTeamSelected, AllNbaTeams, playerName);

    }

    public static string GetPlayerName() 
    {
        Console.WriteLine("Qual nome do seu jogador?");
        string PlayerName = Console.ReadLine();

        return PlayerName;
    }

    public static string Draft (ref int PickDraft, ref string NbaTeamSelected, string [] AllNbaTeams, string playerName)
    {
        Random random = new Random();

        PickDraft = random.Next(1,31);
        NbaTeamSelected = AllNbaTeams[random.Next(0,30)];

        string Draft = $"O jogador {playerName}";
    } 
}
