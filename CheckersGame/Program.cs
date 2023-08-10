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
                    Display($"Enter Player {i + 1} Name: ");
                    name = Console.ReadLine();
                    player1.SetName(name);
                } while (name == "");
            }
            else
            {
                do
                {
                    Display($"Enter Player {i + 1} Name: ");
                    name = Console.ReadLine();
                    player2.SetName(name);
                } while (name == "" || name.Equals(player1.GetName()));
            }
        }
        checkers.AddPlayer(player1);
        checkers.AddPlayer(player2);

        //3. Initialize Board %% players init pieces placed
        Console.Clear();
        DisplayLine($"Player 1 Name = {player1.GetName()}, ID = {player1.GetID()}, Piece left = {checkers.GetPlayerPieces(player1).Count}");
        DisplayLine($"Player 2 Name = {player2.GetName()}, ID = {player2.GetID()}, Piece left = {checkers.GetPlayerPieces(player2).Count}");
        DrawBoard(checkers);

        DisplayTurn(checkers, player1, player2);

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

        while (checkers.GetGameStatus().Equals(GameStatus.Ongoing))
        {
            // Player 1
            do
            {
            // Select piece that want to move
            IfNoMove: do
                {
                    do
                    {
                        Display("Input your piece's position (row,column): ");
                        currPos = Console.ReadLine().Split(",");
                        if (currPos.Length != 2)
                        {
                            DisplayLine("Input must include row and column only! Please try again with correct format (row,column).");
                        }

                    } while (currPos.Length != 2);
                    bool isCurrRowParseable = int.TryParse(currPos[0], out currRow);
                    bool isCurrColParseable = int.TryParse(currPos[1], out currCol);
                    origin = new Position();
                    origin.SetRow(currRow);
                    origin.SetColumn(currCol);
                    if (!isCurrRowParseable || !isCurrColParseable)
                    {
                        DisplayLine("Input invalid! Please try again with correct format (row,column).");
                    }
                    else if (currRow >= checkers.GetBoardBoundary() || currCol >= checkers.GetBoardBoundary())
                    {
                        DisplayLine("Input out of bound! Please try again with input in range of 0 - 7.");
                    }
                    else if (checkers.GetPlayerPiece(player1, origin) == null)
                    {
                        DisplayLine("No piece of yours in current position!");
                    }
                } while (checkers.GetPlayerPiece(player1, origin) == null);

                Piece p = (Piece)checkers.CheckPiece(currRow, currCol);
                if (checkers.GetPossibleMove(p) != null)
                {
                    var possibleMove = checkers.GetPossibleMove(p);
                    DisplayLine("Possible move: ");
                    foreach (var pos in possibleMove)
                    {
                        DisplayLine("=> " + pos.GetRow() + "," + pos.GetColumn());
                    }
                }
                else
                {
                    DisplayLine("There's no possible move for this piece.");
                    goto IfNoMove;
                }

                do
                {
                    Display("Input your desired position (row,column): ");
                    newPos = Console.ReadLine().Split(",");
                    if (newPos.Length != 2)
                    {
                        DisplayLine("Input must include row and column only! Please try again with correct format (row,column).");
                    }
                } while (newPos.Length != 2);
                bool isNewRowParseable = int.TryParse(newPos[0], out newRow);
                bool isNewColParseable = int.TryParse(newPos[1], out newCol);
                if (!isNewRowParseable || !isNewColParseable)
                {
                    DisplayLine("Input invalid! Please try again with correct format (row,column).");
                }
                else if (newRow >= checkers.GetBoardBoundary() || newCol >= checkers.GetBoardBoundary())
                {
                    DisplayLine("Input out of range! Please try again with input in range of 0 - 7.");
                }
                else
                {
                    DisplayLine("Invalid move! Please Try Again.");
                }
                destination = new Position();
                destination.SetRow(newRow);
                destination.SetColumn(newCol);
            } while (!checkers.MakeMove(origin, destination));

            Console.Clear();
            DisplayPlayer(checkers, player1, player2);
            DrawBoard(checkers);
            DisplayTurn(checkers, player1, player2);

            if (!checkers.GetGameStatus().Equals(GameStatus.Ongoing))
            {
                break;
            }

            // Player 2
            do
            {
            // Select piece that want to move
            IfNoMove: do
                {
                    do
                    {
                        Display("Input your piece's position (row,column): ");
                        currPos = Console.ReadLine().Split(",");
                        if (currPos.Length != 2)
                        {
                            DisplayLine("Input must include row and column! Please try again with correct format (row,column).");
                        }

                    } while (currPos.Length != 2);
                    bool isCurrRowParseable = int.TryParse(currPos[0], out currRow);
                    bool isCurrColParseable = int.TryParse(currPos[1], out currCol);
                    origin = new Position();
                    origin.SetRow(currRow);
                    origin.SetColumn(currCol);
                    if (!isCurrRowParseable || !isCurrColParseable)
                    {
                        DisplayLine("Input invalid! Please try again with correct format (row,column).");
                    }
                    else if (currRow >= checkers.GetBoardBoundary() || currCol >= checkers.GetBoardBoundary())
                    {
                        DisplayLine("Input out of bound! Please try again with input in range of 0 - 7.");
                    }
                    else if (checkers.GetPlayerPiece(player2, origin) == null)
                    {
                        DisplayLine("No piece of yours in current position!");
                    }
                } while (checkers.GetPlayerPiece(player2, origin) == null);

                Piece p = (Piece)checkers.CheckPiece(currRow, currCol);
                if (checkers.GetPossibleMove(p) != null)
                {
                    var possibleMove = checkers.GetPossibleMove(p);
                    DisplayLine("Possible move: ");
                    foreach (var pos in possibleMove)
                    {
                        DisplayLine("=> " + pos.GetRow() + "," + pos.GetColumn());
                    }
                }
                else
                {
                    DisplayLine("There's no possible move for this piece.");
                    goto IfNoMove;
                }

                do
                {
                    Display("Input your desired position (row,column): ");
                    newPos = Console.ReadLine().Split(",");
                    if (newPos.Length != 2)
                    {
                        DisplayLine("Input must include row and column! Please try again with correct format (row,column).");
                    }
                } while (newPos.Length != 2);
                bool isNewRowParseable = int.TryParse(newPos[0], out newRow);
                bool isNewColParseable = int.TryParse(newPos[1], out newCol);
                if (!isNewRowParseable || !isNewColParseable)
                {
                    DisplayLine("Input invalid! Please try again with correct format (row,column).");
                }
                else if (newRow >= checkers.GetBoardBoundary() || newCol >= checkers.GetBoardBoundary())
                {
                    DisplayLine("Input out of range! Please try again with input in range of 0 - 7.");
                }
                else
                {
                    DisplayLine("Invalid move! Please Try Again.");
                }
                destination = new Position();
                destination.SetRow(newRow);
                destination.SetColumn(newCol);
            } while (!checkers.MakeMove(origin, destination));

            Console.Clear();
            DisplayPlayer(checkers, player1, player2);
            DrawBoard(checkers);

            DisplayTurn(checkers, player1, player2);
        }

        Console.Clear();
        DrawBoard(checkers);
        RegisterCheckersWinner(checkers);
        checkers.GetGameStatus();
        UnregisterCheckersWinner(checkers);

        Console.ReadLine();
    }
}