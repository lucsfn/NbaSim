using System;

class NbaSim
{
    public static void Main(string[] args)
    {
        // Variáveis que serão utilizadas
        string playerName = PlayerName();
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
        do {
            name = Console.ReadLine()!;
        } while(name == string.Empty);

        return name;     
    }
}
