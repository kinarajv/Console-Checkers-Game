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
        checkers.AddPlayer(player1);
        checkers.AddPlayer(player2);

        //3. Initialize Board %% players init pieces placed
        Console.Clear();
        Console.WriteLine($"Player 1 Name = {player1.GetName()}, ID = {player1.GetID()}, Piece left = {checkers.GetPlayerPieces(player1).Count}");
        Console.WriteLine($"Player 2 Name: {player2.GetName()}, ID = {player2.GetID()}, Piece left = {checkers.GetPlayerPieces(player2).Count}");
        DrawBoard(checkers);
        System.Console.WriteLine("=========================================");
        if (checkers.SwitchTurn())
        {
            Console.WriteLine($"               {player1.GetName()} Turn               ");
        }
        else
        {
            Console.WriteLine($"               {player2.GetName()} Turn               ");
        }
        System.Console.WriteLine("=========================================");

        //4. Get a piece of a player
        int row;
        int column;

        //5. Make move of selected piece
        int currRow;
        int currCol;
        string[] currPos;
        Position origin;

        int newRow;
        int newCol;
        string[] newPos;
        Position destination;

        while (checkers.GetGameStatus() == GameStatus.Ongoing)
        {
            // Player 1
            do
            {
                // Select piece that want to move
                do
                {
                    Console.Write("Input your piece's position(row,column): ");
                    currPos = Console.ReadLine().Split(",");
                    currRow = int.Parse(currPos[0]);
                    currCol = int.Parse(currPos[1]);
                    origin = new Position();
                    origin.SetRow(currRow);
                    origin.SetColumn(currCol);
                    if (checkers.CheckPiece(currRow, currCol) == null)
                    {
                        System.Console.WriteLine("Position invalid! There's no piece there");
                        System.Console.WriteLine();
                    }
                } while (checkers.CheckPiece(currRow, currCol) == null);
                Piece p = checkers.CheckPiece(currRow, currCol);
                var possibleMove = checkers.GetPossibleMove(p);
                System.Console.WriteLine("Possible move: ");
                foreach (var pos in possibleMove)
                {
                    System.Console.WriteLine("- " + pos.GetRow() + "," + pos.GetColumn());
                }

                Console.Write("Input your desired position(row,column): ");
                newPos = Console.ReadLine().Split(",");
                newRow = int.Parse(newPos[0]);
                newCol = int.Parse(newPos[1]);
                destination = new Position();
                destination.SetRow(newRow);
                destination.SetColumn(newCol);
                if (!checkers.MakeMove(origin, destination))
                {
                    System.Console.WriteLine("Move invalid! It's not possible to move there");
                    System.Console.WriteLine();
                }
            } while (!checkers.MakeMove(origin, destination));

            Console.Clear();
            Console.WriteLine($"Player 1 Name = {player1.GetName()}, ID = {player1.GetID()}, Piece left = {checkers.GetPlayerPieces(player1).Count}");
            Console.WriteLine($"Player 2 Name: {player2.GetName()}, ID = {player2.GetID()}, Piece left = {checkers.GetPlayerPieces(player2).Count}");
            DrawBoard(checkers);
            System.Console.WriteLine("=========================================");
            if (checkers.SwitchTurn())
            {
                Console.WriteLine($"               {player1.GetName()} Turn               ");
            }
            else
            {
                Console.WriteLine($"               {player2.GetName()} Turn               ");
            }
            System.Console.WriteLine("=========================================");

            // Player 2
            do
            {
                // Select piece that want to move
                do
                {
                    Console.Write("Input your piece's position(row,column): ");
                    currPos = Console.ReadLine().Split(",");
                    currRow = int.Parse(currPos[0]);
                    currCol = int.Parse(currPos[1]);
                    origin = new Position();
                    origin.SetRow(currRow);
                    origin.SetColumn(currCol);
                    if (checkers.CheckPiece(currRow, currCol) == null)
                    {
                        System.Console.WriteLine("Position invalid! There's no piece there");
                        System.Console.WriteLine();
                    }
                } while (checkers.CheckPiece(currRow, currCol) == null);
                Piece p = checkers.CheckPiece(currRow, currCol);
                var possibleMove = checkers.GetPossibleMove(p);
                System.Console.WriteLine("Possible move: ");
                foreach (var pos in possibleMove)
                {
                    System.Console.WriteLine("- " + pos.GetRow() + "," + pos.GetColumn());
                }

                Console.Write("Input your desired position(row,column): ");
                newPos = Console.ReadLine().Split(",");
                newRow = int.Parse(newPos[0]);
                newCol = int.Parse(newPos[1]);
                destination = new Position();
                destination.SetRow(newRow);
                destination.SetColumn(newCol);
                if (!checkers.MakeMove(origin, destination))
                {
                    System.Console.WriteLine("Move invalid! It's not possible to move there");
                    System.Console.WriteLine();
                }
            } while (!checkers.MakeMove(origin, destination));

            Console.Clear();
            Console.WriteLine($"Player 1 Name = {player1.GetName()}, ID = {player1.GetID()}, Piece left = {checkers.GetPlayerPieces(player1).Count}");
            Console.WriteLine($"Player 2 Name = {player2.GetName()}, ID = {player2.GetID()}, Piece left = {checkers.GetPlayerPieces(player2).Count}");
            DrawBoard(checkers);
            System.Console.WriteLine("=========================================");
            if (checkers.SwitchTurn())
            {
                Console.WriteLine($"               {player1.GetName()} Turn               ");
            }
            else
            {
                Console.WriteLine($"               {player2.GetName()} Turn               ");
            }
            System.Console.WriteLine("=========================================");
        }
        System.Console.WriteLine();

        if (checkers.GetGameStatus().Equals(GameStatus.BlackWin))
        {
            System.Console.WriteLine("=========================================");
            System.Console.WriteLine($"             {player1.GetName()} Win               ");
            System.Console.WriteLine("=========================================");
        }
        else if (checkers.GetGameStatus().Equals(GameStatus.RedWin))
        {
            System.Console.WriteLine("=========================================");
            System.Console.WriteLine($"             {player2.GetName()} Win               ");
            System.Console.WriteLine("=========================================");
        }

        Console.ReadLine();
    }
}