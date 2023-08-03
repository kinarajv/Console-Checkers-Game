using CheckersGameLib;

class Program
{
    static void Main()
    {
        // 1. Add Players
        Board checkersBoard = new Board();
        checkersBoard.SetSize(8);
        GameRunnerTest checkers = new GameRunnerTest(checkersBoard);

        Player player1 = new();
        Player player2 = new();
        string name;
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
        bool addPlayer = checkers.AddPlayer(player1);
        bool addPlayer2 = checkers.AddPlayer(player2);
        Console.WriteLine(addPlayer);
        Console.WriteLine($"Player 1 Name: {player1.GetName()}, ID = {player1.GetID()}");
        Console.WriteLine(addPlayer2);
        Console.WriteLine($"Player 2 Name: {player2.GetName()}, ID = {player2.GetID()}");

        //2. Get a player's pieces
        List<Piece> player1Pieces = checkers.GetPlayerPieces(player1);
        List<Piece> player2Pieces = checkers.GetPlayerPieces(player2);
        foreach (var piece in player1Pieces)
        {
            Console.WriteLine(piece.GetPieceColor());
            Console.WriteLine(piece.GetPosition().GetRow() + ", " + piece.GetPosition().GetColumn());
        }
        // System.Console.WriteLine("============================================================");
        // foreach (var piece in player2Pieces)
        // {
        //     Console.WriteLine(piece.GetPieceColor());
        //     Console.WriteLine(piece.GetPosition().GetRow() + ", " + piece.GetPosition().GetColumn());
        // }

        // List of Pieces from all player
        // List<Piece> allPiece = player1Pieces.Concat(player2Pieces).ToList();

        //3. Initialize Board %% players init pieces placed
        DrawBoard(checkers);

        //4. Get a piece of a player
        int row;
        int column;
        bool isOwned = false;
        do
        {
            Console.Write("Input your piece (row,column): ");
            string[] piecePost = Console.ReadLine().Split(",");
            row = int.Parse(piecePost[0]);
            column = int.Parse(piecePost[1]);
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
        } while (!isOwned);


        Position piecePos = new Position(row, column);
        Position piecePos1 = new Position(row + 1, column + 1);
        Piece player1Piece = checkers.GetPlayerPiece(player1, piecePos);
        Piece player1Piece1 = checkers.GetPlayerPiece(player1, piecePos1);
        player1Piece1.SetPieceColor(PieceColor.Red);

        //4. Get Available Move of a player's piece
        List<Position> piece1AvailMove = checkers.GetPossibleMove(player1Piece);
        foreach (var position in piece1AvailMove)
        {
            Console.WriteLine(position.GetRow() + "," + position.GetColumn());
        }

        //5. Make move of selected piece
        int baris;
        int kolom;
        string[] post;
        Position origin;
        do
        {
            Console.Write("Input your piece's position(row,column): ");
            post = Console.ReadLine().Split(",");
            baris = int.Parse(post[0]);
            kolom = int.Parse(post[1]);
            origin = new Position(baris, kolom);
        } while (checkers.CheckPiece(baris, kolom) == null);

        int newRow;
        int newCol;
        Position destination = new Position();
        string[] pos;
        do
        {
            Console.Write("Input your desired position(row,column): ");
            pos = Console.ReadLine().Split(",");
            newRow = int.Parse(pos[0]);
            newCol = int.Parse(pos[1]);
            foreach (var position in piece1AvailMove)
            {
                if (position.GetRow() == newRow && position.GetColumn() == newCol)
                {
                    destination.SetRow(newRow);
                    destination.SetColumn(newCol);
                }
            }
        } while (destination.GetRow() == 0 && destination.GetColumn() == 0);

        checkers.MakeMove(origin, destination);
        DrawBoard(checkers);

        // Console.ReadLine();
    }

    static void DrawBoard(GameRunnerTest gr)
    {
        Console.WriteLine("+---+---+---+---+---+---+---+---+");
        for (int i = 0; i < gr.GetBoardBoundary(); i++)
        {
            for (int j = 0; j < gr.GetBoardBoundary(); j++)
            {
                char aPiece;
                Rank basic = Rank.Basic;
                PieceColor black = PieceColor.Black;
                Piece piece = gr.CheckPiece(i, j);
                if (piece != null)
                {
                    Rank pieceRank = piece.GetRank();
                    PieceColor pieceColor = piece.GetPieceColor();
                    if (pieceRank.Equals(basic))
                    {
                        if (pieceColor.Equals(black))
                        {
                            aPiece = 'b';
                        }
                        else
                        {
                            aPiece = 'r';
                        }
                    }
                    else
                    {
                        if (pieceColor.Equals(black))
                        {
                            aPiece = 'B';
                        }
                        else
                        {
                            aPiece = 'R';
                        }
                    }
                    Console.Write($"| {aPiece} ");
                }
                else
                {
                    Console.Write("|   ");
                }
            }
            Console.WriteLine("|");
            Console.WriteLine("+---+---+---+---+---+---+---+---+");
        }
    }
}