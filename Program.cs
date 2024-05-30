using System;

class Program
{
    public static void Main(string[] args)
    {

        Random random = new Random();

        Console.Clear();
        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");

        Console.WriteLine("Bem vindo ao simulador de carreira NBA!");

        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");

        // Obtenção de nome e posição do jogador

        string playerName = GetPlayerName();
        string playerPosition = GetplayerPosition();
        Console.Clear();
        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");

        int playerAge = 19;
        string continueSim = string.Empty;
        string condOffs = string.Empty;

        // Array de todos times da Nba
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

        // Chamando a função draft e estabelecendo o time inicial do jogador
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
        int teamRookieForce = TeamForce(nbaTeamSelected);

        // Variáveis que serão utilizadas para saber o Rookie Year
        int regularSeasonGamesPlayed = 0,
            regularSeasonPPG = 0,
            regularSeasonRPG = 0,
            regularSeasonAPG = 0,
            ovr = 0;

        bool winRoy = false;

        // Função que simula o roy
        RookieYear(ref teamRookieForce, ref regularSeasonGamesPlayed, ref regularSeasonPPG, ref regularSeasonRPG, ref regularSeasonAPG, ref winRoy, playerPosition, ref ovr, pickDraft);

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
            totalRSMediaStats = 0;

        int teamPosition = 0;

        RegularSeasonTotalStats(regularSeasonGamesPlayed, regularSeasonPPG, regularSeasonRPG, regularSeasonAPG, ref totalP, ref totalR, ref totalA, ref totalRSMediaStats, ref totalG);

        // Cálculo OVR Rookie
        int playerOVR = OvrRookie(totalRSMediaStats, ref ovr);

        Console.WriteLine($"{playerName} teve um overral de {playerOVR} ao final da temporada regular!");
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
            Console.WriteLine("Pronto para os playoffs?");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();

            // Simulação dos Playoffs no Rookie year
            PlayoffsSim(seasonCondition, easternNbaTeams, westernNbaTeams, teamConference, playerTeam, ref nbaChamp, ref nbaFMVP, playerOVR, teamPosition, playerName);

            // Stats nos Playoffs no Rookie year
            PlayoffsPerfomance(ref offsP, ref offsR, ref offsA, ref playerOVR, ref condOffs, playerName, seasonCondition, playerPosition, regularSeasonPPG, regularSeasonRPG, regularSeasonAPG, totalRSMediaStats);
        }

        playerAge++;

        // Próximas temporadas
        int teamForce = teamRookieForce;
        string condRegularSeason = string.Empty;
        int seasonCount = 2;
        int mvp = 0;

        Console.WriteLine("Pronto para a segunda temporada?");
        Console.WriteLine("Pressione ENTER para continuar...");
        Console.ReadLine();

