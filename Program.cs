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

        int playerAge = 18;

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
        string nbaTeamSelected = "";

        // Função Draft
        string DraftInfos = Draft(ref pickDraft, ref playerPosition, ref nbaTeamSelected, allNbaTeams, playerName);

        string TeamConference = Conference(nbaTeamSelected, easternNbaTeams, westernNbaTeams);

        Console.WriteLine(DraftInfos);

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
            Console.WriteLine("Além de ganhar o roy!");
        }
        else
        {
            Console.WriteLine("Além disso, o jogador não ganhou o roy.");
        }
        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");

        // Imprimindo a seed e a condição de pós-temporada
        string condRookie = " ";
        int seasonCondition = 0;

        TeamSeedRookie(nbaTeamSelected, teamRookieForce, ref condRookie, ref seasonCondition, ref TeamConference);

        Console.WriteLine(condRookie);
        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");

        // Calculando total stats na Regular Season
        int totalP = 0,
            totalR = 0,
            totalA = 0,
            totalMediaStats = 0;

        RegularSeasonTotalStats(ref regularSeasonGamesPlayed, ref regularSeasonPPG, ref regularSeasonRPG, ref regularSeasonAPG, ref totalP, ref totalR, ref totalA, ref totalMediaStats);

        int totalG = regularSeasonGamesPlayed;

        // Cálculo OVR Rookie
        int ovrPlayer = OvrRookie(totalMediaStats);

        Console.WriteLine($"{playerName} teve um overral de {ovrPlayer} ao final da temporada regular!");
        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");

        // Simulação dos Playoffs
        int pTotalP = 0,
            pTotalR = 0,
            pTotalA = 0,
            nbaChamp = 0,
            nbaFVMP = 0;

        PlayoffsSim(seasonCondition, easternNbaTeams, westernNbaTeams, teamConference, nbaTeamSelected, ref pTotalP, ref pTotalR, ref pTotalA, ref nbaChamp, ref nbaFVMP);

        // Stats nos Playoffs
        int offsP = 0,
            offsR = 0,
            offsA = 0;
        string condOffs = "";
        playerAge ++;

        PlayoffsPerfomance(ref offsP, ref offsR, ref offsA, ref ovrPlayer, ref condOffs, playerName, seasonCondition);

        // Próximas temporadas
        int teamForce = teamRookieForce;
        string playerTeam = nbaTeamSelected;
        string condRegularSeason = " ";
        int seasonCount = 2;
        int mvp;

        TeamSeed(playerTeam, teamForce, ref condRegularSeason, ref seasonCondition, ref TeamConference);

        RegularSeasonStats(ref ovrPlayer, ref regularSeasonGamesPlayed , ref regularSeasonPPG, ref regularSeasonRPG, ref regularSeasonAPG, ref regularSeasonGamesPlayed, totalMediaStats);
        RegularSeasonTotalStats(ref regularSeasonGamesPlayed, ref regularSeasonPPG, ref regularSeasonRPG, ref regularSeasonAPG, ref totalP, ref totalR, ref totalA, ref totalMediaStats);
        bool winMVP = MVP (int ovrPlayer, int totalMediaStats);

        Console.WriteLine($"O jogador {playerName} jogou {regularSeasonGamesPlayed} jogos na sua {seasonCount}º temporada e obteve as seguintes médias:");
        Console.WriteLine(" ");
        Console.WriteLine($"{regularSeasonPPG} pontos por jogo");
        Console.WriteLine($"{regularSeasonRPG} rebotes por jogo");
        Console.WriteLine($"{regularSeasonAPG} assistências por jogo");
        Console.WriteLine(" ");
        Console.WriteLine($"{playerName} teve um overral de {ovrPlayer} ao final da temporada regular!");
        Console.WriteLine(" ");
        Console.WriteLine("==============================================================================");
        Console.WriteLine(" ");
        if (winMVP == true)
        {
            mvp++;
            Console.WriteLine($"{playerName} foi eleito o MVP da Temporada Regular, parabéns!");
            Console.WriteLine(" ");
            Console.WriteLine("==============================================================================");
            Console.WriteLine(" ");
        }
        PlayoffsSim(seasonCondition, easternNbaTeams, westernNbaTeams, teamConference, nbaTeamSelected, ref pTotalP, ref pTotalR, ref pTotalA, ref nbaChamp, ref nbaFVMP);
        PlayoffsPerfomance(ref offsP, ref offsR, ref offsA, ref ovrPlayer, ref condOffs, playerName, seasonCondition);

        seasonCount ++;
        playerAge ++;

        if (seasonCount == 5 || seasonCount == 8 || seasonCount == 11 || seasonCount == 13 || seasonCount == 15)
        {
            
        }
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
        do
        {
            Console.WriteLine("Digite a posição do seu jogador: \nPG (Armador)\nSG (Ala-armador)\nSF (Ala)\nPF (Ala-Pivô)\nC (Pivô)");
            PlayerPosition = Console.ReadLine().ToUpper();

        } while (!Array.Exists(ValidPositions, position => position == PlayerPosition));
