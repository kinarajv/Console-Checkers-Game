using CheckersGameLib;

class Program
{
    static void Main()
    {
        // 1. Add Players
        Player player1 = new();
        Player player2 = new();
        GameRunner gr = new();
        bool addPlayer = gr.AddPlayer(player1);
        bool addPlayer2 = gr.AddPlayer(player2);
        Console.WriteLine(addPlayer);
        Console.WriteLine(addPlayer2);
        System.Console.WriteLine($"Player 1 Name: {player1.GetName()}, ID = {player1.GetID()}");
        System.Console.WriteLine($"Player 2 Name: {player2.GetName()}, ID = {player2.GetID()}");

        //2. Initialize Board
        Board checkers = new Board();
        System.Console.WriteLine(checkers.SetSize(8));
        gr = new GameRunner(checkers);


    }
}