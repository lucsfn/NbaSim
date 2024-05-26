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
        string playerPosition = GetPlayerPosition();
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
        string DraftInfos = Draft(ref PickDraft, ref playerPosition,ref NbaTeamSelected, AllNbaTeams, playerName);

        Console.WriteLine(DraftInfos);

        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");

        // Função para saber a força do time baseado na classificação da Temporada Regular 23/24
        int TeamRookieForce = ForceRookieTeam(NbaTeamSelected);

        // Variáveis que serão utilizadas para saber o Rookie Year
        int rookieGamesPlayed = 0,
            rookiePPG = 0,
            rookieRPG = 0,
            rookieAPG = 0;

        bool ROY = false;

        // Função que simula o ROY
        RookieYear(ref TeamRookieForce, ref rookieGamesPlayed, ref rookiePPG, ref rookieRPG, ref rookieAPG, ref ROY);

        // Imprimindo resultado da Rookie Season
        Console.WriteLine($"O jogador {playerName} em seu Rookie Year jogou {rookieGamesPlayed} jogos e obteve as seguintes médias:");
        Console.WriteLine(" ");
        Console.WriteLine($"{rookiePPG} pontos por jogo");
        Console.WriteLine($"{rookieRPG} rebotes por jogo");
        Console.WriteLine($"{rookieAPG} assistências por jogo");
        Console.WriteLine(" ");
        if (ROY)
        {
            Console.WriteLine ("Além de ganahr o ROY!");
        } else
        {
            Console.WriteLine("Além disso, o jogador não ganhou o ROY.");
        }
        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");
        
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
        Console.WriteLine(" ");      

        return PlayerName;
    }

    public static string GetPlayerPosition()
    {
        string PlayerPosition = "";
#pragma warning disable CS8602
        // Array com as posições válidas
        string[] ValidPositions = { "PG", "SG", "SF", "PF", "C" };

        Console.WriteLine(" ");
        do {
            Console.WriteLine("Digite a posição do seu jogador: \nPG (Armador)\nSG (Ala-armador)\nSF (Ala)\nPF (Ala-Pivô)\nC (Pivô)");
            PlayerPosition = Console.ReadLine().ToUpper();

        } while (!Array.Exists(ValidPositions, position => position == PlayerPosition));
#pragma warning restore CS8602
        return PlayerPosition;
    }

    public static string Draft (ref int PickDraft, ref string playerPosition, ref string NbaTeamSelected, string [] AllNbaTeams, string playerName)
    {
        Random random = new Random();

        PickDraft = random.Next(1,31);
        NbaTeamSelected = AllNbaTeams[random.Next(0,30)];

        string Draft = $"O jogador {playerName}, um {playerPosition}, foi escolhido pelo {NbaTeamSelected} na {PickDraft}º escolha.";

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

        // Obtendo o número de jogos
        if (TeamRookieForce == 1)
        {
            rookieGamesPlayed = random.Next(30, 61);
        } else if (TeamRookieForce == 2)
        {
            rookieGamesPlayed = random.Next(55, 76);
        } else 
        {
            rookieGamesPlayed = random.Next(60, 80);
        }

        // Obtendo o número de pontos por jogo   
        if (TeamRookieForce == 1)
        {
            rookiePPG = random.Next(5, 13);
        } else if (TeamRookieForce == 2)
        {
            rookiePPG = random.Next(10, 16);
        } else 
        {
            rookiePPG = random.Next(13, 23);
        }

        // Obtendo o número de rebotes por jogo   
        if (TeamRookieForce == 1)
        {
            rookieRPG = random.Next(2, 4);
        } else if (TeamRookieForce == 2)
        {
            rookieRPG = random.Next(3, 6);
        } else if (TeamRookieForce == 3) 
        {
            rookieRPG = random.Next(4,7);
        }
    
        // Obtendo o número de assistências por jogo
        if (TeamRookieForce == 1)
        {
            rookieAPG = random.Next(2, 4);
        } else if (TeamRookieForce == 2)
        {
            rookieAPG = random.Next(3, 6);
        } else if (TeamRookieForce == 3)
        {
            rookieAPG = random.Next(4,7);
        }

        int ProbWinRoy = 0;

        // Calculando probabilidade de ganhar o ROY
        if (TeamRookieForce == 1)
        {
            ProbWinRoy = random.Next(15, 60);
        } else if (TeamRookieForce == 2)
        {
            ProbWinRoy = random.Next(25, 70);
        } else if (TeamRookieForce == 2)
        {
            ProbWinRoy = random.Next(35, 80);
        }   

        if (ProbWinRoy >= 50)
        {
            ROY = true;
        }
    }
}
