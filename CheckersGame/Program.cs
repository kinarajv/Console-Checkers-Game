using CheckersGameLib;

class Program
{
    static void Main()
    {
        // 1. Add Players
        Board checkers = new Board();
        bool checkerSize = checkers.SetSize(8);
        System.Console.WriteLine(checkerSize);
        GameRunner gr = new GameRunner(checkers);
        Player player1 = new();
        Player player2 = new();
        bool addPlayer = gr.AddPlayer(player1);
        bool addPlayer2 = gr.AddPlayer(player2);
        Console.WriteLine(addPlayer);
        Console.WriteLine(addPlayer2);
        System.Console.WriteLine($"Player 1 Name: {player1.GetName()}, ID = {player1.GetID()}");
        System.Console.WriteLine($"Player 2 Name: {player2.GetName()}, ID = {player2.GetID()}");

        //2. Initialize Board %% players init pieces placed
        gr.InitBoard();

        //3. Get a player's pieces
        var player1Pieces = gr.GetPlayerPieces(player1);
        var player2Pieces = gr.GetPlayerPieces(player2);
        // System.Console.WriteLine(player1Pieces.Count);
        // System.Console.WriteLine(player2Pieces.Count);
        foreach (var piece in player1Pieces)
        {
            Console.WriteLine(piece.GetPosition().GetRow() + ", " + piece.GetPosition().GetColumn());
        }
        foreach (var piece in player2Pieces)
        {
            Console.WriteLine(piece.GetPosition().GetRow() + ", " + piece.GetPosition().GetColumn());
        }

        //4. Get Available Move of a player's piece
        // var pieceAvailMove = gr.GetAvailableMove();
    }
}