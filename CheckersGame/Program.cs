using CheckersGameLib;

class Program
{
    static void Main()
    {
        // 1. Add Players
        Board checkers = new Board();
        bool checkerSize = checkers.SetSize(8);
        // System.Console.WriteLine(checkerSize);
        // System.Console.WriteLine();
        GameRunner gr = new GameRunner(checkers);

        Player player1 = new();
        Player player2 = new();
        string name = "";
        for (int i = 0; i < 2; i++)
        {
            if (i == 0)
            {
                do
                {
                    Console.WriteLine($"Enter Player {i + 1} Name: ");
                    name = Console.ReadLine();
                    player1.SetName(name);
                } while (name == "");
            }
            else
            {
                do
                {
                    Console.WriteLine($"Enter Player {i + 1} Name: ");
                    name = Console.ReadLine();
                    player2.SetName(name);
                } while (name == "" || name.Equals(player1.GetName()));
            }
        }
        bool addPlayer = gr.AddPlayer(player1);
        bool addPlayer2 = gr.AddPlayer(player2);
        Console.WriteLine(addPlayer);
        Console.WriteLine($"Player 1 Name: {player1.GetName()}, ID = {player1.GetID()}");
        Console.WriteLine(addPlayer2);
        Console.WriteLine($"Player 2 Name: {player2.GetName()}, ID = {player2.GetID()}");

        //2. Initialize Board %% players init pieces placed
        Console.WriteLine((gr.InitBoard()));

        //3. Get a player's pieces
        List<Piece> player1Pieces = gr.GetPlayerPieces(player1);
        List<Piece> player2Pieces = gr.GetPlayerPieces(player2);
        // Console.WriteLine(player1Pieces.Count);
        // Console.WriteLine(player2Pieces.Count);
        foreach (var piece in player1Pieces)
        {
            Console.WriteLine(piece.GetPosition().GetRow() + "" + piece.GetPosition().GetColumn());
        }
        // foreach (var piece in player2Pieces)
        // {
        //     Console.WriteLine(piece.GetPosition().GetRow() + "" + piece.GetPosition().GetColumn());
        // }

        //4. Get a piece of a player
        int row = 0;
        int column = 0;
        bool isOwned = false;
        do
        {
            Console.Write("Input your piece (rowcolumn): ");
            string piecePost = Console.ReadLine();
            row = int.Parse(piecePost.Substring(0, 1));
            column = int.Parse(piecePost.Substring(1, 1)); ;
            foreach (var playerPiece in player1Pieces)
            {
                int pieceRow = playerPiece.GetPosition().GetRow();
                int pieceColumn = playerPiece.GetPosition().GetColumn();
                if (row == pieceRow && column == pieceColumn)
                {
                    isOwned = true;
                    break;
                }
                else
                {
                    isOwned = false;
                }
            }
            // Console.WriteLine(row + "" + column);
        } while (!isOwned);


        Position piecePos = new Position(row, column);
        Piece player1Piece = gr.GetPlayerPiece(player1, piecePos);

        //4. Get Available Move of a player's piece
        List<Position> pieceAvailMove = gr.GetPossibleMove(player1Piece);
        foreach (var position in pieceAvailMove)
        {
            Console.WriteLine(position.GetRow() + "" + position.GetColumn());
        }

        Console.ReadLine();
    }
}