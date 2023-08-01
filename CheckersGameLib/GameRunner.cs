namespace CheckersGameLib;

public class GameRunner
{
    private Dictionary<IPlayer, List<Piece>> _playerPieces = new Dictionary<IPlayer, List<Piece>>();
    private IBoard _board;
    // private PieceColor _pieceColor;
    // private Position _position;
    private GameStatus _gameStatus;

    public GameRunner()
    {
    }

    public GameRunner(IBoard board)
    {
        _board = board;
    }

    public bool AddPlayer(IPlayer player)
    {
        List<Piece> pieces = new();
        List<Position> position = new();
        Random random = new Random();
        int id = random.Next(20000, 30000);

        if (!_playerPieces.ContainsKey(player))
        {
            int playerTotal = _playerPieces.Count;

            // If there is no player added
            if (playerTotal == 0)
            {
                player.SetID(id);
                int i = 0;
                for (int row = 0; row < 3; row++)
                {
                    for (int column = 0; column < 8; column++)
                    {
                        int total = row + column;
                        if (total % 2 != 0)
                        {
                            pieces.Add(new Piece());
                            position.Add(new Position());
                            pieces[i].SetRank(Rank.Basic);
                            position[i].SetRow(row);
                            position[i].SetColumn(column);
                            pieces[i].SetPosition(position[i]);
                            pieces[i].SetPieceColor((PieceColor)playerTotal);
                            // System.Console.WriteLine("x: " + pieces[i].GetPosition().GetRow() + ", y: " + pieces[i].GetPosition().GetColumn());
                            i++;
                        }
                    }
                }
            }
            // If there is a player
            else
            {
                int isIDUnique;
                do
                {
                    isIDUnique = 0;
                    id = random.Next(2);
                    player.SetID(id);
                    foreach (var kvp in _playerPieces)
                    {
                        int playerID = kvp.Key.GetID();
                        if (id == playerID)
                        {
                            isIDUnique++;
                        }
                    }
                } while (isIDUnique > 0);
                int i = 0;
                for (int row = 5; row < 8; row++)
                {
                    for (int column = 0; column < 8; column++)
                    {
                        int total = row + column;
                        if (total % 2 != 0)
                        {
                            pieces.Add(new Piece());
                            position.Add(new Position());
                            pieces[i].SetRank(Rank.Basic);
                            position[i].SetRow(row);
                            position[i].SetColumn(column);
                            pieces[i].SetPosition(position[i]);
                            pieces[i].SetPieceColor((PieceColor)playerTotal);
                            // System.Console.WriteLine("x: " + pieces[i].GetPosition().GetRow() + ", y: " + pieces[i].GetPosition().GetColumn());
                            i++;
                        }
                    }
                }
            }
            _playerPieces.Add(player, pieces);
            return true;
        }
        return false;
    }

    public string InitBoard()
    {
        List<Position> posList = new();
        foreach (var pieceList in _playerPieces)
        {
            System.Console.WriteLine(pieceList.Key.GetName());
            var pieces = pieceList.Value.ToList();
            for (int i = 0; i < pieces.Count; i++)
            {
                int row = pieces[i].GetPosition().GetRow();
                int column = pieces[i].GetPosition().GetColumn();
                posList.Add(pieces[i].GetPosition());
                // System.Console.WriteLine($"row: {row} & column: {column}");
            }
        }
        // System.Console.WriteLine(posList.Count);

        int posIndex = 0;
        string board = "";
        for (int i = 0; i < _board.GetSize(); i++)
        {
            if (i == 0)
            {
                board += "+---+---+---+---+---+---+---+---+\n";
            }
            for (int j = 0; j <= _board.GetSize(); j++)
            {
                if (j == _board.GetSize())
                {
                    board += "|";
                }
                else
                {
                    if (posIndex == posList.Count)
                    {
                        board += "|   ";
                    }
                    else if (posList[posIndex].GetRow() == i && posList[posIndex].GetColumn() == j)
                    {
                        if (i <= 2)
                        {
                            board += "| B ";
                            posIndex++;
                        }
                        else if (i >= 5)
                        {
                            board += "| R ";
                            posIndex++;
                        }
                    }
                    else
                    {
                        board += "|   ";
                    }
                }
            }
            board += "\n+---+---+---+---+---+---+---+---+\n";
        }
        return board;
    }

