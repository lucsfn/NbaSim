using System;

class NbaSim
{
    public static void Main(string[] args)
    {
        // Variáveis do Player
        string playerName = PlayerName();
        string playerPosition = PlayerPosition();
        int playerPick = PlayerPick();
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
