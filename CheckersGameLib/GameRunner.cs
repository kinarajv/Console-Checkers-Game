using System.Text;

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

    public int GetBoardBoundary()
    {
        return _board.GetSize();
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
                            pieces[i].SetPieceColor((PieceColor)playerTotal);
                            pieces[i].SetRank(Rank.Basic);
                            position[i].SetRow(row);
                            position[i].SetColumn(column);
                            pieces[i].SetPosition(position[i]);
                            // System.Console.WriteLine((PieceColor)playerTotal);
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
                    player.SetID(id);
                    foreach (var kvp in _playerPieces)
                    {
                        int playerID = kvp.Key.GetID();
                        if (id == playerID)
                        {
                            isIDUnique++;
                        }
                    }
                    id = random.Next(20000, 30000);
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
                            pieces[i].SetPieceColor((PieceColor)playerTotal);
                            pieces[i].SetRank(Rank.Basic);
                            position[i].SetRow(row);
                            position[i].SetColumn(column);
                            pieces[i].SetPosition(position[i]);
                            // System.Console.WriteLine(pieces[i].SetPieceColor((PieceColor)playerTotal));
                            // System.Console.WriteLine("x: " + pieces[i].GetPosition().GetRow() + ", y: " + pieces[i].GetPosition().GetColumn());
                            i++;
                        }
                    }
                }
            }
            // System.Console.WriteLine((PieceColor)playerTotal);
            _playerPieces.Add(player, pieces);
            return true;
        }
        return false;
    }

    //Check Piece
    public Piece CheckPiece(int row, int col)
    {
        foreach (var kvp in _playerPieces)
        {
            var pieceList = kvp.Value.ToList();
            foreach (Piece piece in pieceList)
            {
                if (piece.GetPosition().GetRow() == row && piece.GetPosition().GetColumn() == col)
                {
                    return piece;
                }
            }
        }
        return null;
    }

    // Get Player Pieces
    public List<Piece> GetPlayerPieces(IPlayer player)
    {
        // List<Piece> playerPieces = new();
        bool piecesPerPlayer = _playerPieces.TryGetValue(player, out List<Piece> playerPieces);
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
        // bool isOccupied = false;
        // bool isOwned = false;
        // bool isMove;
        // int basicMove;
        // int singleMove;
        // int doubleMove;
        int[] nextPos = new int[2];
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
                    Piece pSingle = CheckPiece(row + 1, column + 1);
                    if (pSingle != null)
                    {
                        if (!pSingle.GetPieceColor().Equals(black))
                        {
                            Piece pEat = CheckPiece(row + 2, column + 2);
                            if (pEat == null)
                            {
                                pSingle.SetIsEaten(true);
                                posList.Add(new Position(row + 2, column + 2));
                            }
                        }
                    }
                    else
                    {
                        posList.Add(new Position(row + 1, column + 1));
                    }
                    // posList.Add(new Position(row + 1, column + 1));
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

    public bool MakeMove(Position origin, Position destination)
    {
        bool isValid = false;
        int originRow = origin.GetRow();
        int originCol = origin.GetColumn();

        foreach (var kvp in _playerPieces)
        {
            var pieceList = kvp.Value.ToList();
            foreach (var piece in pieceList)
            {
                // System.Console.WriteLine(pieceList.GetPosition() == origin);
                int ownedRow = piece.GetPosition().GetRow();
                int ownedCol = piece.GetPosition().GetColumn();
                if (originRow == ownedRow && originCol == ownedCol)
                {
                    piece.SetPosition(destination);
                    isValid = true;
                    break;
                }
            }

            if (isValid)
            {
                break;
            }
        }
        System.Console.WriteLine($"Origin: {origin.GetRow()}, {origin.GetColumn()}");
        System.Console.WriteLine($"Destination: {destination.GetRow()}, {destination.GetColumn()}");

        return isValid;
    }
}