using System.Runtime.Serialization.Json;
using System.Text;

namespace CheckersGameLib;

public partial class GameRunner
{
    private Dictionary<IPlayer, List<Piece>> _playerPieces = new Dictionary<IPlayer, List<Piece>>();
    private IBoard _board;
    // private PieceColor _pieceColor;
    // private Position _position;
    private GameStatus _gameStatus;
    private bool _isPlayerTurn = true;
    List<Piece> importedPieces;

    public GameRunner()
    {
    }

    public GameRunner(IBoard board)
    {
        _board = board;
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Piece>));

        // Deserialize
        using (FileStream fs = new FileStream(@"..\CheckersGameLib\pieces.json", FileMode.Open))
        {
            importedPieces = (List<Piece>)serializer.ReadObject(fs);
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
        foreach (var kvp in _playerPieces)
        {
            int eatenPieces = 0;
            PieceColor pc = PieceColor.Black;
            var pieces = kvp.Value.ToList();
            foreach (var piece in pieces)
            {
                if (piece.GetIsEaten())
                {
                    eatenPieces++;
                    pc = piece.GetPieceColor();
                }
            }
            if (eatenPieces == 12)
            {
                if (pc.Equals(PieceColor.Black))
                {
                    return GameStatus.RedWin;
                }
                else
                {
                    return GameStatus.BlackWin;
                }
            }
        }
        return GameStatus.Ongoing;
    }
}