using System.Text;

namespace CheckersGameLib;

public class GameRunnerTest
{
    private Dictionary<IPlayer, List<Piece>> _playerPieces;
    private IBoard _board;
    // private PieceColor _pieceColor;
    // private Position _position;
    private GameStatus _gameStatus;

    public GameRunnerTest()
    {
        _playerPieces = new Dictionary<IPlayer, List<Piece>>();
    }

    public GameRunnerTest(IBoard board)
    {
        _playerPieces = new Dictionary<IPlayer, List<Piece>>();
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
                    if (!piece.GetIsEaten())
                    {
                        return piece;
                    }
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
        int inputRow = position.GetRow();
        int inputColumn = position.GetColumn();
        _playerPieces.TryGetValue(player, out List<Piece> playerPieces);
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
        int row = piece.GetPosition().GetRow();
        int column = piece.GetPosition().GetColumn();
        PieceColor black = PieceColor.Black;
        Rank basic = Rank.Basic;
        List<Position> posList = new List<Position>();
        if (piece.GetRank().Equals(basic))
        {
            if (piece.GetPieceColor().Equals(black))
            {
                Piece pSingleP1P1 = CheckPiece(row + 1, column + 1);
                Piece pSingleP1M1 = CheckPiece(row + 1, column - 1);
                if (pSingleP1P1 != null) // Klo di serong + 11 ada
                {
                    if (!pSingleP1P1.GetPieceColor().Equals(black)) // Klo di serong + 11 merah
                    {
                        Piece pEatP2P2 = CheckPiece(row + 2, column + 2);
                        if (pEatP2P2 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong + 22 merah
                        {
                            pSingleP1P1.SetIsEaten(true);
                            posList.Add(new Position(row + 2, column + 2));
                            Piece pDoubleP3P3 = CheckPiece(row + 3, column + 3);
                            if (pDoubleP3P3 != null) // Klo di serong + 33 ada
                            {
                                if (!pDoubleP3P3.GetPieceColor().Equals(black)) // Klo di serong + 33 merah
                                {
                                    Piece pEatP4P4 = CheckPiece(row + 4, column + 4);
                                    if (pEatP4P4 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong + 44 kosong
                                    {
                                        pDoubleP3P3.SetIsEaten(true);
                                        posList.Add(new Position(row + 4, column + 4));
                                    }

                                }
                            }

                            Piece pDoubleP3P1 = CheckPiece(row + 3, column + 1);
                            if (pDoubleP3P1 != null) // Klo di serong + 31 ada
                            {
                                if (!pDoubleP3P1.GetPieceColor().Equals(black)) // Klo di serong + 31 merah
                                {
                                    Piece pEatP4P0 = CheckPiece(row + 4, column + 0);
                                    if (pEatP4P0 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong + 40 kosong
                                    {
                                        pDoubleP3P1.SetIsEaten(true);
                                        if (!posList.Contains(new Position(row + 4, column + 0)))
                                        {
                                            posList.Add(new Position(row + 4, column + 0));
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
                else if (pSingleP1M1 != null) // Klo di serong +1-1 ada
                {
                    if (!pSingleP1M1.GetPieceColor().Equals(black)) // Klo di serong +1-1 merah
                    {
                        Piece pEatP2M2 = CheckPiece(row + 2, column - 2);
                        if (pEatP2M2 == null && row < GetBoardBoundary() && column >= 0) // Klo di serong + 22 merah
                        {
                            pSingleP1M1.SetIsEaten(true);
                            posList.Add(new Position(row + 2, column - 2));
                            Piece pDoubleP3M3 = CheckPiece(row + 3, column - 3);
                            if (pDoubleP3M3 != null) // Klo di serong + 33 ada
                            {
                                if (!pDoubleP3M3.GetPieceColor().Equals(black)) // Klo di serong + 33 merah
                                {
                                    Piece pEatP4P4 = CheckPiece(row + 4, column + 4);
                                    if (pEatP4P4 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong + 44 kosong
                                    {
                                        pDoubleP3M3.SetIsEaten(true);
                                        posList.Add(new Position(row + 4, column + 4));
                                    }

                                }
                            }

                            Piece pDoubleP3M1 = CheckPiece(row + 3, column - 1);
                            if (pDoubleP3M1 != null) // Klo di serong + 31 ada
                            {
                                if (!pDoubleP3M1.GetPieceColor().Equals(black)) // Klo di serong + 31 merah
                                {
                                    Piece pEatP4P0 = CheckPiece(row + 4, column + 0);
                                    if (pEatP4P0 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong + 40 kosong
                                    {
                                        pDoubleP3M1.SetIsEaten(true);
                                        if (!posList.Contains(new Position(row + 4, column + 0)))
                                        {
                                            posList.Add(new Position(row + 4, column + 0));
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
                else
                {
                    if (column + 1 < GetBoardBoundary())
                    {
                        posList.Add(new Position(row + 1, column + 1));
                    }
                    posList.Add(new Position(row + 1, column - 1));
                }
                // posList.Add(new Position(row + 1, column + 1));
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
            if (piece.GetPieceColor().Equals(black))
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
        return isValid;
    }
}