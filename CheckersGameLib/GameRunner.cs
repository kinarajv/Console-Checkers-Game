using System.Runtime.Serialization.Json;

namespace CheckersGameLib;

public partial class GameRunner
{
    private Dictionary<IPlayer, List<Piece>> _playerPieces = new Dictionary<IPlayer, List<Piece>>();
    readonly private IBoard _board;
    private bool _isPlayerTurn;
    readonly List<Piece>? importedPieces;

    public GameRunner()
    {
        _isPlayerTurn = false;

        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Piece>));

        string path = @"pieces.json";
        string fullPath = Path.GetFullPath(path);

        // Deserialize
        using (FileStream fs = new FileStream(fullPath, FileMode.Open))
        {
            importedPieces = (List<Piece>?)serializer.ReadObject(fs);
        }
    }

    public GameRunner(IBoard board)
    {
        _board = board;
        _isPlayerTurn = false;

        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Piece>));

        string path = @"pieces.json";
        string fullPath = Path.GetFullPath(path);

        // Deserialize
        using (FileStream fs = new FileStream(fullPath, FileMode.Open))
        {
            importedPieces = (List<Piece>?)serializer.ReadObject(fs);
        }
    }

    public int GetBoardBoundary()
    {
        return _board.GetSize();
    }

    public bool AddPlayer(IPlayer player)
    {
        List<Piece> pieces = new();
        Random random = new Random();
        int id = random.Next(20000, 30000);

        if (!_playerPieces.ContainsKey(player))
        {
            int playerTotal = _playerPieces.Count;

            // If there is no player added
            if (playerTotal == 0)
            {
                player.SetID(id);
                for (int i = 0; i < importedPieces.Count - 12; i++)
                {
                    pieces.Add(importedPieces[i]);
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
                for (int i = 12; i < importedPieces.Count; i++)
                {
                    pieces.Add(importedPieces[i]);
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
        List<Piece> playerPieces = new();

        foreach (var kvp in _playerPieces)
        {
            var pieces = kvp.Value.ToList();
            if (kvp.Key == player)
            {
                foreach (var piece in pieces)
                {
                    if (!piece.GetIsEaten())
                    {
                        playerPieces.Add(piece);
                    }
                }
            }
        }
        return playerPieces;
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

    // Switch Player Turn
    public bool SwitchTurn()
    {
        if (_isPlayerTurn)
        {
            _isPlayerTurn = false;
        }
        else
        {
            _isPlayerTurn = true;
        }
        return _isPlayerTurn;
    }

    public GameStatus GetGameStatus()
    {
        int i = 0;
        foreach (var kvp in _playerPieces)
        {
            int pieceLeft = GetPlayerPieces(kvp.Key).Count;
            if (pieceLeft == 0)
            {
                if (i == 0)
                {
                    return GameStatus.RedWin;
                }
                else
                {
                    return GameStatus.BlackWin;
                }
            }
            i++;
        }
        return GameStatus.Ongoing;
    }

    public bool PiecePromotion(Piece p)
    {
        if (p.GetPieceColor().Equals(PieceColor.Black))
        {
            if (p.GetPosition().GetRow() == 7)
            {
                p.SetIsKinged(true);
            }
        }
        else
        {
            if (p.GetPosition().GetRow() == 0)
            {
                p.SetIsKinged(true);
            }
        }

        if (p.GetIsKinged())
        {
            p.SetRank(Rank.King);
            return true;
        }
        return false;
    }
}