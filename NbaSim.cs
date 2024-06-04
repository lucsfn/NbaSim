using System;

class NbaSim
{
    public static void Main(string[] args)
    {
        // Variáveis do Player
        string playerName = PlayerName();
        string playerPosition = PlayerPosition();
        int playerPick = PlayerPick();

        // Arrays de time
        // Array de todos times da NBA
        string[] allNbaTeams = new string[]
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
        // Array com os times da NBA na Conferência Oeste
        string[] westernNbaTeams = 
        {
            "Dallas Mavericks",
            "Denver Nuggets",
            "Golden State Warriors",
            "Houston Rockets",
            "LA Clippers",
            "Los Angeles Lakers",
            "Memphis Grizzlies",
            "Minnesota Timberwolves",
            "New Orleans Pelicans",
            "Oklahoma City Thunder",
            "Phoenix Suns",
            "Portland Trail Blazers",
            "Sacramento Kings",
            "San Antonio Spurs",
            "Utah Jazz"
        };
        // Array com os times da NBA na Conferência Leste
        string[] easternNbaTeams =
        {
            "Atlanta Hawks",
            "Boston Celtics",
            "Brooklyn Nets",
            "Charlotte Hornets",
            "Chicago Bulls",
            "Cleveland Cavaliers",
            "Detroit Pistons",
            "Indiana Pacers",
            "Miami Heat",
            "Milwaukee Bucks",
            "New York Knicks",
            "Orlando Magic",
            "Philadelphia 76ers",
            "Toronto Raptors",
            "Washington Wizards"
        }; 

    }

    public static void SpaceLines()
    {
        Console.WriteLine("");
        Console.WriteLine("=====================================================================================================");
        Console.WriteLine("");
    }

    public static string PlayerName()
    {
        SpaceLines();

        string name = string.Empty;

        Console.WriteLine("Digite o nome do seu jogador:");
        Console.WriteLine("");
        do {
            name = Console.ReadLine()!;
        } while(name == string.Empty);

        return name;     
    }

    public static string PlayerPosition()
    {
        string position = string.Empty;

        string [] pos = 
        {   
            "PG",
            "SG",
            "SF",
            "PF",
            "C"
        };

        SpaceLines();

        do {
            Console.WriteLine("Qual a posição do seu jogador?");
            Console.WriteLine("PG - Armador");
            Console.WriteLine("SG - Ala-Armador");
            Console.WriteLine("SF - Ala");
            Console.WriteLine("PF - Ala-Pivô");
            Console.WriteLine("C - Pivô");
            Console.WriteLine("");
            position = Console.ReadLine()!.ToUpper();
        } while (!pos.Contains(position));
        
        return position;
    }

    public static int PlayerPick()
    {
        Random random = new Random();

        int pick = random.Next(1, 31);

        return pick;
    }

}
