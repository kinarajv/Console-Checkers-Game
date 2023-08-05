using CheckersGameLib;

partial class Program
{
    static void Main()
    {
        // 1. Add Players
        Board checkersBoard = new Board();
        checkersBoard.SetSize(8);
        GameRunner checkers = new GameRunner(checkersBoard);

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
        // foreach (var piece in player1Pieces)
        // {
        //     Console.WriteLine(piece.GetPieceColor());
        //     Console.WriteLine(piece.GetPosition().GetRow() + ", " + piece.GetPosition().GetColumn());
        // }
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

        //5. Make move of selected piece
        int baris;
        int kolom;
        string[] post;
        Position origin;

        int newRow;
        int newCol;
        string[] pos;
        Position destination;

        // Player 1 turn 1
        do
        {
            // Get Possible Move
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
            Piece player1Piece = checkers.GetPlayerPiece(player1, piecePos);

            //4. Get Available Move of a player's piece
            List<Position> piece1AvailMove = checkers.GetPossibleMove(player1Piece);
            foreach (var position in piece1AvailMove)
            {
                Console.WriteLine(position.GetRow() + "," + position.GetColumn());
            }

            // Select piece that want to move
            do
            {
                Console.Write("Input your piece's position(row,column): ");
                post = Console.ReadLine().Split(",");
                baris = int.Parse(post[0]);
                kolom = int.Parse(post[1]);
                origin = new Position();
                origin.SetRow(baris);
                origin.SetColumn(kolom);
            } while (checkers.CheckPiece(baris, kolom) == null);

            Console.Write("Input your desired position(row,column): ");
            pos = Console.ReadLine().Split(",");
            newRow = int.Parse(pos[0]);
            newCol = int.Parse(pos[1]);
            destination = new Position();
            destination.SetRow(newRow);
            destination.SetColumn(newCol);
        } while (!checkers.MakeMove(origin, destination));

        Console.Clear();
        DrawBoard(checkers);
        if (checkers.GetGameStatus().Equals(GameStatus.BlackWin))
        {
            System.Console.WriteLine("Player 1 Win");
        }
        else if (checkers.GetGameStatus().Equals(GameStatus.RedWin))
        {
            System.Console.WriteLine("Player 2 Win");
        }
        else
        {
            System.Console.WriteLine("Game is still ongoing");
        }

        checkers.SwitchTurn();

        // Player 2 turn 1
        do
        {
            // Get Possible Move
            do
            {
                Console.Write("Input your piece (row,column): ");
                string[] piecePost = Console.ReadLine().Split(",");
                row = int.Parse(piecePost[0]);
                column = int.Parse(piecePost[1]);
                foreach (var playerPiece in player2Pieces)
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
            Piece player2Piece = checkers.GetPlayerPiece(player2, piecePos);

            // 4. Get Available Move of a player's piece
            List<Position> piece2AvailMove = checkers.GetPossibleMove(player2Piece);
            foreach (var position in piece2AvailMove)
            {
                Console.WriteLine(position.GetRow() + "," + position.GetColumn());
            }

            // Select piece that want to move
            do
            {
                Console.Write("Input your piece's position(row,column): ");
                post = Console.ReadLine().Split(",");
                baris = int.Parse(post[0]);
                kolom = int.Parse(post[1]);
                origin = new Position();
                origin.SetRow(baris);
                origin.SetColumn(kolom);
            } while (checkers.CheckPiece(baris, kolom) == null);

            Console.Write("Input your desired position(row,column): ");
            pos = Console.ReadLine().Split(",");
            newRow = int.Parse(pos[0]);
            newCol = int.Parse(pos[1]);
            destination = new Position();
            destination.SetRow(newRow);
            destination.SetColumn(newCol);
        } while (!checkers.MakeMove(origin, destination));

        Console.Clear();
        DrawBoard(checkers);
        if (checkers.GetGameStatus().Equals(GameStatus.BlackWin))
        {
            System.Console.WriteLine("Player 1 Win");
        }
        else if (checkers.GetGameStatus().Equals(GameStatus.RedWin))
        {
            System.Console.WriteLine("Player 2 Win");
        }
        else
        {
            System.Console.WriteLine("Game is still ongoing");
        }

        checkers.SwitchTurn();

        // Player 1 turn 2
        do
        {
            // Get Possible Move
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
            Piece player1Piece = checkers.GetPlayerPiece(player1, piecePos);

            //4. Get Available Move of a player's piece
            List<Position> piece1AvailMove = checkers.GetPossibleMove(player1Piece);
            foreach (var position in piece1AvailMove)
            {
                Console.WriteLine(position.GetRow() + "," + position.GetColumn());
            }

            // Select piece that want to move
            do
            {
                Console.Write("Input your piece's position(row,column): ");
                post = Console.ReadLine().Split(",");
                baris = int.Parse(post[0]);
                kolom = int.Parse(post[1]);
                origin = new Position();
                origin.SetRow(baris);
                origin.SetColumn(kolom);
            } while (checkers.CheckPiece(baris, kolom) == null);

            Console.Write("Input your desired position(row,column): ");
            pos = Console.ReadLine().Split(",");
            newRow = int.Parse(pos[0]);
            newCol = int.Parse(pos[1]);
            destination = new Position();
            destination.SetRow(newRow);
            destination.SetColumn(newCol);
        } while (!checkers.MakeMove(origin, destination));

        Console.Clear();
        DrawBoard(checkers);
        if (checkers.GetGameStatus().Equals(GameStatus.BlackWin))
        {
            System.Console.WriteLine("Player 1 Win");
        }
        else if (checkers.GetGameStatus().Equals(GameStatus.RedWin))
        {
            System.Console.WriteLine("Player 2 Win");
        }
        else
        {
            System.Console.WriteLine("Game is still ongoing");
        }
    }
}