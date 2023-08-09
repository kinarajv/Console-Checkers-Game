using System.Runtime.Serialization.Json;

namespace CheckersGameLib;

public partial class GameRunner
{
    public event EventHandler<WinnerEventArgs> WinnerDecided;

    private Dictionary<IPlayer, List<IPiece>> _playerPieces;
    readonly private IBoard _board;
    private bool _isPlayerTurn;
    readonly List<Piece>? importedPieces;

    public GameRunner()
    {
        _isPlayerTurn = false;
        _playerPieces = new Dictionary<IPlayer, List<IPiece>>();

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
        _playerPieces = new Dictionary<IPlayer, List<IPiece>>();

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
        List<IPiece> pieces = new();
        Random random = new Random();
        int id = random.Next(20000, 30000);

        if (!_playerPieces.ContainsKey(player))
        {
            int playerTotal = _playerPieces.Count;

            // If there is no player added
            if (playerTotal == 0)
            {
                player.SetID(id);
                for (int i = 0; i < importedPieces.Count; i++)
                {
                    if (importedPieces[i].GetPieceColor().Equals(PieceColor.Black))
                    {
                        pieces.Add(importedPieces[i]);
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
                for (int i = 0; i < importedPieces.Count; i++)
                {
                    if (importedPieces[i].GetPieceColor().Equals(PieceColor.Red))
                    {
                        pieces.Add(importedPieces[i]);
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
    public ICheckersPiece CheckPiece(int row, int col)
    {
        foreach (var kvp in _playerPieces)
        {
            var pieceList = kvp.Value.ToList();
            foreach (ICheckersPiece piece in pieceList)
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
    public List<IPiece> GetPlayerPieces(IPlayer player)
    {
        List<IPiece> playerPieces = new();

        foreach (var kvp in _playerPieces)
        {
            var pieces = kvp.Value.ToList();
            if (kvp.Key == player)
            {
                foreach (ICheckersPiece piece in pieces)
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
    public IPiece GetPlayerPiece(IPlayer player, Position position)
    {
        int inputRow = position.GetRow();
        int inputColumn = position.GetColumn();
        _playerPieces.TryGetValue(player, out List<IPiece> playerPieces);
        foreach (var aPiece in playerPieces)
        {
            int outRow = aPiece.GetPosition().GetRow();
            int outColumn = aPiece.GetPosition().GetColumn();
            if (inputRow == outRow && inputColumn == outColumn)
            {
                return aPiece;
            }
        }
        return null;
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
                    WinnerEventArgs we = new WinnerEventArgs(kvp.Key);
                    OnWinnerDecided(we);
                    return GameStatus.RedWin;
                }
                else
                {
                    WinnerEventArgs we = new WinnerEventArgs(kvp.Key);
                    OnWinnerDecided(we);
                    return GameStatus.BlackWin;
                }
            }
            i++;
        }
        return GameStatus.Ongoing;
    }

    public bool PiecePromotion(ICheckersPiece p)
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

    protected virtual void OnWinnerDecided(WinnerEventArgs e)
    {
        if (WinnerDecided != null)
        {
            WinnerDecided?.Invoke(this, e);
        }
    }
}