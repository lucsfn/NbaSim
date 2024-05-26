using System;

class Program
{
    public static void Main(string[] args)
    {

        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");

        Console.WriteLine("Bem vindo ao simulador de carreira NBA!");

        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");

        // Função para obter o nome do jogador
        string playerName = GetPlayerName();
        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");

        // Array dos times da Nba
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

        // Variáveis a serem utilizadas na função Draft
        int PickDraft = 0;
        string NbaTeamSelected = "";

        // Função Draft
        string DraftInfos = Draft(ref PickDraft, ref NbaTeamSelected, AllNbaTeams, playerName);

        Console.WriteLine(DraftInfos);

        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");

        int TeamRookieForce = ForceRookieTeam();

        int rookieGamesPlayed = 0,
            rookiePPG = 0,
            rookieRPG = 0,
            rookieAPG = 0;

        bool ROY = false;

        RookieYear(ref TeamRookieForce, ref rookieGamesPlayed, ref rookiePPG, ref rookieRPG, ref rookieAPG, ref ROY);

    }

    public static string GetPlayerName() 
    {
        string PlayerName = "";
#pragma warning disable CS8600
        
        do 
        {
            Console.WriteLine("Qual nome do seu jogador?");
            PlayerName = Console.ReadLine();

            if (PlayerName == null) PlayerName = "";
#pragma warning restore CS8600

        } while (string.IsNullOrEmpty(PlayerName));
        

        return PlayerName;
    }

    public static string Draft (ref int PickDraft, ref string NbaTeamSelected, string [] AllNbaTeams, string playerName)
    {
        Random random = new Random();

        PickDraft = random.Next(1,31);
        NbaTeamSelected = AllNbaTeams[random.Next(0,30)];

        string Draft = $"O jogador {playerName} foi escolhido pelo {NbaTeamSelected} na {PickDraft}º escolha.";

        return Draft;
    } 

    public static int ForceRookieTeam(string NbaTeamSelected)
    {
        int pos = 0;
        int forceValue = 0;

        string[] TeamsClassification = {
            // Primeiro Escalão
            "Boston Celtics", "New York Knicks", "Milwaukee Bucks", "Cleveland Cavaliers", "Orlando Magic", 
            "Indiana Pacers", "Philadelphia 76ers", "Miami Heat", "Chicago Bulls", "Atlanta Hawks",
            // Segundo Escalão
            "Brooklyn Nets", "Toronto Raptors", "Charlotte Hornets", "Washington Wizards", "Detroit Pistons", 
            "Oklahoma City Thunder", "Denver Nuggets", "Minnesota Timberwolves", "LA Clippers", "Dallas Mavericks",
            // Terceiro Escalão
            "Phoenix Suns", "New Orleans Pelicans", "Los Angeles Lakers", "Sacramento Kings", "Golden State Warriors", 
            "Houston Rockets", "Utah Jazz", "Memphis Grizzlies", "San Antonio Spurs", "Portland Trail Blazers"
        };

        for (int i = 0; i < TeamsClassification.Length; i++)
        {
            if (NbaTeamSelected == TeamsClassification[i])
            {
                pos = i+1;
            }
        }

        if (pos <= 10)
        {
            forceValue = 1;
        }
        else if (pos <= 20)
        {
            forceValue = 2;
        } else
        {
            forceValue = 3;
        }

        return forceValue;

    }

    public static void RookieYear(ref int TeamRookieForce, ref int rookieGamesPlayed, ref int rookiePPG, ref int rookieRPG, ref int rookieAPG, ref bool ROY)
    {
        Random random = new Random();
    }
}