    // Get Player Pieces
    public List<Piece> GetPlayerPieces(IPlayer player)
    {
        List<Piece> playerPieces = new();
        bool piecesPerPlayer = _playerPieces.TryGetValue(player, out playerPieces);
        if (piecesPerPlayer)
        {
            return playerPieces;
        }
        else
        {
            return null;
        }
    }

    // Get player's piece position
    public Piece GetPlayerPiece(IPlayer player, Position position)
    {
        Piece piece = new Piece();
        List<Piece> playerPieces = new();
        int inputRow = position.GetRow();
        int inputColumn = position.GetColumn();
        bool piecesPerPlayer = _playerPieces.TryGetValue(player, out playerPieces);
        foreach (var aPiece in playerPieces)
        {
            int outRow = aPiece.GetPosition().GetRow();
            int outColumn = aPiece.GetPosition().GetColumn();
            if (inputRow == outRow && inputColumn == outColumn)
            {
                return aPiece;
            }
        }

        return piece;
    }

    // Get Any available move for a player's piece
    public List<Position> GetPossibleMove(Piece piece)
    {
        bool isOccupied = false;
        bool isOwned = false;
        int pieceCount = 0;
        int row = piece.GetPosition().GetRow();
        int column = piece.GetPosition().GetColumn();
        PieceColor black = PieceColor.Black;
        Rank basic = Rank.Basic;
        List<Position> posList = new List<Position>();
        if (piece.GetRank().Equals(basic))
        {
            if (piece.GetPieceColor().Equals(black))
            {
                if (column == 0)
                {
                    foreach (KeyValuePair<IPlayer, List<Piece>> kvp in _playerPieces)
                    {
                        var pieceList = kvp.Value.ToList();
                        foreach (Piece pieces in pieceList)
                        {
                            int nextRow = pieces.GetPosition().GetRow();
                            int nextCol = pieces.GetPosition().GetColumn();

                            if (nextRow == row + 1 && nextCol == column + 1)
                            {
                                if (!pieces.GetPieceColor().Equals(black))
                                {
                                    isOccupied = true;
                                }
                            }

                            if (isOccupied)
                            {
                                if (nextRow != row + 2 && nextCol != column + 2)
                                {
                                    pieceCount++;
                                }
                                else
                                {
                                    pieceCount = 0;
                                }
                            }
                        }
                        if (pieceCount != 0)
                        {
                            posList.Add(new Position(row + 2, column + 2));
                        }
                    }
                    posList.Add(new Position(row + 1, column + 1));
                }
                else if (column == 7)
                {
                    posList.Add(new Position(row + 1, column - 1));
                }
                else
                {
                    posList.Add(new Position(row + 1, column + 1));
                    posList.Add(new Position(row + 1, column - 1));
                }
            }
            else
            {
                if (column == 0)
                {
                    posList.Add(new Position(row + 1, column + 1));
                    posList.Add(new Position(row - 1, column + 1));
                }
                else if (column == 7)
                {
                    posList.Add(new Position(row + 1, column - 1));
                    posList.Add(new Position(row - 1, column - 1));
                }
                else
                {
                    posList.Add(new Position(row + 1, column + 1));
                    posList.Add(new Position(row + 1, column - 1));
                    posList.Add(new Position(row - 1, column + 1));
                    posList.Add(new Position(row - 1, column - 1));
                }
            }
        }
        else
        {
            if (piece.GetRank() == basic)
            {
                if (column == 0)
                {
                    posList.Add(new Position(row - 1, column + 1));
                }
                else if (column == 7)
                {
                    posList.Add(new Position(row - 1, column - 1));
                }
                else
                {
                    posList.Add(new Position(row - 1, column + 1));
                    posList.Add(new Position(row - 1, column - 1));
                }
            }
            else
            {
                if (column == 0)
                {
                    posList.Add(new Position(row - 1, column + 1));
                    posList.Add(new Position(row + 1, column + 1));
                }
                else if (column == 7)
                {
                    posList.Add(new Position(row - 1, column - 1));
                    posList.Add(new Position(row + 1, column - 1));
                }
                else
                {
                    posList.Add(new Position(row - 1, column + 1));
                    posList.Add(new Position(row - 1, column - 1));
                    posList.Add(new Position(row + 1, column + 1));
                    posList.Add(new Position(row + 1, column - 1));
                }
            }
        }

        return posList;
    }
}