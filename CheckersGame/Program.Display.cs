using CheckersGameLib;

public delegate void Print(string x);
// public delegate void PrintLine(string x);
public partial class Program
{

    public static void Display(string message)
    {
        Console.Write(message);
    }

    public static void DisplayLine(string message)
    {
        Console.WriteLine(message);
    }

    public static void DisplayPlayer(GameRunner gr, Player player1, Player player2)
    {
        Console.WriteLine($"Player 1 Name = {player1.GetName()}, ID = {player1.GetID()}, Piece left = {gr.GetPlayerPieces(player1).Count}");
        Console.WriteLine($"Player 2 Name = {player2.GetName()}, ID = {player2.GetID()}, Piece left = {gr.GetPlayerPieces(player2).Count}");

        logger.Info($"Player 1 Name = {player1.GetName()}, ID = {player1.GetID()}, Piece left = {gr.GetPlayerPieces(player1).Count}");
        logger.Info($"Player 2 Name = {player2.GetName()}, ID = {player2.GetID()}, Piece left = {gr.GetPlayerPieces(player2).Count}");
    }

    public static void DisplayTurn(GameRunner gr, Player player1, Player player2)
    {
        Console.WriteLine("=========================================");
        if (gr.SwitchTurn())
        {
            Console.WriteLine($"               {player1.GetName()} Turn               ");
            logger.Info($"{player1.GetName()} Turn");
        }
        else
        {
            Console.WriteLine($"               {player2.GetName()} Turn               ");
            logger.Info($"{player2.GetName()} Turn");
        }
        Console.WriteLine("=========================================");
    }


    public static void OnWinnerDecided(object sender, WinnerEventArgs e)
    {
        Console.WriteLine("=========================================");
        Console.WriteLine($"               {e.Player.GetName()} Win               ");
        logger.Info($"{e.Player.GetName()} Win ");
        Console.WriteLine("=========================================");
    }

    public static void RegisterCheckersWinner(GameRunner gr)
    {
        gr.WinnerDecided += OnWinnerDecided;
    }

    public static void UnregisterCheckersWinner(GameRunner gr)
    {
        gr.WinnerDecided -= OnWinnerDecided;
    }
}