        do
        {
            Console.Clear();
            Console.WriteLine(" ");
            Console.WriteLine("==============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine($"Vamos para a sua {seasonCount}º temporada!");
            Console.WriteLine(" ");
            Console.WriteLine("==============================================================================");
            Console.WriteLine(" ");

            // Simulando e imprimindo os stats de temporada regular
            RegularSeasonStats(ref playerOVR, ref regularSeasonGamesPlayed, ref regularSeasonPPG, ref regularSeasonRPG, ref regularSeasonAPG, totalRSMediaStats, playerAge, playerPosition);

            // Calculando os stats totais a cada season
            RegularSeasonTotalStats(regularSeasonGamesPlayed, regularSeasonPPG, regularSeasonRPG, regularSeasonAPG, ref totalP, ref totalR, ref totalA, ref totalRSMediaStats, ref totalG);

            // Saber se o jogador ganhou ou não o MVP
            bool winMVP = MVP(playerOVR, totalRSMediaStats, regularSeasonGamesPlayed, seasonCondition);

            // Imprimindo stats e OVR da Temporada Regular
            Console.WriteLine($"O jogador {playerName} jogou {regularSeasonGamesPlayed} jogos na sua {seasonCount}º temporada e obteve as seguintes médias:");
            Console.WriteLine(" ");
            Console.WriteLine($"{regularSeasonPPG} pontos por jogo");
            Console.WriteLine($"{regularSeasonRPG} rebotes por jogo");
            Console.WriteLine($"{regularSeasonAPG} assistências por jogo");
            Console.WriteLine(" ");
            Console.WriteLine($"{playerName} teve um overall de {playerOVR} ao final da temporada regular!");
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

            // Variável para saber a posição do time na temporada anterior, inicializando com um valor aleatório
            int oldTeamPosition = random.Next(6, 16);

            // Simulando e imrpimindo a temporada regular
            TeamSeed(playerTeam, teamForce, ref condRegularSeason, ref seasonCondition, ref TeamConference, playerOVR, ref teamPosition, ref oldTeamPosition);

            // Imrpimindo a perfomance de temporada regular
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
                PlayoffsSim(seasonCondition, easternNbaTeams, westernNbaTeams, teamConference, playerTeam, ref nbaChamp, ref nbaFMVP, playerOVR, teamPosition, playerName);

                // Stats nos Playoffs
                PlayoffsPerfomance(ref offsP, ref offsR, ref offsA, ref playerOVR, ref condOffs, playerName, seasonCondition, playerPosition, regularSeasonPPG, regularSeasonRPG, regularSeasonAPG, totalRSMediaStats);
            }

            seasonCount++;
            playerAge++;

            if (seasonCount == 5 || seasonCount == 8 || seasonCount == 11 || seasonCount == 14 || seasonCount == 17)
            {
                // Free Agency
                FreeAgency(ref playerTeam, allNbaTeams, easternNbaTeams, westernNbaTeams, ref teamConference, ref teamForce);
            }

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
                Console.ReadLine();
                break;
            }

            // Pergunta se deseja continuar a simulação
            Console.WriteLine(" ");
            Console.WriteLine("==============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine($"Deseja continuar a simulação? {playerName} está com {playerAge} anos, indo para sua {seasonCount}º temporada na liga.");
            Console.WriteLine("Digite 'SIM' ou pressione Enter para continuar, digite 'NAO' para encerrar a simulação.");
            continueSim = Console.ReadLine()?.ToUpper() ?? string.Empty;
            if (continueSim == "NAO")
            {
                continueSim = "NÃO";
            }

            Console.Clear();
        } while (continueSim == "SIM" && playerAge < 40 || continueSim == string.Empty && playerAge < 40);

        if (continueSim == "NÃO")
        {
            Console.WriteLine(" ");
            Console.WriteLine("==============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine($"A carreira de {playerName} chegou ao fim com {totalG} jogos ao longo de {seasonCount - 1} temporadas.\n{totalP} pontos\n{totalR} rebotes\n{totalA} assistências");
            Console.WriteLine($"Além de conquistar {nbaChamp} títulos, {mvp} MVPs e {nbaFMVP} FMVPs!");
            Console.WriteLine(" ");
            Console.WriteLine("==============================================================================");
            Console.WriteLine(" ");
            Console.ReadLine();
        }

    }

    // Obtenção de nome de jogador
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

    // Obtenção de posição de jogador
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

    // Simulação do Draft
    public static string Draft(ref int pickDraft, ref string playerPosition, ref string nbaTeamSelected, string[] allNbaTeams, string playerName)
    {
        Random random = new Random();

        pickDraft = random.Next(1, 11);
        nbaTeamSelected = allNbaTeams[random.Next(0, 30)];

        string Draft = $"O jogador {playerName}, um {playerPosition}, foi escolhido pelo {nbaTeamSelected} na {pickDraft}º escolha.";

        return Draft;
    }

    // Determinar a Conferência de um determinado time
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

    // Determinar a força do time
    public static int TeamForce(string nbaTeamSelected)
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

