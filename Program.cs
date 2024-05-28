using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");

        Console.WriteLine("Bem vindo ao simulador de carreira NBA!");

        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");

        // Função para obter o nome do jogador
        string playerName = GetPlayerName();
        string playerPosition = GetplayerPosition();
        Console.Clear();
        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");

        int playerAge = 19;
        string continueSim = string.Empty;
        string condOffs = string.Empty;

        // Array dos times da Nba
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

        // Array com os times da NBA na Conferência Leste
        string[] easternNbaTeams = {
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

        // Array com os times da NBA na Conferência Oeste
        string[] westernNbaTeams = {
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

        // Variáveis a serem utilizadas na função Draft
        int pickDraft = 0;
        string nbaTeamSelected = string.Empty;

        // Função Draft
        string draftInfos = Draft(ref pickDraft, ref playerPosition, ref nbaTeamSelected, allNbaTeams, playerName);

        string TeamConference = Conference(nbaTeamSelected, easternNbaTeams, westernNbaTeams);
        string playerTeam = nbaTeamSelected;

        Console.WriteLine(draftInfos);

        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");

        // Função para determinar a conferência do time
        string teamConference = Conference(nbaTeamSelected, easternNbaTeams, westernNbaTeams);

        // Função para saber a força do time baseado na classificação da Temporada Regular 23/24
        int teamRookieForce = ForceRookieTeam(nbaTeamSelected);

        // Variáveis que serão utilizadas para saber o Rookie Year
        int regularSeasonGamesPlayed = 0,
            regularSeasonPPG = 0,
            regularSeasonRPG = 0,
            regularSeasonAPG = 0;

        bool winRoy = false;

        // Função que simula o roy
        RookieYear(ref teamRookieForce, ref regularSeasonGamesPlayed, ref regularSeasonPPG, ref regularSeasonRPG, ref regularSeasonAPG, ref winRoy);

        // Imprimindo resultado da Rookie Season
        Console.WriteLine($"O jogador {playerName} em seu Rookie Year jogou {regularSeasonGamesPlayed} jogos e obteve as seguintes médias:");
        Console.WriteLine(" ");
        Console.WriteLine($"{regularSeasonPPG} pontos por jogo");
        Console.WriteLine($"{regularSeasonRPG} rebotes por jogo");
        Console.WriteLine($"{regularSeasonAPG} assistências por jogo");
        Console.WriteLine(" ");
        if (winRoy)
        {
            Console.WriteLine("Além de ganhar o ROY!");
        }
        else
        {
            Console.WriteLine("Além disso, o jogador não ganhou o ROY.");
        }
        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");

        // Imprimindo a seed e a condição de pós-temporada
        string condRookie = string.Empty;
        int seasonCondition = 0;

        TeamSeedRookie(nbaTeamSelected, teamRookieForce, ref condRookie, ref seasonCondition, ref TeamConference);

        Console.WriteLine(condRookie);
        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");

        // Calculando total stats na Regular Season
        int totalG = 0,
            totalP = 0,
            totalR = 0,
            totalA = 0,
            totalMediaStats = 0;

        RegularSeasonTotalStats(regularSeasonGamesPlayed, regularSeasonPPG, regularSeasonRPG, regularSeasonAPG, ref totalP, ref totalR, ref totalA, ref totalMediaStats, ref totalG);

        // Cálculo OVR Rookie
        int ovrPlayer = OvrRookie(totalMediaStats);

        Console.WriteLine($"{playerName} teve um overral de {ovrPlayer} ao final da temporada regular!");
        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");

        // Simulação dos Playoffs
        int nbaChamp = 0,
            nbaFMVP = 0,
            offsP = 0,
            offsR = 0,
            offsA = 0;

        if (seasonCondition != 3)
        {
            do
            {
                Console.WriteLine("Pronto para os playoffs?");
                continueSim = Console.ReadLine()?.ToUpper() ?? string.Empty;
            } while (continueSim != "SIM");

            // Simulação dos Playoffs

            PlayoffsSim(seasonCondition, easternNbaTeams, westernNbaTeams, teamConference, playerTeam, ref nbaChamp, ref nbaFMVP, ovrPlayer);

            // Stats nos Playoffs
            PlayoffsPerfomance(ref offsP, ref offsR, ref offsA, ref ovrPlayer, ref condOffs, playerName, seasonCondition, playerPosition, regularSeasonPPG, regularSeasonRPG, regularSeasonAPG);
        }

        playerAge++;

        // Próximas temporadas
        int teamForce = teamRookieForce;
        string condRegularSeason = string.Empty;
        int seasonCount = 2;
        int mvp = 0;

        Console.WriteLine("Pronto para a segunda temporada?");
        continueSim = Console.ReadLine()?.ToUpper() ?? string.Empty;
        Console.Clear();

        do
        {
            Console.WriteLine($"Vamos para a sua {seasonCount}º temporada!");
            Console.WriteLine(" ");
            Console.WriteLine("==============================================================================");
            Console.WriteLine(" ");

            // Simulando os stats de temporada regular, além de imprimir
            RegularSeasonStats(ref ovrPlayer, ref regularSeasonGamesPlayed, ref regularSeasonPPG, ref regularSeasonRPG, ref regularSeasonAPG, totalMediaStats, playerAge, playerPosition);

            // Calculando os stats totais a cada season
            RegularSeasonTotalStats(regularSeasonGamesPlayed, regularSeasonPPG, regularSeasonRPG, regularSeasonAPG, ref totalP, ref totalR, ref totalA, ref totalMediaStats, ref totalG);

            // Saber se o jogador ganhou ou não o MVP
            bool winMVP = MVP(ovrPlayer, totalMediaStats, regularSeasonGamesPlayed);

            Console.WriteLine($"O jogador {playerName} jogou {regularSeasonGamesPlayed} jogos na sua {seasonCount}º temporada e obteve as seguintes médias:");
            Console.WriteLine(" ");
            Console.WriteLine($"{regularSeasonPPG} pontos por jogo");
            Console.WriteLine($"{regularSeasonRPG} rebotes por jogo");
            Console.WriteLine($"{regularSeasonAPG} assistências por jogo");
            Console.WriteLine(" ");
            Console.WriteLine($"{playerName} teve um overall de {ovrPlayer} ao final da temporada regular!");
            Console.WriteLine(" ");
            Console.WriteLine("==============================================================================");
            Console.WriteLine(" ");
            if (winMVP)
            {
                mvp++;
                Console.WriteLine($"{playerName} foi eleito o MVP da Temporada Regular, parabéns!");
                Console.WriteLine(" ");
                Console.WriteLine("==============================================================================");
                Console.WriteLine(" ");
            }

            TeamSeed(playerTeam, teamForce, ref condRegularSeason, ref seasonCondition, ref TeamConference, ovrPlayer);
            Console.WriteLine(condRegularSeason);

            if (seasonCondition != 3)
            {
                Console.WriteLine(" ");
                Console.WriteLine("==============================================================================");
                Console.WriteLine(" ");
                Console.WriteLine("Pronto para os playoffs?");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();

                // Simulação dos Playoffs
                PlayoffsSim(seasonCondition, easternNbaTeams, westernNbaTeams, teamConference, playerTeam, ref nbaChamp, ref nbaFMVP, ovrPlayer);
                Console.WriteLine(" ");
                Console.WriteLine("==============================================================================");
                Console.WriteLine(" ");

                // Stats nos Playoffs
                PlayoffsPerfomance(ref offsP, ref offsR, ref offsA, ref ovrPlayer, ref condOffs, playerName, seasonCondition, playerPosition, regularSeasonPPG, regularSeasonRPG, regularSeasonAPG);
            }

            seasonCount++;
            playerAge++;

            // Verifica se a idade do jogador é maior que 40 para encerrar o programa
            if (playerAge > 40)
            {
                Console.WriteLine(" ");
                Console.WriteLine("==============================================================================");
                Console.WriteLine(" ");
                Console.WriteLine($"A carreira de {playerName} chegou ao fim com {totalG} jogos ao longo de {seasonCount - 1} temporadas.\n{totalP} pontos\n{totalR} rebotes\n{totalA} assistências");
                Console.WriteLine($"Além de conquistar {nbaChamp} títulos, {mvp} MVPs e {nbaFMVP} FMVPs!");
                Console.WriteLine(" ");
                Console.WriteLine("==============================================================================");
                Console.WriteLine(" ");
                break; // Encerra o loop
            }

            // Pergunta se deseja continuar a simulação
            Console.WriteLine(" ");
            Console.WriteLine("==============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine($"Deseja continuar a simulação? {playerName} está com {playerAge} anos, indo para sua {seasonCount}º temporada na liga.");
            Console.WriteLine("Digite 'SIM' para continuar ou 'NAO' para encerrar a simulação.");

            continueSim = Console.ReadLine()?.ToUpper() ?? string.Empty;

            Console.Clear();
        } while (continueSim == "SIM");

        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");
        Console.WriteLine("Obrigado por jogar o nbaSim!");
        Console.WriteLine($"{playerName} terminou a carreira com {totalG} jogos ao longo de {seasonCount - 1} temporadas.\n{totalP} pontos\n{totalR} rebotes\n{totalA} assistências");
        Console.WriteLine($"Além de conquistar {nbaChamp} títulos, {mvp} MVPs e {nbaFMVP} FMVPs!");
        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");

    }

    public static string GetPlayerName()
    {
        string PlayerName = string.Empty;
#pragma warning disable CS8600

        do
        {
            Console.WriteLine("Qual nome do seu jogador?");
            PlayerName = Console.ReadLine();

            if (PlayerName == null) PlayerName = string.Empty;
#pragma warning restore CS8600

        } while (string.IsNullOrEmpty(PlayerName));

        return PlayerName;
    }

    public static string GetplayerPosition()
    {
        string playerPosition = string.Empty;
#pragma warning disable CS8602
        // Array com as posições válidas
        string[] ValidPositions = { "PG", "SG", "SF", "PF", "C" };

        Console.WriteLine(" ");
        do
        {
            Console.WriteLine("Digite a posição do seu jogador: \nPG (Armador)\nSG (Ala-armador)\nSF (Ala)\nPF (Ala-Pivô)\nC (Pivô)");
            playerPosition = Console.ReadLine().ToUpper();

        } while (!Array.Exists(ValidPositions, position => position == playerPosition));
#pragma warning restore CS8602
        return playerPosition;
    }

    public static string Draft(ref int pickDraft, ref string playerPosition, ref string nbaTeamSelected, string[] allNbaTeams, string playerName)
    {
        Random random = new Random();

        pickDraft = random.Next(1, 31);
        nbaTeamSelected = allNbaTeams[random.Next(0, 30)];

        string Draft = $"O jogador {playerName}, um {playerPosition}, foi escolhido pelo {nbaTeamSelected} na {pickDraft}º escolha.";

        return Draft;
    }

    public static string Conference(string nbaTeamSelected, string[] easternNbaTeams, string[] westernNbaTeams)
    {
        string Conference = string.Empty;

        if (Array.Exists(easternNbaTeams, position => position == nbaTeamSelected))
        {
            Conference = "Leste";
        }
        else
        {
            Conference = "Oeste";
        }

        return Conference;
    }

    public static int ForceRookieTeam(string nbaTeamSelected)
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
            if (nbaTeamSelected == TeamsClassification[i])
            {
                pos = i + 1;
            }
        }

        if (pos <= 10)
        {
            forceValue = 1;
        }
        else if (pos <= 20)
        {
            forceValue = 2;
        }
        else
        {
            forceValue = 3;
        }

        return forceValue;

    }

    public static void RookieYear(ref int teamRookieForce, ref int regularSeasonGamesPlayed, ref int regularSeasonPPG, ref int regularSeasonRPG, ref int regularSeasonAPG, ref bool winRoy)
    {
        Random random = new Random();

        // Obtendo o número de jogos
        if (teamRookieForce == 1)
        {
            regularSeasonGamesPlayed = random.Next(60, 71);
        }
        else if (teamRookieForce == 2)
        {
            regularSeasonGamesPlayed = random.Next(60, 76);
        }
        else
        {
            regularSeasonGamesPlayed = random.Next(60, 83);
        }

        // Obtendo o número de pontos por jogo   
        if (teamRookieForce == 1)
        {
            regularSeasonPPG = random.Next(12, 19);
        }
        else if (teamRookieForce == 2)
        {
            regularSeasonPPG = random.Next(13, 21);
        }
        else
        {
            regularSeasonPPG = random.Next(14, 24);
        }

        // Obtendo o número de rebotes por jogo   
        if (teamRookieForce == 1)
        {
            regularSeasonRPG = random.Next(3, 6);
        }
        else if (teamRookieForce == 2)
        {
            regularSeasonRPG = random.Next(3, 7);
        }
        else if (teamRookieForce == 3)
        {
            regularSeasonRPG = random.Next(3, 8);
        }

        // Obtendo o número de assistências por jogo
        if (teamRookieForce == 1)
        {
            regularSeasonAPG = random.Next(2, 5);
        }
        else if (teamRookieForce == 2)
        {
            regularSeasonAPG = random.Next(2, 6);
        }
        else if (teamRookieForce == 3)
        {
            regularSeasonAPG = random.Next(3, 7);
        }

        int ProbWinroy = 0;

        // Calculando probabilidade de ganhar o roy
        if (teamRookieForce == 1 && regularSeasonGamesPlayed >= 58 && regularSeasonPPG >= 16)
        {
            ProbWinroy = random.Next(15, 55);
        }
        else if (teamRookieForce == 2 && regularSeasonGamesPlayed >= 58 && regularSeasonPPG >= 17)
        {
            ProbWinroy = random.Next(25, 70);
        }
        else if (teamRookieForce == 3 && regularSeasonGamesPlayed >= 58 && regularSeasonPPG >= 18)
        {
            ProbWinroy = random.Next(35, 80);
        }

        if (ProbWinroy >= 50)
        {
            winRoy = true;
        }
    }

    public static void TeamSeedRookie(string nbaTeamSelected, int teamRookieForce, ref string condRookie, ref int seasonCondition, ref string TeamConference)
    {
        Random random = new Random();

        int wins = 0,
            loses = 0,
            teamPosition = 0;

        seasonCondition = 0;

        if (teamRookieForce == 1)
        {
            wins = random.Next(46, 69);
        }
        else if (teamRookieForce == 2)
        {
            wins = random.Next(38, 52);
        }
        else if (teamRookieForce == 3)
        {
            wins = random.Next(18, 42);
        }

        loses = 82 - wins;


        if (wins >= 56)
        {
            teamPosition = random.Next(1, 4);
            seasonCondition = 1;
            condRookie = $"O {nbaTeamSelected} obteve uma seed de {wins} W - {loses} L e classificou para os playoffs em {teamPosition}º no {TeamConference}!";
        }
        else if (wins <= 55 && wins >= 48)
        {
            teamPosition = random.Next(4, 7);
            seasonCondition = 1;
            condRookie = $"O {nbaTeamSelected} obteve uma seed de {wins} W - {loses} L e classificou para os playoffs em {teamPosition}º no {TeamConference}!";
        }
        else if (wins <= 47 && wins >= 41)
        {
            teamPosition = random.Next(7, 9);
            seasonCondition = 2;
            condRookie = $"O {nbaTeamSelected} obteve uma seed de {wins} W - {loses} L e classificou para o play-in em {teamPosition}º no {TeamConference}!";
        }
        else if (wins <= 41 && wins >= 32)
        {
            teamPosition = random.Next(10, 13);
            seasonCondition = 3;
            condRookie = $"O {nbaTeamSelected} obteve uma seed de {wins} W - {loses} L no {TeamConference}, ficando em {teamPosition}º e não classificando para a pós-temporada.";
        }
        else
        {
            teamPosition = random.Next(13, 16);
            seasonCondition = 3;
            condRookie = $"O {nbaTeamSelected} obteve uma seed de {wins} W - {loses} L no {TeamConference}, ficando em {teamPosition}º e não classificando para a pós-temporada.";
        }
    }

    public static void RegularSeasonTotalStats(int regularSeasonGamesPlayed, int regularSeasonPPG, int regularSeasonRPG, int regularSeasonAPG, ref int totalP, ref int totalR, ref int totalA, ref int totalMediaStats, ref int totalG)
    {
        totalMediaStats = regularSeasonPPG + regularSeasonRPG + regularSeasonAPG;

        totalP += regularSeasonPPG * regularSeasonGamesPlayed;
        totalR += regularSeasonRPG * regularSeasonGamesPlayed;
        totalA += regularSeasonAPG * regularSeasonGamesPlayed;
        totalG += regularSeasonGamesPlayed;
    }

    public static int OvrRookie(int totalMediaStats)
    {
        int ovr = 0;

        Random random = new Random();

        if (totalMediaStats >= 27)
        {
            ovr = random.Next(78, 85);
        }
        else if (totalMediaStats >= 23)
        {
            ovr = random.Next(76, 83);
        }
        else
        {
            ovr = random.Next(73, 79);
        }

        return ovr;
    }

    public static void TeamSeed(string playerTeam, int teamForce, ref string condRegularSeason, ref int seasonCondition, ref string TeamConference, int ovrPlayer)
    {
        Random random = new Random();

        int wins = 0,
            loses = 0,
            teamPosition = 0;

        seasonCondition = 0;

        if (teamForce == 1)
        {
            wins = random.Next(46, 73);
        }
        else if (teamForce == 2)
        {
            wins = random.Next(38, 52);
            if (wins > 48)
            {
                teamForce = 1;
            }
        }
        else if (teamForce == 3)
        {
            wins = random.Next(18, 42);
            if (wins > 42)
            {
                teamForce = 2;
            }
        }

        loses = 82 - wins;

        int winIncrease = 0;
        double winChanceAdjustment = 0.0;
        if (ovrPlayer > 95)
        {
            winIncrease = random.Next(0, 6);
            winChanceAdjustment = wins > 65 ? 0.26 : 0.38;
        }
        else if (ovrPlayer > 90)
        {
            winIncrease = random.Next(0, 5);
            winChanceAdjustment = wins > 65 ? 0.22 : 0.32;
        }
        else if (ovrPlayer > 85)
        {
            winIncrease = random.Next(0, 4);
            winChanceAdjustment = wins > 65 ? 0.14 : 0.26;
        }

        wins += winIncrease;

        if (wins >= 63)
        {
            teamPosition = random.Next(1, 3);
            seasonCondition = 1;
            condRegularSeason = $"O {playerTeam} obteve uma seed de {wins} W - {loses} L e classificou para os playoffs em {teamPosition}º no {TeamConference}!";
        }
        else if (wins >= 56)
        {
            teamPosition = random.Next(1, 4);
            seasonCondition = 1;
            condRegularSeason = $"O {playerTeam} obteve uma seed de {wins} W - {loses} L e classificou para os playoffs em {teamPosition}º no {TeamConference}!";
        }
        else if (wins >= 48)
        {
            teamPosition = random.Next(4, 7);
            seasonCondition = 1;
            condRegularSeason = $"O {playerTeam} obteve uma seed de {wins} W - {loses} L e classificou para os playoffs em {teamPosition}º no {TeamConference}!";
        }
        else if (wins >= 41)
        {
            teamPosition = random.Next(7, 9);
            seasonCondition = 2;
            condRegularSeason = $"O {playerTeam} obteve uma seed de {wins} W - {loses} L e classificou para o play-in em {teamPosition}º no {TeamConference}!";
        }
        else if (wins >= 35)
        {
            teamPosition = random.Next(11, 13);
            seasonCondition = 3;
            condRegularSeason = $"O {playerTeam} obteve uma seed de {wins} W - {loses} L no {TeamConference}, ficando em {teamPosition}º e não classificando para a pós-temporada.";
        }
        else if (wins >= 30)
        {
            teamPosition = random.Next(13, 15);
            seasonCondition = 3;
            condRegularSeason = $"O {playerTeam} obteve uma seed de {wins} W - {loses} L no {TeamConference}, ficando em {teamPosition}º e não classificando para a pós-temporada.";
        }
        else
        {
            teamPosition = random.Next(14, 16);
            seasonCondition = 3;
            condRegularSeason = $"O {playerTeam} obteve uma seed de {wins} W - {loses} L no {TeamConference}, ficando em {teamPosition}º e não classificando para a pós-temporada.";
        }
    }

    public static void RegularSeasonStats(ref int ovrPlayer, ref int regularSeasonGamesPlayed, ref int regularSeasonPPG, ref int regularSeasonRPG, ref int regularSeasonAPG, int totalMediaStats, int playerAge, string playerPosition)
    {
        Random random = new Random();

        int oldPPG = regularSeasonPPG;
        int oldRPG = regularSeasonRPG;
        int oldAPG = regularSeasonAPG;

        regularSeasonGamesPlayed = random.Next(65, 83);

        if (ovrPlayer > 95)
        {
            regularSeasonPPG = random.Next(23, 39);
            regularSeasonRPG = random.Next(5, 13);
            regularSeasonAPG = random.Next(5, 13);
        }
        else if (ovrPlayer > 90)
        {
            regularSeasonPPG = random.Next(21, 34);
            regularSeasonRPG = random.Next(5, 9);
            regularSeasonAPG = random.Next(5, 9);
        }
        else if (ovrPlayer > 86)
        {
            regularSeasonPPG = random.Next(18, 29);
            regularSeasonRPG = random.Next(4, 8);
            regularSeasonAPG = random.Next(4, 9);
        }
        else if (ovrPlayer > 82)
        {
            regularSeasonPPG = random.Next(18, 26);
            regularSeasonRPG = random.Next(3, 8);
            regularSeasonAPG = random.Next(4, 9);
        }
        else if (ovrPlayer > 79)
        {
            regularSeasonPPG = random.Next(16, 19);
            regularSeasonRPG = random.Next(2, 7);
            regularSeasonAPG = random.Next(3, 8);
        }
        else if (ovrPlayer > 74)
        {
            regularSeasonPPG = random.Next(11, 19);
            regularSeasonRPG = random.Next(2, 5);
            regularSeasonAPG = random.Next(3, 6);
        }
        else
        {
            regularSeasonPPG = random.Next(9, 15);
            regularSeasonRPG = random.Next(2, 5);
            regularSeasonAPG = random.Next(3, 5);
        }

        int diffPPG = regularSeasonPPG - oldPPG;
        int diffRPG = regularSeasonRPG - oldRPG;
        int diffAPG = regularSeasonAPG - oldAPG;

        if (diffPPG > 4)
        {
            regularSeasonPPG = oldPPG + 4;
        }
        else if (diffPPG < -2)
        {
            regularSeasonPPG = oldPPG - 2;
        }

        if (diffRPG > 4)
        {
            regularSeasonRPG = oldRPG + 4;
        }
        else if (diffRPG < -2)
        {
            regularSeasonRPG = oldRPG - 2;
        }

        if (diffAPG > 4)
        {
            regularSeasonAPG = oldAPG + 4;
        }
        else if (diffAPG < -2)
        {
            regularSeasonAPG = oldAPG - 2;
        }

        totalMediaStats = regularSeasonPPG + regularSeasonRPG + regularSeasonAPG;

        if (totalMediaStats > (oldPPG + oldRPG + oldAPG) && playerAge < 35)
        {
            if (ovrPlayer >= 99)
            {
                ovrPlayer += 0;
            }
            else if (ovrPlayer > 94)
            {
                ovrPlayer += random.Next(0, 2);
            }
            else
            {
                ovrPlayer += random.Next(1, 6);
            }
        }
        else
        {
            ovrPlayer -= random.Next(0, 2);
        }

        if (playerAge > 35)
        {
            ovrPlayer -= random.Next(0, 4);
        }

        if (playerAge <= 22)
        {
            ovrPlayer += random.Next(0, 2);
        }
    }

    public static bool MVP(int ovrPlayer, int totalMediaStats, int regularSeasonGamesPlayed)
    {
        Random random = new Random();
        int numberMVP = random.Next(0, 10);

        bool mvpWin = false;

        if (ovrPlayer > 84 && totalMediaStats > 39 && regularSeasonGamesPlayed > 58 && numberMVP >= 7)
        {
            mvpWin = true;
        }

        return mvpWin;
    }

    public static void PlayoffsSim(int seasonCondition, string[] easternNbaTeams, string[] westernNbaTeams, string teamConference, string playerTeam, ref int nbaChamp, ref int nbaFMVP, int ovrPlayer)
    {
        Random random = new Random();
        string playInTeam = string.Empty,
                firstRoundTeam = string.Empty,
                secondRoundTeam = string.Empty,
                cfTeam = string.Empty,
                finalTeam = string.Empty;

        int wins = 0,
            loses = 0;

        bool FVMPWin = false;
        double winChanceAdjustment = 0;

        if (teamConference == "Leste")
        {
            if (ovrPlayer > 95)
            {
                winChanceAdjustment = 0.35;
            }
            else if (ovrPlayer > 90)
            {
                winChanceAdjustment = 0.18;
            }
            else if (ovrPlayer > 86)
            {
                winChanceAdjustment = 0.075;
            }

            if (seasonCondition == 1) // Playoffs direto
            {
                do
                {
                    firstRoundTeam = easternNbaTeams[random.Next(0, 15)];
                } while (firstRoundTeam == playerTeam);

                wins = random.Next(1, 5);
                if (random.NextDouble() < winChanceAdjustment)
                {
                    wins = 4;
                }

                if (wins == 4)
                {
                    loses = random.Next(0, 4);
                    Console.WriteLine($"O {playerTeam} enfrentou o {firstRoundTeam} no primeiro round e ganhou por {wins} - {loses}!");
                    Console.WriteLine(" ");
                    Console.WriteLine("==============================================================================");
                    Console.WriteLine(" ");

                    do
                    {
                        secondRoundTeam = easternNbaTeams[random.Next(0, 15)];
                    } while (secondRoundTeam == firstRoundTeam || secondRoundTeam == playerTeam);

                    wins = random.Next(1, 5);
                    if (random.NextDouble() < winChanceAdjustment)
                    {
                        wins = 4;
                    }

                    if (wins == 4)
                    {
                        loses = random.Next(0, 4);
                        Console.WriteLine($"O {playerTeam} enfrentou o {secondRoundTeam} no segundo round e ganhou por {wins} - {loses}!");
                        Console.WriteLine(" ");
                        Console.WriteLine("==============================================================================");
                        Console.WriteLine(" ");

                        do
                        {
                            cfTeam = easternNbaTeams[random.Next(0, 15)];
                        } while (cfTeam == firstRoundTeam || cfTeam == secondRoundTeam || cfTeam == playerTeam);

                        wins = random.Next(1, 5);
                        if (random.NextDouble() < winChanceAdjustment)
                        {
                            wins = 4;
                        }

                        if (wins == 4)
                        {
                            loses = random.Next(0, 4);
                            Console.WriteLine($"O {playerTeam} enfrentou o {cfTeam} nas finais de conferência e ganhou por {wins} - {loses}!");
                            Console.WriteLine(" ");
                            Console.WriteLine("==============================================================================");
                            Console.WriteLine(" ");

                            finalTeam = westernNbaTeams[random.Next(0, 16)];

                            wins = random.Next(1, 5);
                            if (random.NextDouble() < winChanceAdjustment)
                            {
                                wins = 4;
                            }

                            if (wins == 4)
                            {
                                loses = random.Next(0, 4);
                                Console.WriteLine($"O {playerTeam} enfrentou o {finalTeam} nas finais da NBA e ganhou por {wins} - {loses}!");
                                Console.WriteLine(" ");
                                Console.WriteLine("==============================================================================");
                                Console.WriteLine(" ");
                                nbaChamp++;
                                FVMPWin = random.Next(0, 2) == 0;
                            }
                            else
                            {
                                loses = 4;
                                Console.WriteLine($"O {playerTeam} enfrentou o {finalTeam} na final da NBA e perdeu por {loses} - {wins}.");
                            }
                        }
                        else
                        {
                            loses = 4;
                            Console.WriteLine($"O {playerTeam} enfrentou o {cfTeam} nas finais de conferência e perdeu por {loses} - {wins}.");
                        }
                    }
                    else
                    {
                        loses = 4;
                        Console.WriteLine($"O {playerTeam} enfrentou o {secondRoundTeam} no segundo round e perdeu por {loses} - {wins}.");
                    }
                }
                else
                {
                    loses = 4;
                    Console.WriteLine($"O {playerTeam} enfrentou o {firstRoundTeam} no primeiro round e perdeu por {loses} - {wins}.");
                }
            }
            else if (seasonCondition == 2) // Play - In
            {
                do
                {
                    playInTeam = easternNbaTeams[random.Next(0, 15)];
                } while (playInTeam == playerTeam);

                wins = random.Next(1, 5);
                if (random.NextDouble() < winChanceAdjustment)
                {
                    wins = 4;
                }

                if (wins > -1)
                {
                    loses = 0;
                    Console.WriteLine($"O {playerTeam} enfrentou o {playInTeam} no play-in e ganhou por 1 - 0!");
                    Console.WriteLine(" ");
                    Console.WriteLine("==============================================================================");
                    Console.WriteLine(" ");

                    do
                    {
                        firstRoundTeam = easternNbaTeams[random.Next(0, 15)];
                    } while (firstRoundTeam == playerTeam || firstRoundTeam == playInTeam);

                    wins = random.Next(1, 5);
                    if (random.NextDouble() < winChanceAdjustment)
                    {
                        wins = 4;
                    }

                    if (wins == 4)
                    {
                        loses = random.Next(0, 4);
                        Console.WriteLine($"O {playerTeam} enfrentou o {firstRoundTeam} no primeiro round e ganhou por {wins} - {loses}!");
                        Console.WriteLine(" ");
                        Console.WriteLine("==============================================================================");
                        Console.WriteLine(" ");

                        do
                        {
                            secondRoundTeam = easternNbaTeams[random.Next(0, 15)];
                        } while (secondRoundTeam == firstRoundTeam || secondRoundTeam == playerTeam || secondRoundTeam == playInTeam);

                        wins = random.Next(1, 5);
                        if (random.NextDouble() < winChanceAdjustment)
                        {
                            wins = 4;
                        }

                        if (wins == 4)
                        {
                            loses = random.Next(0, 4);
                            Console.WriteLine($"O {playerTeam} enfrentou o {secondRoundTeam} no segundo round e ganhou por {wins} - {loses}!");
                            Console.WriteLine(" ");
                            Console.WriteLine("==============================================================================");
                            Console.WriteLine(" ");

                            do
                            {
                                cfTeam = easternNbaTeams[random.Next(0, 15)];
                            } while (cfTeam == firstRoundTeam || cfTeam == secondRoundTeam || cfTeam == playerTeam || cfTeam == playInTeam);

                            wins = random.Next(1, 5);
                            if (random.NextDouble() < winChanceAdjustment)
                            {
                                wins = 4;
                            }

                            if (wins == 4)
                            {
                                loses = random.Next(0, 4);
                                Console.WriteLine($"O {playerTeam} enfrentou o {cfTeam} nas finais de conferência e ganhou por {wins} - {loses}!");
                                Console.WriteLine(" ");
                                Console.WriteLine("==============================================================================");
                                Console.WriteLine(" ");

                                do
                                {

                                    finalTeam = westernNbaTeams[random.Next(0, 16)];
                                } while (finalTeam == string.Empty);

                                wins = random.Next(1, 5);
                                if (random.NextDouble() < winChanceAdjustment)
                                {
                                    wins = 4;
                                }

                                if (wins == 4)
                                {
                                    loses = random.Next(0, 4);
                                    Console.WriteLine($"O {playerTeam} enfrentou o {finalTeam} nas finais da NBA e ganhou por {wins} - {loses}!");
                                    Console.WriteLine(" ");
                                    Console.WriteLine("==============================================================================");
                                    Console.WriteLine(" ");
                                    nbaChamp++;
                                    FVMPWin = random.Next(0, 2) == 0;
                                }
                                else
                                {
                                    loses = 4;
                                    Console.WriteLine($"O {playerTeam} enfrentou o {finalTeam} na final da NBA e perdeu por {loses} - {wins}.");
                                }
                            }
                            else
                            {
                                loses = 4;
                                Console.WriteLine($"O {playerTeam} enfrentou o {cfTeam} nas finais de conferência e perdeu por {loses} - {wins}.");
                            }
                        }
                        else
                        {
                            loses = 4;
                            Console.WriteLine($"O {playerTeam} enfrentou o {secondRoundTeam} no segundo round e perdeu por {loses} - {wins}.");
                        }
                    }
                    else
                    {
                        loses = 4;
                        Console.WriteLine($"O {playerTeam} enfrentou o {firstRoundTeam} no primeiro round e perdeu por {loses} - {wins}.");
                    }
                }
                else
                {
                    loses = 4;
                    Console.WriteLine($"O {playerTeam} enfrentou o {playInTeam} no play-in e perdeu por {loses} - {wins}.");
                }
            }
        }
        if (teamConference == "Oeste")
        {
            winChanceAdjustment = 0;

            if (ovrPlayer > 95)
            {
                winChanceAdjustment = 0.65;
            }
            else if (ovrPlayer > 90)
            {
                winChanceAdjustment = 0.48;
            }
            else if (ovrPlayer > 86)
            {
                winChanceAdjustment = 0.25;
            }

            if (seasonCondition == 1) // Playoffs direto
            {
                do
                {
                    firstRoundTeam = westernNbaTeams[random.Next(0, 15)];
                } while (firstRoundTeam == playerTeam);

                wins = random.Next(1, 5);
                if (random.NextDouble() < winChanceAdjustment)
                {
                    wins = 4;
                }

                if (wins == 4)
                {
                    loses = random.Next(0, 4);
                    Console.WriteLine($"O {playerTeam} enfrentou o {firstRoundTeam} no primeiro round e ganhou por {wins} - {loses}!");
                    Console.WriteLine(" ");
                    Console.WriteLine("==============================================================================");
                    Console.WriteLine(" ");

                    do
                    {
                        secondRoundTeam = westernNbaTeams[random.Next(0, 15)];
                    } while (secondRoundTeam == firstRoundTeam || secondRoundTeam == playerTeam);

                    wins = random.Next(1, 5);
                    if (random.NextDouble() < winChanceAdjustment)
                    {
                        wins = 4;
                    }

                    if (wins == 4)
                    {
                        loses = random.Next(0, 4);
                        Console.WriteLine($"O {playerTeam} enfrentou o {secondRoundTeam} no segundo round e ganhou por {wins} - {loses}!");
                        Console.WriteLine(" ");
                        Console.WriteLine("==============================================================================");
                        Console.WriteLine(" ");

                        do
                        {
                            cfTeam = westernNbaTeams[random.Next(0, 15)];
                        } while (cfTeam == firstRoundTeam || cfTeam == secondRoundTeam || cfTeam == playerTeam);

                        wins = random.Next(1, 5);
                        if (random.NextDouble() < winChanceAdjustment)
                        {
                            wins = 4;
                        }

                        if (wins == 4)
                        {
                            loses = random.Next(0, 4);
                            Console.WriteLine($"O {playerTeam} enfrentou o {cfTeam} nas finais de conferência e ganhou por {wins} - {loses}!");
                            Console.WriteLine(" ");
                            Console.WriteLine("==============================================================================");
                            Console.WriteLine(" ");

                            do
                            {
                                finalTeam = easternNbaTeams[random.Next(0, 15)];
                            } while (finalTeam == string.Empty);

                            wins = random.Next(1, 5);
                            if (random.NextDouble() < winChanceAdjustment)
                            {
                                wins = 4;
                            }

                            if (wins == 4)
                            {
                                loses = random.Next(0, 4);
                                Console.WriteLine($"O {playerTeam} enfrentou o {finalTeam} nas finais da NBA e ganhou por {wins} - {loses}!");
                                Console.WriteLine(" ");
                                Console.WriteLine("==============================================================================");
                                Console.WriteLine(" ");
                                nbaChamp++;
                                FVMPWin = random.Next(0, 2) == 0;
                            }
                            else
                            {
                                loses = 4;
                                Console.WriteLine($"O {playerTeam} enfrentou o {finalTeam} na final da NBA e perdeu por {loses} - {wins}.");
                            }
                        }
                        else
                        {
                            loses = 4;
                            Console.WriteLine($"O {playerTeam} enfrentou o {cfTeam} nas finais de conferência e perdeu por {loses} - {wins}.");
                        }
                    }
                    else
                    {
                        loses = 4;
                        Console.WriteLine($"O {playerTeam} enfrentou o {secondRoundTeam} no segundo round e perdeu por {loses} - {wins}.");
                    }
                }
                else
                {
                    loses = 4;
                    Console.WriteLine($"O {playerTeam} enfrentou o {firstRoundTeam} no primeiro round e perdeu por {loses} - {wins}.");
                }
            }
            else if (seasonCondition == 2) // Play - In
            {
                do
                {
                    playInTeam = westernNbaTeams[random.Next(0, 15)];
                } while (playInTeam == playerTeam);

                wins = random.Next(1, 5);
                if (random.NextDouble() < winChanceAdjustment)
                {
                    wins = 4;
                }

                if (wins == 4)
                {
                    loses = random.Next(0, 4);
                    Console.WriteLine($"O {playerTeam} enfrentou o {playInTeam} no play-in e ganhou por {wins} - {loses}!");
                    Console.WriteLine(" ");
                    Console.WriteLine("==============================================================================");
                    Console.WriteLine(" ");

                    do
                    {
                        firstRoundTeam = westernNbaTeams[random.Next(0, 15)];
                    } while (firstRoundTeam == playerTeam || firstRoundTeam == playInTeam);

                    wins = random.Next(1, 5);
                    if (random.NextDouble() < winChanceAdjustment)
                    {
                        wins = 4;
                    }

                    if (wins == 4)
                    {
                        loses = random.Next(0, 4);
                        Console.WriteLine($"O {playerTeam} enfrentou o {firstRoundTeam} no primeiro round e ganhou por {wins} - {loses}!");
                        Console.WriteLine(" ");
                        Console.WriteLine("==============================================================================");
                        Console.WriteLine(" ");

                        do
                        {
                            secondRoundTeam = westernNbaTeams[random.Next(0, 15)];
                        } while (secondRoundTeam == firstRoundTeam || secondRoundTeam == playerTeam || secondRoundTeam == playInTeam);

                        wins = random.Next(1, 5);
                        if (random.NextDouble() < winChanceAdjustment)
                        {
                            wins = 4;
                        }

                        if (wins == 4)
                        {
                            loses = random.Next(0, 4);
                            Console.WriteLine($"O {playerTeam} enfrentou o {secondRoundTeam} no segundo round e ganhou por {wins} - {loses}!");
                            Console.WriteLine(" ");
                            Console.WriteLine("==============================================================================");
                            Console.WriteLine(" ");

                            do
                            {
                                cfTeam = westernNbaTeams[random.Next(0, 15)];
                            } while (cfTeam == firstRoundTeam || cfTeam == secondRoundTeam || cfTeam == playerTeam || cfTeam == playInTeam);

                            wins = random.Next(1, 5);
                            if (random.NextDouble() < winChanceAdjustment)
                            {
                                wins = 4;
                            }

                            if (wins == 4)
                            {
                                loses = random.Next(0, 4);
                                Console.WriteLine($"O {playerTeam} enfrentou o {cfTeam} nas finais de conferência e ganhou por {wins} - {loses}!");
                                Console.WriteLine(" ");
                                Console.WriteLine("==============================================================================");
                                Console.WriteLine(" ");

                                finalTeam = easternNbaTeams[random.Next(0, 15)];

                                wins = random.Next(1, 5);
                                if (random.NextDouble() < winChanceAdjustment)
                                {
                                    wins = 4;
                                }

                                if (wins == 4)
                                {
                                    loses = random.Next(0, 4);
                                    Console.WriteLine($"O {playerTeam} enfrentou o {finalTeam} nas finais da NBA e ganhou por {wins} - {loses}!");
                                    Console.WriteLine(" ");
                                    Console.WriteLine("==============================================================================");
                                    Console.WriteLine(" ");
                                    nbaChamp++;
                                    FVMPWin = random.Next(0, 2) == 0;
                                }
                                else
                                {
                                    loses = 4;
                                    Console.WriteLine($"O {playerTeam} enfrentou o {finalTeam} na final da NBA e perdeu por {loses} - {wins}.");
                                }
                            }
                            else
                            {
                                loses = 4;
                                Console.WriteLine($"O {playerTeam} enfrentou o {cfTeam} nas finais de conferência e perdeu por {loses} - {wins}.");
                            }
                        }
                        else
                        {
                            loses = 4;
                            Console.WriteLine($"O {playerTeam} enfrentou o {secondRoundTeam} no segundo round e perdeu por {loses} - {wins}.");
                        }
                    }
                    else
                    {
                        loses = 4;
                        Console.WriteLine($"O {playerTeam} enfrentou o {playInTeam} no play-in e perdeu por {loses} - {wins}.");
                    }
                }
            }
        }

        if (FVMPWin == true)
        {
            nbaFMVP++;
        }

    }

    public static void PlayoffsPerfomance(ref int offsP, ref int offsR, ref int offsA, ref int ovrPlayer, ref string condOffs, string playerName, int seasonCondition, string playerPosition, int regularSeasonPPG, int regularSeasonRPG, int regularSeasonAPG)
    {
        Random random = new Random();

        if (seasonCondition != 3)
        {
            if (ovrPlayer > 95)
            {
                offsP = random.Next(Math.Max(23 - 3, 0), Math.Min(39 + 3, 50));
                offsR = random.Next(Math.Max(5 - 3, 0), Math.Min(13 + 3, 20));
                offsA = random.Next(Math.Max(5 - 3, 0), Math.Min(13 + 3, 20));
            }
            else if (ovrPlayer > 90)
            {
                offsP = random.Next(Math.Max(21 - 3, 0), Math.Min(33 + 3, 50));
                offsR = random.Next(Math.Max(5 - 3, 0), Math.Min(9 + 3, 20));
                offsA = random.Next(Math.Max(5 - 3, 0), Math.Min(9 + 3, 20));
            }
            else if (ovrPlayer > 86)
            {
                offsP = random.Next(Math.Max(18 - 3, 0), Math.Min(28 + 3, 50));
                offsR = random.Next(Math.Max(4 - 3, 0), Math.Min(8 + 3, 20));
                offsA = random.Next(Math.Max(4 - 3, 0), Math.Min(9 + 3, 20));
            }
            else if (ovrPlayer > 82)
            {
                offsP = random.Next(Math.Max(17 - 3, 0), Math.Min(25 + 3, 50));
                offsR = random.Next(Math.Max(3 - 3, 0), Math.Min(8 + 3, 20));
                offsA = random.Next(Math.Max(4 - 3, 0), Math.Min(9 + 3, 20));
            }
            else if (ovrPlayer > 79)
            {
                offsP = random.Next(Math.Max(14 - 3, 0), Math.Min(19 + 3, 50));
                offsR = random.Next(Math.Max(2 - 3, 0), Math.Min(7 + 3, 20));
                offsA = random.Next(Math.Max(3 - 3, 0), Math.Min(8 + 3, 20));
            }
            else if (ovrPlayer > 74)
            {
                offsP = random.Next(Math.Max(11 - 3, 0), Math.Min(17 + 3, 50));
                offsR = random.Next(Math.Max(2 - 3, 0), Math.Min(5 + 3, 20));
                offsA = random.Next(Math.Max(3 - 3, 0), Math.Min(6 + 3, 20));
            }
            else
            {
                offsP = random.Next(Math.Max(9 - 3, 0), Math.Min(15 + 3, 50));
                offsR = random.Next(Math.Max(2 - 3, 0), Math.Min(5 + 3, 20));
                offsA = random.Next(Math.Max(3 - 3, 0), Math.Min(5 + 3, 20));
            }

            if (playerPosition == "PG" && random.NextDouble() < 0.5)
            {
                offsA += random.Next(0, 3);
            }
            else if ((playerPosition == "SG" || playerPosition == "SF") && random.NextDouble() < 0.5)
            {
                offsP += random.Next(0, 3);
            }
            else if ((playerPosition == "PF" || playerPosition == "C") && random.NextDouble() < 0.5)
            {
                offsR += random.Next(0, 3);
            }

            Console.WriteLine(" ");
            Console.WriteLine("==============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine($"O jogador {playerName} obteve as seguintes médias nos playoffs:");
            Console.WriteLine(" ");
            Console.WriteLine($"{offsP} pontos por jogo");
            Console.WriteLine($"{offsR} rebotes por jogo");
            Console.WriteLine($"{offsA} assistências por jogo");
            Console.WriteLine(" ");
        }

    }


    public static void FreeAgency(ref string playerTeam, string[] allNbaTeams, string[] easternNbaTeams, string[] westernNbaTeams, ref string teamConference)
    {
        Random random = new Random();
        string team1, team2, team3;
        int selected = 0;
        string resposta = string.Empty;

        do
        {
            team1 = allNbaTeams[random.Next(allNbaTeams.Length)];
        } while (team1 == playerTeam);

        do
        {
            team2 = allNbaTeams[random.Next(allNbaTeams.Length)];
        } while (team2 == playerTeam || team2 == team1);

        do
        {
            team3 = allNbaTeams[random.Next(allNbaTeams.Length)];
        } while (team3 == playerTeam || team3 == team1 || team3 == team2);

        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");
        Console.WriteLine($"Seu contrato com o {playerTeam} acabou. Você recebeu uma proposta de extensão por 3 anos, deseja continuar?\nResponda com sim ou não");
        Console.WriteLine(" ");

        do
        {
            resposta = Console.ReadLine()?.ToUpper() ?? string.Empty;

            if (resposta == "NAO")
            {
                resposta = "NÃO";
            }
        } while (resposta != "SIM" && resposta != "NÃO");

        if (resposta == "NÃO")
        {
            Console.WriteLine(" ");
            Console.WriteLine($"Você recebeu 3 propostas, todas contratos máximos por 3 anos:");
            Console.WriteLine($"1- {team1}");
            Console.WriteLine($"2- {team2}");
            Console.WriteLine($"3- {team3}");
            Console.WriteLine(" ");
            Console.WriteLine("Qual das 3 você deseja aceitar?");

            bool validInput;

            do
            {
                string input = Console.ReadLine()?.ToUpper() ?? string.Empty;
                validInput = int.TryParse(input, out selected);

                if (!validInput || selected < 1 || selected > 3)
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número de 1 a 3.");
                }
            } while (!validInput || selected < 1 || selected > 3);

            playerTeam = selected switch
            {
                1 => team1,
                2 => team2,
                3 => team3,
                _ => playerTeam
            };

            teamConference = easternNbaTeams.Contains(playerTeam) ? "Leste" : "Oeste";
        }
        Console.WriteLine($"Bem-vindo ao {playerTeam}!");
        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");
    }

}