#pragma warning restore CS8602
        return PlayerPosition;
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
        string Conference = "";

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
            regularSeasonGamesPlayed = random.Next(45, 61);
        }
        else if (teamRookieForce == 2)
        {
            regularSeasonGamesPlayed = random.Next(55, 76);
        }
        else
        {
            regularSeasonGamesPlayed = random.Next(60, 80);
        }

        // Obtendo o número de pontos por jogo   
        if (teamRookieForce == 1)
        {
            regularSeasonPPG = random.Next(5, 16);
        }
        else if (teamRookieForce == 2)
        {
            regularSeasonPPG = random.Next(10, 20);
        }
        else
        {
            regularSeasonPPG = random.Next(13, 24);
        }

        // Obtendo o número de rebotes por jogo   
        if (teamRookieForce == 1)
        {
            regularSeasonRPG = random.Next(2, 4);
        }
        else if (teamRookieForce == 2)
        {
            regularSeasonRPG = random.Next(3, 6);
        }
        else if (teamRookieForce == 3)
        {
            regularSeasonRPG = random.Next(4, 7);
        }

        // Obtendo o número de assistências por jogo
        if (teamRookieForce == 1)
        {
            regularSeasonAPG = random.Next(2, 4);
        }
        else if (teamRookieForce == 2)
        {
            regularSeasonAPG = random.Next(3, 6);
        }
        else if (teamRookieForce == 3)
        {
            regularSeasonAPG = random.Next(4, 7);
        }

        int ProbWinroy = 0;

        // Calculando probabilidade de ganhar o roy
        if (teamRookieForce == 1)
        {
            ProbWinroy = random.Next(15, 55);
        }
        else if (teamRookieForce == 2)
        {
            ProbWinroy = random.Next(25, 70);
        }
        else if (teamRookieForce == 3)
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
            wins = random.Next(46, 66);
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
            teamPosition = random.Next(7, 11);
            seasonCondition = 2;
            condRookie = $"O {nbaTeamSelected} obteve uma seed de {wins} W - {loses} L e classificou para o play-in em {teamPosition}º no {TeamConference}!";
        }
        else if (wins <= 41)
        {
            teamPosition = random.Next(11, 16);
            seasonCondition = 3;
            condRookie = $"O {nbaTeamSelected} obteve uma seed de {wins} W - {loses} L no {TeamConference}, ficando em {teamPosition}º e não classificando para a pós-temporada.";
        }
    }

    public static void RegularSeasonTotalStats(ref int regularSeasonGamesPlayed, ref int regularSeasonPPG, ref int regularSeasonRPG, ref int regularSeasonAPG, ref int totalP, ref int totalR, ref int totalA, ref int totalMediaStats)
    {
        totalMediaStats = regularSeasonPPG + regularSeasonRPG + regularSeasonAPG;

        totalP += regularSeasonPPG * regularSeasonGamesPlayed;
        totalR += regularSeasonRPG * regularSeasonGamesPlayed;
        totalA += regularSeasonAPG * regularSeasonGamesPlayed;

    }

    public static int OvrRookie(int totalMediaStats)
    {
        int ovr = 0;

        Random random = new Random();

        if (totalMediaStats >= 29)
        {
            ovr = random.Next(78, 84);
        }
        else if (totalMediaStats >= 23)
        {
            ovr = random.Next(76, 81);
        }
        else
        {
            ovr = random.Next(72, 76);
        }

        return ovr;
    }

    public static void TeamSeed(string playerTeam, int teamForce, ref string condRegularSeason, ref int seasonCondition, ref string TeamConference)
    {
        Random random = new Random();

        int wins = 0,
            loses = 0,
            teamPosition = 0;

        seasonCondition = 0;

        if (teamForce == 1)
        {
            wins = random.Next(46, 66);
        }
        else if (teamForce == 2)
        {
            wins = random.Next(38, 52);
        }
        else if (teamForce == 3)
        {
            wins = random.Next(18, 42);
        }

        loses = 82 - wins;


        if (wins >= 56)
        {
            teamPosition = random.Next(1, 4);
            seasonCondition = 1;
            condRegularSeason = $"O {nbaTeamSelected} obteve uma seed de {wins} W - {loses} L e classificou para os playoffs em {teamPosition}º no {TeamConference}!";
        }
        else if (wins <= 55 && wins >= 48)
        {
            teamPosition = random.Next(4, 7);
            seasonCondition = 1;
            condRegularSeason = $"O {nbaTeamSelected} obteve uma seed de {wins} W - {loses} L e classificou para os playoffs em {teamPosition}º no {TeamConference}!";
        }
        else if (wins <= 47 && wins >= 41)
        {
            teamPosition = random.Next(7, 11);
            seasonCondition = 2;
            condRegularSeason = $"O {nbaTeamSelected} obteve uma seed de {wins} W - {loses} L e classificou para o play-in em {teamPosition}º no {TeamConference}!";
        }
        else if (wins <= 41)
        {
            teamPosition = random.Next(11, 16);
            seasonCondition = 3;
            condRegularSeason = $"O {nbaTeamSelected} obteve uma seed de {wins} W - {loses} L no {TeamConference}, ficando em {teamPosition}º e não classificando para a pós-temporada.";
        }    
    }

    public static void RegularSeasonStats(ref int ovrPlayer, ref int regularSeasonGamesPlayed , ref int regularSeasonPPG, ref int regularSeasonRPG, ref int regularSeasonAPG, ref int regularSeasonGamesPlayed, int totalMediaStats)
    {
        Random random = new Random();

        regularSeasonGamesPlayed = random.Next(65, 83);
    
        int beforeStats = totalMediaStats; 
    
    if (ovrPlayer > 95)
            {
                regularSeasonPPG = random.Next(23, 39);
                regularSeasonRPG = random.Next(5, 13);
                regularSeasonAPG = random.Next(5, 13);
            }
            else if (ovrPlayer > 90)
            {
                regularSeasonPPG = random.Next(21, 33);
                regularSeasonRPG = random.Next(5, 9);
                regularSeasonAPG = random.Next(5, 9);
            }
            else if (ovrPlayer > 86)
            {
                regularSeasonPPG = random.Next(18, 28);
                regularSeasonRPG = random.Next(4, 8);
                regularSeasonAPG = random.Next(4, 9);
            }
            else if (ovrPlayer > 82)
            {
                regularSeasonPPG = random.Next(17, 25);
                regularSeasonRPG = random.Next(3, 8);
                regularSeasonAPG = random.Next(4, 9);
            }
            else if (ovrPlayer > 79)
            {
                regularSeasonPPG = random.Next(14, 19);
                regularSeasonRPG = random.Next(2, 7);
                regularSeasonAPG = random.Next(3, 8);
            }
            else if (ovrPlayer > 74)
            {
                regularSeasonPPG = random.Next(11, 17);
                regularSeasonRPG = random.Next(2, 5);
                regularSeasonAPG = random.Next(3, 6);
            }
            else
            {
                regularSeasonPPG = random.Next(9, 15);
                regularSeasonRPG = random.Next(2, 5);
                regularSeasonAPG = random.Next(3, 5);
            }   
        
        totalMediaStats = regularSeasonPPG + regularSeasonRPG + regularSeasonAPG;
    
    if (totalMediaStats > beforeStats)
    {
        ovrPlayer += random.Next(0, 5);
    } else 
    {
        ovrPlayer -= random.Next(0, 2);
    }
    
    }

    public statis bool MVP (int ovrPlayer, int totalMediaStats)
    {
        Random random = new Random();
        bool mvpWin = false;
        
        if (ovrPlayer > 88 && totalMediaStats > 39)
        {
            mvpWin = random.Next(2) == 0;
        }

        return mvpWin; 
    } 

    public static void PlayoffsSim(int seasonCondition, string[] easternNbaTeams, string[] westernNbaTeams, string teamConference, string nbaTeamSelected, ref int pTotalP, ref int pTotalR, ref int pTotalA, ref int nbaChamp, ref int nbaFVMP)
    {
        Random random = new Random();
        string playInTeam = " ",
                firstRoundTeam = " ",
                secondRoundTeam = " ",
                cfTeam = " ",
                finalTeam = " ";

        int wins = 0,
            loses = 0;

        bool FVMPWin = false;

        if (teamConference == "Leste")
        {
            if (seasonCondition == 1) // Playoffs direto
            {
                do
                {
                    firstRoundTeam = easternNbaTeams[random.Next(0, 15)];
                } while (firstRoundTeam == nbaTeamSelected);

                wins = random.Next(1, 5);

                if (wins == 4)
                {
                    loses = random.Next(0, 4);
                    Console.WriteLine($"O {nbaTeamSelected} enfrentou o {firstRoundTeam} no primeiro round e ganhou por {wins} - {loses}!");
                    Console.WriteLine(" ");
                    Console.WriteLine("==============================================================================");
                    Console.WriteLine(" ");

                    do
                    {
                        secondRoundTeam = easternNbaTeams[random.Next(0, 15)];
                    } while (secondRoundTeam == firstRoundTeam || secondRoundTeam == nbaTeamSelected);

                    wins = random.Next(1, 5);

                    if (wins == 4)
                    {
                        loses = random.Next(0, 4);
                        Console.WriteLine($"O {nbaTeamSelected} enfrentou o {secondRoundTeam} no segundo round e ganhou por {wins} - {loses}!");
                        Console.WriteLine(" ");
                        Console.WriteLine("==============================================================================");
                        Console.WriteLine(" ");

                        do
                        {
                            cfTeam = easternNbaTeams[random.Next(0, 15)];
                        } while (cfTeam == firstRoundTeam || cfTeam == secondRoundTeam || cfTeam == nbaTeamSelected);

                        wins = random.Next(1, 5);

                        if (wins == 4)
                        {
                            loses = random.Next(0, 4);
                            Console.WriteLine($"O {nbaTeamSelected} enfrentou o {cfTeam} nas finais de conferência e ganhou por {wins} - {loses}!");
                            Console.WriteLine(" ");
                            Console.WriteLine("==============================================================================");
                            Console.WriteLine(" ");

                            finalTeam = westernNbaTeams[random.Next(0, 16)];

                            wins = random.Next(1, 5);

                            if (wins == 4)
                            {
                                loses = random.Next(0, 4);
                                Console.WriteLine($"O {nbaTeamSelected} enfrentou o {finalTeam} nas finais da NBA e ganhou por {wins} - {loses}!");
                                Console.WriteLine(" ");
                                Console.WriteLine("==============================================================================");
                                Console.WriteLine(" ");
                                nbaChamp++;
                                FVMPWin = random.Next(0, 2) == 0;
                            }
                            else
                            {
                                loses = 4;
                                Console.WriteLine($"O {nbaTeamSelected} enfrentou o {finalTeam} na final da NBA e perdeu por {loses} - {wins}.");
                            }
                        }
                        else
                        {
                            loses = 4;
                            Console.WriteLine($"O {nbaTeamSelected} enfrentou o {cfTeam} nas finais de conferência e perdeu por {loses} - {wins}.");
                        }
                    }
                    else
                    {
                        loses = 4;
                        Console.WriteLine($"O {nbaTeamSelected} enfrentou o {secondRoundTeam} no segundo round e perdeu por {loses} - {wins}.");
                    }
                }
                else
                {
                    loses = 4;
                    Console.WriteLine($"O {nbaTeamSelected} enfrentou o {firstRoundTeam} no primeiro round e perdeu por {loses} - {wins}.");
                }
            }
            else if (seasonCondition == 2) // Play - In
            {
                do
                {
                    playInTeam = easternNbaTeams[random.Next(0, 15)];
                } while (playInTeam == nbaTeamSelected);

                wins = random.Next(1, 5);

                if (wins == 4)
                {
                    loses = random.Next(0, 4);
                    Console.WriteLine($"O {nbaTeamSelected} enfrentou o {playInTeam} no play-in e ganhou por {wins} - {loses}!");
                    Console.WriteLine(" ");
                    Console.WriteLine("==============================================================================");
                    Console.WriteLine(" ");

                    do
                    {
                        firstRoundTeam = easternNbaTeams[random.Next(0, 15)];
                    } while (firstRoundTeam == nbaTeamSelected || firstRoundTeam == playInTeam);

                    wins = random.Next(1, 5);

                    if (wins == 4)
                    {
                        loses = random.Next(0, 4);
                        Console.WriteLine($"O {nbaTeamSelected} enfrentou o {firstRoundTeam} no primeiro round e ganhou por {wins} - {loses}!");
                        Console.WriteLine(" ");
                        Console.WriteLine("==============================================================================");
                        Console.WriteLine(" ");

                        do
                        {
                            secondRoundTeam = easternNbaTeams[random.Next(0, 15)];
                        } while (secondRoundTeam == firstRoundTeam || secondRoundTeam == nbaTeamSelected || secondRoundTeam == playInTeam);

                        wins = random.Next(1, 5);

                        if (wins == 4)
                        {
                            loses = random.Next(0, 4);
                            Console.WriteLine($"O {nbaTeamSelected} enfrentou o {secondRoundTeam} no segundo round e ganhou por {wins} - {loses}!");
                            Console.WriteLine(" ");
                            Console.WriteLine("==============================================================================");
                            Console.WriteLine(" ");

                            do
                            {
                                cfTeam = easternNbaTeams[random.Next(0, 15)];
                            } while (cfTeam == firstRoundTeam || cfTeam == secondRoundTeam || cfTeam == nbaTeamSelected || cfTeam == playInTeam);

                            wins = random.Next(1, 5);

                            if (wins == 4)
                            {
                                loses = random.Next(0, 4);
                                Console.WriteLine($"O {nbaTeamSelected} enfrentou o {cfTeam} nas finais de conferência e ganhou por {wins} - {loses}!");
                                Console.WriteLine(" ");
                                Console.WriteLine("==============================================================================");
                                Console.WriteLine(" ");

                                finalTeam = westernNbaTeams[random.Next(0, 16)];

                                wins = random.Next(1, 5);

                                if (wins == 4)
                                {
                                    loses = random.Next(0, 4);
                                    Console.WriteLine($"O {nbaTeamSelected} enfrentou o {finalTeam} nas finais da NBA e ganhou por {wins} - {loses}!");
                                    Console.WriteLine(" ");
                                    Console.WriteLine("==============================================================================");
                                    Console.WriteLine(" ");
                                    nbaChamp++;
                                    FVMPWin = random.Next(0, 2) == 0;
                                }
                                else
                                {
                                    loses = 4;
                                    Console.WriteLine($"O {nbaTeamSelected} enfrentou o {finalTeam} na final da NBA e perdeu por {loses} - {wins}.");
                                }
                            }
                            else
                            {
                                loses = 4;
                                Console.WriteLine($"O {nbaTeamSelected} enfrentou o {cfTeam} nas finais de conferência e perdeu por {loses} - {wins}.");
                            }
                        }
                        else
                        {
                            loses = 4;
                            Console.WriteLine($"O {nbaTeamSelected} enfrentou o {secondRoundTeam} no segundo round e perdeu por {loses} - {wins}.");
                        }
                    }
                    else
                    {
                        loses = 4;
                        Console.WriteLine($"O {nbaTeamSelected} enfrentou o {firstRoundTeam} no primeiro round e perdeu por {loses} - {wins}.");
                    }
                }
                else
                {
                    loses = 4;
                    Console.WriteLine($"O {nbaTeamSelected} enfrentou o {playInTeam} no play-in e perdeu por {loses} - {wins}.");
                }
            }

        }
        if (teamConference == "Oeste")
        {
            if (seasonCondition == 1) // Playoffs direto
            {
                do
                {
                    firstRoundTeam = westernNbaTeams[random.Next(0, 15)];
                } while (firstRoundTeam == nbaTeamSelected);

                wins = random.Next(1, 5);

                if (wins == 4)
                {
                    loses = random.Next(0, 4);
                    Console.WriteLine($"O {nbaTeamSelected} enfrentou o {firstRoundTeam} no primeiro round e ganhou por {wins} - {loses}!");
                    Console.WriteLine(" ");
                    Console.WriteLine("==============================================================================");
                    Console.WriteLine(" ");

                    do
                    {
                        secondRoundTeam = westernNbaTeams[random.Next(0, 15)];
                    } while (secondRoundTeam == firstRoundTeam || secondRoundTeam == nbaTeamSelected);

                    wins = random.Next(1, 5);

                    if (wins == 4)
                    {
                        loses = random.Next(0, 4);
                        Console.WriteLine($"O {nbaTeamSelected} enfrentou o {secondRoundTeam} no segundo round e ganhou por {wins} - {loses}!");
                        Console.WriteLine(" ");
                        Console.WriteLine("==============================================================================");
                        Console.WriteLine(" ");

                        do
                        {
                            cfTeam = westernNbaTeams[random.Next(0, 15)];
                        } while (cfTeam == firstRoundTeam || cfTeam == secondRoundTeam || cfTeam == nbaTeamSelected);

                        wins = random.Next(1, 5);

                        if (wins == 4)
                        {
                            loses = random.Next(0, 4);
                            Console.WriteLine($"O {nbaTeamSelected} enfrentou o {cfTeam} nas finais de conferência e ganhou por {wins} - {loses}!");
                            Console.WriteLine(" ");
                            Console.WriteLine("==============================================================================");
                            Console.WriteLine(" ");

                            finalTeam = easternNbaTeams[random.Next(0, 15)];

                            wins = random.Next(1, 5);

                            if (wins == 4)
                            {
                                loses = random.Next(0, 4);
                                Console.WriteLine($"O {nbaTeamSelected} enfrentou o {finalTeam} nas finais da NBA e ganhou por {wins} - {loses}!");
                                Console.WriteLine(" ");
                                Console.WriteLine("==============================================================================");
                                Console.WriteLine(" ");
                                nbaChamp++;
                                FVMPWin = random.Next(0, 2) == 0;
                            }
                            else
                            {
                                loses = 4;
                                Console.WriteLine($"O {nbaTeamSelected} enfrentou o {finalTeam} na final da NBA e perdeu por {loses} - {wins}.");
                            }
                        }
                        else
                        {
                            loses = 4;
                            Console.WriteLine($"O {nbaTeamSelected} enfrentou o {cfTeam} nas finais de conferência e perdeu por {loses} - {wins}.");
                        }
                    }
                    else
                    {
                        loses = 4;
                        Console.WriteLine($"O {nbaTeamSelected} enfrentou o {secondRoundTeam} no segundo round e perdeu por {loses} - {wins}.");
                    }
                }
                else
                {
                    loses = 4;
                    Console.WriteLine($"O {nbaTeamSelected} enfrentou o {firstRoundTeam} no primeiro round e perdeu por {loses} - {wins}.");
                }
            }
            else if (seasonCondition == 2) // Play - In
            {
                do
                {
                    playInTeam = westernNbaTeams[random.Next(0, 15)];
                } while (playInTeam == nbaTeamSelected);

                wins = random.Next(1, 5);

                if (wins == 4)
                {
                    loses = random.Next(0, 4);
                    Console.WriteLine($"O {nbaTeamSelected} enfrentou o {playInTeam} no play-in e ganhou por {wins} - {loses}!");
                    Console.WriteLine(" ");
                    Console.WriteLine("==============================================================================");
                    Console.WriteLine(" ");

                    do
                    {
                        firstRoundTeam = westernNbaTeams[random.Next(0, 15)];
                    } while (firstRoundTeam == nbaTeamSelected || firstRoundTeam == playInTeam);

                    wins = random.Next(1, 5);

                    if (wins == 4)
                    {
                        loses = random.Next(0, 4);
                        Console.WriteLine($"O {nbaTeamSelected} enfrentou o {firstRoundTeam} no primeiro round e ganhou por {wins} - {loses}!");
                        Console.WriteLine(" ");
                        Console.WriteLine("==============================================================================");
                        Console.WriteLine(" ");

                        do
                        {
                            secondRoundTeam = westernNbaTeams[random.Next(0, 15)];
                        } while (secondRoundTeam == firstRoundTeam || secondRoundTeam == nbaTeamSelected || secondRoundTeam == playInTeam);

                        wins = random.Next(1, 5);

                        if (wins == 4)
                        {
                            loses = random.Next(0, 4);
                            Console.WriteLine($"O {nbaTeamSelected} enfrentou o {secondRoundTeam} no segundo round e ganhou por {wins} - {loses}!");
                            Console.WriteLine(" ");
                            Console.WriteLine("==============================================================================");
                            Console.WriteLine(" ");

                            do
                            {
                                cfTeam = westernNbaTeams[random.Next(0, 15)];
                            } while (cfTeam == firstRoundTeam || cfTeam == secondRoundTeam || cfTeam == nbaTeamSelected || cfTeam == playInTeam);

                            wins = random.Next(1, 5);

                            if (wins == 4)
                            {
                                loses = random.Next(0, 4);
                                Console.WriteLine($"O {nbaTeamSelected} enfrentou o {cfTeam} nas finais de conferência e ganhou por {wins} - {loses}!");
                                Console.WriteLine(" ");
                                Console.WriteLine("==============================================================================");
                                Console.WriteLine(" ");

                                finalTeam = easternNbaTeams[random.Next(0, 15)];

                                wins = random.Next(1, 5);

                                if (wins == 4)
                                {
                                    loses = random.Next(0, 4);
                                    Console.WriteLine($"O {nbaTeamSelected} enfrentou o {finalTeam} nas finais da NBA e ganhou por {wins} - {loses}!");
                                    Console.WriteLine(" ");
                                    Console.WriteLine("==============================================================================");
                                    Console.WriteLine(" ");
                                    nbaChamp++;
                                    FVMPWin = random.Next(0, 2) == 0;
                                }
                                else
                                {
                                    loses = 4;
                                    Console.WriteLine($"O {nbaTeamSelected} enfrentou o {finalTeam} na final da NBA e perdeu por {loses} - {wins}.");
                                }
                            }
                            else
                            {
                                loses = 4;
                                Console.WriteLine($"O {nbaTeamSelected} enfrentou o {cfTeam} nas finais de conferência e perdeu por {loses} - {wins}.");
                            }
                        }
                        else
                        {
                            loses = 4;
                            Console.WriteLine($"O {nbaTeamSelected} enfrentou o {secondRoundTeam} no segundo round e perdeu por {loses} - {wins}.");
                        }
                    }
                    else
                    {
                        loses = 4;
                        Console.WriteLine($"O {nbaTeamSelected} enfrentou o {firstRoundTeam} no primeiro round e perdeu por {loses} - {wins}.");
                    }
                }
                else
                {
                    loses = 4;
                    Console.WriteLine($"O {nbaTeamSelected} enfrentou o {playInTeam} no play-in e perdeu por {loses} - {wins}.");
                }
            }
        }

        if (FVMPWin == true)
        {
            nbaFVMP++;
        }

    }

    public static void PlayoffsPerfomance(ref int offsP, ref int offsR, ref int offsA, ref int ovrPlayer, ref string condOffs, string playerName, int seasonCondition)
    {
        Random random = new Random();

        if (seasonCondition < 3)
        {
            if (ovrPlayer > 95)
            {
                offsP = random.Next(23, 39);
                offsR = random.Next(5, 13);
                offsA = random.Next(5, 13);
            }
            else if (ovrPlayer > 90)
            {
                offsP = random.Next(21, 33);
                offsR = random.Next(5, 9);
                offsA = random.Next(5, 9);
            }
            else if (ovrPlayer > 86)
            {
                offsP = random.Next(18, 28);
                offsR = random.Next(4, 8);
                offsA = random.Next(4, 9);
            }
            else if (ovrPlayer > 82)
            {
                offsP = random.Next(17, 25);
                offsR = random.Next(3, 8);
                offsA = random.Next(4, 9);
            }
            else if (ovrPlayer > 79)
            {
                offsP = random.Next(14, 19);
                offsR = random.Next(2, 7);
                offsA = random.Next(3, 8);
            }
            else if (ovrPlayer > 74)
            {
                offsP = random.Next(11, 17);
                offsR = random.Next(2, 5);
                offsA = random.Next(3, 6);
            }
            else
            {
                offsP = random.Next(9, 15);
                offsR = random.Next(2, 5);
                offsA = random.Next(3, 5);
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


}