    // Simular o Rookie Year
    public static void RookieYear(ref int teamRookieForce, ref int regularSeasonGamesPlayed, ref int regularSeasonPPG, ref int regularSeasonRPG, ref int regularSeasonAPG, ref bool winRoy, string playerPosition, ref int ovr, int pickDraft)
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
            regularSeasonPPG = random.Next(12, 21);
        }
        else if (teamRookieForce == 2)
        {
            regularSeasonPPG = random.Next(13, 22);
        }
        else
        {
            regularSeasonPPG = random.Next(14, 25);
        }

        // Obtendo o número de rebotes por jogo   
        if (teamRookieForce == 1)
        {
            regularSeasonRPG = random.Next(3, 6);
        }
        else if (teamRookieForce == 2)
        {
            regularSeasonRPG = random.Next(3, 8);
        }
        else
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
            regularSeasonAPG = random.Next(3, 7);
        }
        else
        {
            regularSeasonAPG = random.Next(3, 7);
        }

        // Chance de melhorar estatísticas baseado na posição do jogador
        if (playerPosition == "PG")
        {
            regularSeasonAPG += random.Next(0, 4);
            ovr += 1;
        }
        else if (playerPosition == "SG" || playerPosition == "PF")
        {
            regularSeasonPPG += random.Next(0, 4);
            ovr += 1;
        }
        else if (playerPosition == "PF")
        {
            regularSeasonPPG += random.Next(0, 3);
            regularSeasonRPG += random.Next(0, 3);
            ovr += 1;
        }
        else if (playerPosition == "C")
        {
            regularSeasonRPG += random.Next(0, 4);
            ovr += 1;
        }

        int ProbWinRoy = 0;

        // Verificar se o jogador é considerado "GOAT status"
        if (random.Next(1, 26) == 1)
        {
            regularSeasonPPG += 4;
            regularSeasonRPG += 2;
            regularSeasonAPG += 2;
            ovr += 3;
            ProbWinRoy += 10;
        }

        int regularTotal = regularSeasonPPG + regularSeasonRPG + regularSeasonAPG;

        // Calculando probabilidade de ganhar o ROY
        if (teamRookieForce == 1 && regularSeasonGamesPlayed >= 58 && regularTotal >= 24)
        {
            ProbWinRoy = random.Next(15, 85);
        }
        else if (teamRookieForce == 2 && regularSeasonGamesPlayed >= 58 && regularTotal >= 24)
        {
            ProbWinRoy = random.Next(25, 85);
        }
        else if (teamRookieForce == 3 && regularSeasonGamesPlayed >= 58 && regularTotal >= 24)
        {
            ProbWinRoy = random.Next(35, 85);
        }

        // Caso primeira escolha, as chances aumentam
        if (pickDraft == 1 || regularTotal >= 25)
        {
            ProbWinRoy += random.Next(1, 16);
        }

        if (ProbWinRoy >= 50)
        {
            winRoy = true;
        }
    }

    // Simular a seed do Rookie Year
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

    // Simular os stats totais de temporada regular
    public static void RegularSeasonTotalStats(int regularSeasonGamesPlayed, int regularSeasonPPG, int regularSeasonRPG, int regularSeasonAPG, ref int totalP, ref int totalR, ref int totalA, ref int totalRSMediaStats, ref int totalG)
    {
        totalRSMediaStats = regularSeasonPPG + regularSeasonRPG + regularSeasonAPG;

        totalP += regularSeasonPPG * regularSeasonGamesPlayed;
        totalR += regularSeasonRPG * regularSeasonGamesPlayed;
        totalA += regularSeasonAPG * regularSeasonGamesPlayed;
        totalG += regularSeasonGamesPlayed;
    }

    // Simular o Overall de rookie
    public static int OvrRookie(int totalRSMediaStats, ref int ovr)
    {

        Random random = new Random();

        if (totalRSMediaStats >= 27)
        {
            ovr = random.Next(80, 85);
        }
        else if (totalRSMediaStats >= 23)
        {
            ovr = random.Next(77, 83);
        }
        else
        {
            ovr = random.Next(73, 79);
        }

        return ovr;
    }

    // Simular a seed
    public static void TeamSeed(string playerTeam, int teamForce, ref string condRegularSeason, ref int seasonCondition, ref string TeamConference, int playerOVR, ref int teamPosition, ref int oldTeamPosition)
    {
        Random random = new Random();

        int wins = 0,
            loses = 0;

        teamPosition = 0;
        seasonCondition = 0;

        if (teamForce == 1)
        {
            wins = random.Next(46, 63);
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

        int winIncrease = 0;
        double winChanceAdjustment = 0.0;

        if (playerOVR > 95)
        {
            winIncrease = random.Next(2, 15);
            winChanceAdjustment = 0.3;
        }
        else if (playerOVR > 90)
        {
            winIncrease = random.Next(3, 8);
            winChanceAdjustment = 0.25;
        }
        else if (playerOVR > 85)
        {
            winIncrease = random.Next(2, 5);
            winChanceAdjustment = 0.2;
        }

        wins += winIncrease;

        if (winChanceAdjustment != 0)
        {
            teamPosition = (int)((1 - winChanceAdjustment) * (wins / 82.0) * 15);
            teamPosition = Math.Max(1, Math.Min(teamPosition, 15));
        }

        if (teamPosition < oldTeamPosition && wins < 66)
        {
            wins += random.Next(0, 6);
        }

        wins = Math.Min(wins, 78);

        loses = 82 - wins;

        if (wins >= 67)
        {
            teamPosition = 1;
            seasonCondition = 1;
            condRegularSeason = $"O {playerTeam} obteve uma seed de {wins} W - {loses} L e classificou para os playoffs em {teamPosition}º no {TeamConference}!";
        }
        else if (wins >= 63)
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

        oldTeamPosition = teamPosition;
    }

    // Simular os stats da temporada regular e calcular o ovr com base neles
    public static void RegularSeasonStats(ref int playerOVR, ref int regularSeasonGamesPlayed, ref int regularSeasonPPG, ref int regularSeasonRPG, ref int regularSeasonAPG, int totalRSMediaStats, int playerAge, string playerPosition)
    {
        Random random = new Random();

        int oldPPG = regularSeasonPPG;
        int oldRPG = regularSeasonRPG;
        int oldAPG = regularSeasonAPG;

        regularSeasonGamesPlayed = random.Next(65, 83);

        // Simulaçãoo de stats com base no overall
        if (playerOVR > 95)
        {
            regularSeasonPPG = random.Next(23, 38);
            regularSeasonRPG = random.Next(6, 9);
            regularSeasonAPG = random.Next(5, 9);
        }
        else if (playerOVR > 90)
        {
            regularSeasonPPG = random.Next(21, 34);
            regularSeasonRPG = random.Next(5, 9);
            regularSeasonAPG = random.Next(4, 9);
        }
        else if (playerOVR > 86)
        {
            regularSeasonPPG = random.Next(18, 29);
            regularSeasonRPG = random.Next(4, 9);
            regularSeasonAPG = random.Next(4, 8);
        }
        else if (playerOVR > 82)
        {
            regularSeasonPPG = random.Next(18, 26);
            regularSeasonRPG = random.Next(4, 8);
            regularSeasonAPG = random.Next(3, 7);
        }
        else if (playerOVR > 79)
        {
            regularSeasonPPG = random.Next(16, 19);
            regularSeasonRPG = random.Next(3, 7);
            regularSeasonAPG = random.Next(3, 6);
        }
        else if (playerOVR > 74)
        {
            regularSeasonPPG = random.Next(11, 19);
            regularSeasonRPG = random.Next(2, 6);
            regularSeasonAPG = random.Next(3, 6);
        }
        else
        {
            regularSeasonPPG = random.Next(9, 15);
            regularSeasonRPG = random.Next(2, 5);
            regularSeasonAPG = random.Next(3, 5);
        }

        // Controlar consistência de evolução e variação em estatísticas

        int diffPPG = regularSeasonPPG - oldPPG;
        int diffRPG = regularSeasonRPG - oldRPG;
        int diffAPG = regularSeasonAPG - oldAPG;

        if (playerAge <= 34)
        {
            diffPPG = regularSeasonPPG - oldPPG;
            diffRPG = regularSeasonRPG - oldRPG;
            diffAPG = regularSeasonAPG - oldAPG;

            if (diffPPG > 4)
            {
                regularSeasonPPG = oldPPG + 2;
            }
            else if (diffPPG < -2)
            {
                regularSeasonPPG = oldPPG - 2;
            }

            if (diffRPG > 4)
            {
                regularSeasonRPG = oldRPG + 2;
            }
            else if (diffRPG < -2)
            {
                regularSeasonRPG = oldRPG - 2;
            }

            if (diffAPG > 4)
            {
                regularSeasonAPG = oldAPG + 2;
            }
            else if (diffAPG < -2)
            {
                regularSeasonAPG = oldAPG - 2;
            }
        }

        // Bonificação de stats com base na posição
        if (random.NextDouble() < 0.5 && playerAge <= 32)
        {
            switch (playerPosition)
            {
                case "PG":
                    if (regularSeasonAPG <= 10)
                    {
                        regularSeasonAPG += random.Next(0, 4);
                        regularSeasonPPG -= random.Next(0, 2);
                    }
                    break;
                case "SG":
                    if (regularSeasonPPG <= 32)
                    {
                        regularSeasonPPG += random.Next(0, 3);
                        if (regularSeasonAPG >= 4 || regularSeasonRPG >= 4)
                        {
                            regularSeasonAPG -= random.Next(0, 2);
                            regularSeasonRPG -= random.Next(0, 2);
                        }
                    }
                    break;
                case "SF":
                    if (regularSeasonPPG <= 32)
                    {
                        regularSeasonPPG += random.Next(0, 2);
                    }
                    break;
                case "PF":
                    if (regularSeasonRPG <= 12)
                    {
                        regularSeasonPPG += random.Next(0, 2);
                        regularSeasonRPG += random.Next(0, 2);
                        if (regularSeasonAPG >= 6)
                        {
                            regularSeasonAPG -= random.Next(0, 2);
                        }
                    }
                    break;
                case "C":
                    if (regularSeasonRPG <= 8)
                    {
                        regularSeasonRPG += random.Next(0, 3);
                        if (regularSeasonAPG >= 6)
                        {
                            regularSeasonAPG -= random.Next(0, 3);
                        }
                    }
                    break;
            }
        }

        // Controle de valor nulo
        if (regularSeasonPPG < 0) regularSeasonPPG = 12;
        if (regularSeasonRPG < 0) regularSeasonRPG = 3;
        if (regularSeasonAPG < 0) regularSeasonAPG = 3;

        totalRSMediaStats = regularSeasonPPG + regularSeasonRPG + regularSeasonAPG;

        // Bonificação de melhoria dos stats na season
        if (totalRSMediaStats > (oldPPG + oldRPG + oldAPG) && playerAge <= 32)
        {
            if (playerOVR < 94)
            {
                playerOVR += random.Next(0, 2);
            }
            else if (playerOVR < 90)
            {
                playerOVR += random.Next(0, 3);
            }
            else if (playerOVR < 86)
            {
                playerOVR += random.Next(0, 4);
            }
            else if (playerOVR < 82)
            {
                playerOVR += random.Next(1, 3);
            }

            // Bonificação de jogador jovem
            if (playerAge <= 23 && playerOVR <= 85)
            {
                playerOVR += random.Next(0, 4);
                regularSeasonPPG += random.Next(0, 4);
                regularSeasonRPG += random.Next(0, 3);
                regularSeasonAPG += random.Next(0, 3);
            }
        }
        else if (playerAge >= 29) // Penalização no OVR por piora de stats
        {
            playerOVR -= random.Next(0, 3);
        }

        // Downgrade no overall por envelhecimento
        
        if (playerAge >= 36)
        {
            playerOVR -= random.Next(1, 5);
        }
        else if (playerAge >= 33)
        {
            playerOVR -= random.Next(0, 4);
        }

        // Suporte para jogadores que não estão evoluindo
        if (playerAge <= 26 && playerOVR <= 86)
        {
            playerOVR += random.Next(0, 3);
            regularSeasonPPG += random.Next(0, 3);
            regularSeasonRPG += random.Next(0, 3);
            regularSeasonAPG += random.Next(0, 3);
        }
    }

    // Verificar se o ojogador ganhou ou não o MVP
    public static bool MVP(int playerOVR, int totalRSMediaStats, int regularSeasonGamesPlayed, int seasonCondition)
    {
        Random random = new Random();
        int numberMVP = random.Next(0, 10);
        
        if (totalRSMediaStats >= 50)
        {
            numberMVP += 4;
        }
        else if (totalRSMediaStats >= 45)
        {
            numberMVP += 2;
        }

        bool mvpWin = false;

        if (playerOVR >= 88 && totalRSMediaStats > 39 && regularSeasonGamesPlayed > 58 && numberMVP >= 7 && seasonCondition != 3)
        {
            mvpWin = true;
        }

        return mvpWin;
    }

    // Simular os playoffs
    public static void PlayoffsSim(int seasonCondition, string[] easternNbaTeams, string[] westernNbaTeams, string teamConference, string playerTeam, ref int nbaChamp, ref int nbaFMVP, int playerOVR, int teamPosition, string playerName)
    {
        Random random = new Random();
        string playInTeam = string.Empty,
                firstRoundTeam = string.Empty,
                secondRoundTeam = string.Empty,
                cfTeam = string.Empty,
                finalTeam = string.Empty;

        int wins = 0,
            loses = 0;

        bool FMVPwin = false;
        int chanceToWinFVMP = random.Next(0, 3);
        double winChanceAdjustment = 0;

        if (teamConference == "Leste")
        {
            if (playerOVR > 95 || teamPosition >= 3)
            {
                winChanceAdjustment = 0.60;
            }
            else if (playerOVR > 90)
            {
                winChanceAdjustment = 0.30;
            }
            else if (playerOVR > 86)
            {
                winChanceAdjustment = 0.15;
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
                                nbaChamp++;
                                if (chanceToWinFVMP != 0)
                                {
                                    Console.WriteLine($"Além disso, {playerName} foi coroado o FMVP!");
                                    Console.WriteLine(" ");
                                    Console.WriteLine("==============================================================================");
                                    Console.WriteLine(" ");
                                    FMVPwin = true;
                                }
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
                                    nbaChamp++;
                                    if (chanceToWinFVMP != 0)
                                    {
                                        Console.WriteLine($"Além disso, {playerName} foi coroado o FMVP!");
                                        Console.WriteLine(" ");
                                        Console.WriteLine("==============================================================================");
                                        Console.WriteLine(" ");
                                        FMVPwin = true;
                                    }
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

            if (playerOVR > 95 || teamPosition >= 3)
            {
                winChanceAdjustment = 0.60;
            }
            else if (playerOVR > 90)
            {
                winChanceAdjustment = 0.30;
            }
            else if (playerOVR > 86)
            {
                winChanceAdjustment = 0.15;
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
                            } while (finalTeam == playerTeam);

                            wins = random.Next(1, 5);
                            if (random.NextDouble() < winChanceAdjustment)
                            {
                                wins = 4;
                            }

                            if (wins == 4)
                            {
                                loses = random.Next(0, 4);
                                Console.WriteLine($"O {playerTeam} enfrentou o {finalTeam} nas finais da NBA e ganhou por {wins} - {loses}!");
                                nbaChamp++;
                                if (chanceToWinFVMP != 0)
                                {
                                    Console.WriteLine($"Além disso, {playerName} foi coroado o FMVP!");
                                    Console.WriteLine(" ");
                                    Console.WriteLine("==============================================================================");
                                    Console.WriteLine(" ");
                                    FMVPwin = true;
                                }
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
            else if (seasonCondition == 2) // Play-In
            {
                do
                {
                    playInTeam = westernNbaTeams[random.Next(0, 15)];
                } while (playInTeam == playerTeam);

                wins = 1;
                Console.WriteLine($"O {playerTeam} enfrentou o {playInTeam} no play-in e ganhou por 1 - 0!");
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

                            do
                            {
                                finalTeam = easternNbaTeams[random.Next(0, 15)];
                            } while (finalTeam == playerTeam);

                            wins = random.Next(1, 5);
                            if (random.NextDouble() < winChanceAdjustment)
                            {
                                wins = 4;
                            }

                            if (wins == 4)
                            {
                                loses = random.Next(0, 4);
                                Console.WriteLine($"O {playerTeam} enfrentou o {finalTeam} nas finais da NBA e ganhou por {wins} - {loses}!");
                                nbaChamp++;
                                if (chanceToWinFVMP != 0)
                                {
                                    Console.WriteLine($"Além disso, {playerName} foi coroado o FMVP!");
                                    Console.WriteLine(" ");
                                    Console.WriteLine("==============================================================================");
                                    Console.WriteLine(" ");
                                    FMVPwin = true;
                                }
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
        }

        if (FMVPwin == true)
        {
            nbaFMVP++;
        }

    }

    // Simular a perfomance nos playoffs
    public static void PlayoffsPerfomance(ref int offsP, ref int offsR, ref int offsA, ref int playerOVR, ref string condOffs, string playerName, int seasonCondition, string playerPosition, int regularSeasonPPG, int regularSeasonRPG, int regularSeasonAPG, int totalRSMediaStats)
    {
        Random random = new Random();

        if (seasonCondition != 3)
        {
            int pointsVariationPositive, pointsVariationNegative;
            int reboundsVariationPositive, reboundsVariationNegative;
            int assistsVariationPositive, assistsVariationNegative;

            if (playerOVR < 80)
            {
                pointsVariationPositive = 3; pointsVariationNegative = 5;
                reboundsVariationPositive = 2; reboundsVariationNegative = 4;
                assistsVariationPositive = 2; assistsVariationNegative = 4;
            }
            else if (playerOVR < 86)
            {
                pointsVariationPositive = 4; pointsVariationNegative = 4;
                reboundsVariationPositive = 2; reboundsVariationNegative = 3;
                assistsVariationPositive = 2; assistsVariationNegative = 3;
            }
            else if (playerOVR < 92)
            {
                pointsVariationPositive = 5; pointsVariationNegative = 4;
                reboundsVariationPositive = 3; reboundsVariationNegative = 2;
                assistsVariationPositive = 3; assistsVariationNegative = 2;
            }
            else
            {
                pointsVariationPositive = 5; pointsVariationNegative = 3;
                reboundsVariationPositive = 2; reboundsVariationNegative = 1;
                assistsVariationPositive = 2; assistsVariationNegative = 1;
            }

            offsP = regularSeasonPPG + random.Next(-pointsVariationNegative, pointsVariationPositive + 1);
            offsR = regularSeasonRPG + random.Next(-reboundsVariationNegative, reboundsVariationPositive + 1);
            offsA = regularSeasonAPG + random.Next(-assistsVariationNegative, assistsVariationPositive + 1);

            offsP = Math.Max(offsP, 18);
            offsR = Math.Max(offsR, 4);
            offsA = Math.Max(offsA, 4);

            if (playerPosition == "PG" && random.NextDouble() < 0.20)
            {
                offsA += random.Next(0, 4);
                offsP -= random.Next(0, 2);
            }
            else if ((playerPosition == "SG" || playerPosition == "SF") && random.NextDouble() < 0.20)
            {
                offsP += random.Next(0, 4);
            }
            else if ((playerPosition == "PF" || playerPosition == "C") && random.NextDouble() < 0.20)
            {
                offsR += random.Next(0, 4);
                offsP += random.Next(0, 2);
                offsA -= random.Next(0, 2);
            }

            Console.WriteLine(" ");
            Console.WriteLine("==============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine($"O jogador {playerName} obteve as seguintes médias nos playoffs:");
            Console.WriteLine(" ");
            Console.WriteLine($"{offsP} pontos por jogo");
            Console.WriteLine($"{offsR} rebotes por jogo");
            Console.WriteLine($"{offsA} assistências por jogo");

            int totalOffsStats = offsR + offsP + offsA;

            if (totalRSMediaStats < totalOffsStats)
            {
                playerOVR++;
            }
        }

    }

    // Simular a Free Agency para troca de time
    public static void FreeAgency(ref string playerTeam, string[] allNbaTeams, string[] easternNbaTeams, string[] westernNbaTeams, ref string teamConference, ref int teamForce)
    {
        Random random = new Random();
        string team1, team2, team3;
        int selected = 0;
        string resposta = string.Empty;

        // Selecionar 3 times aleatórios da liga que não sejam o time atual do jogador
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
        Console.WriteLine($"Seu contrato com o {playerTeam} acabou. Você recebeu uma proposta de extensão com contrato máximo por 3 anos, deseja renovar?\nResponda com 'SIM' ou pressione Enter ou 'NÃO'");
        Console.WriteLine(" ");

            resposta = Console.ReadLine()?.ToUpper() ?? string.Empty;

            if (resposta == "NAO")
            {
                resposta = "NÃO";
            }

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

            // Ajustar a conferência do time escolhido usando a função Conference
            teamConference = Conference(playerTeam, easternNbaTeams, westernNbaTeams);

            // Atualizando a força do time selecionado por um padrão pré determinado
            teamForce = TeamForce(playerTeam);
        }
    }
}
