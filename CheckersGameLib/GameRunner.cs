using System.Runtime.Serialization.Json;
using NLog;

namespace CheckersGameLib;

public partial class GameRunner
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    public event EventHandler<WinnerEventArgs> WinnerDecided;

    private Dictionary<IPlayer, List<IPiece>> _playerPieces;
    readonly private IBoard _board;
    private GameStatus _gameStatus;
    private bool _isPlayerTurn;
    readonly List<Piece>? importedPieces;
    readonly Moveset _moveset;

    public GameRunner()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var nlogConfigPath = Path.Combine(currentDirectory, "logs\\nlog.config");
        LogManager.LoadConfiguration(nlogConfigPath);

        _gameStatus = GameStatus.NotStarted;
        _isPlayerTurn = false;
        _playerPieces = new Dictionary<IPlayer, List<IPiece>>();
        _moveset = new Moveset();

        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Piece>));

        string path = @"pieces.json";
        string fullPath = Path.GetFullPath(path);

        // Deserialize
        using (FileStream fs = new FileStream(fullPath, FileMode.Open))
        {
            importedPieces = (List<Piece>?)serializer.ReadObject(fs);
        }
        logger.Info("Initial game info created");
    }

    public GameRunner(IBoard board)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var nlogConfigPath = Path.Combine(currentDirectory, "logs\\nlog.config");
        LogManager.LoadConfiguration(nlogConfigPath);

        _gameStatus = GameStatus.NotStarted;
        _board = board;
        _isPlayerTurn = false;
        _playerPieces = new Dictionary<IPlayer, List<IPiece>>();
        _moveset = new Moveset();

        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Piece>));

        string path = @"pieces.json";
        string fullPath = Path.GetFullPath(path);

        // Deserialize
        using (FileStream fs = new FileStream(fullPath, FileMode.Open))
        {
            importedPieces = (List<Piece>?)serializer.ReadObject(fs);
        }
        logger.Info("Initial game info created..");
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
            _playerPieces.Add(player, pieces);
            logger.Info($"Add {player.GetName()} as checkers player success.");
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
                        logger.Info("Retrieve a piece success. This piece is on board.");
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
        logger.Info("Retrieve player pieces on board success.");
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
        return _gameStatus;
    }

    public bool SetGameStatus(GameStatus gameStatus)
    {
        if (!gameStatus.Equals(_gameStatus))
        {
            _gameStatus = gameStatus;
            logger.Info($"Set Game Status for checkers success. Game Status now is {_gameStatus}");
            return true;
        }
        return false;
    }

    public IPlayer CheckWinner()
    {
        Dictionary<IPlayer, int> playerPiecesLeft = new Dictionary<IPlayer, int>();
        foreach (var kvp in _playerPieces)
        {
            if (GetPlayerPieces(kvp.Key).Count == 0)
            {
                playerPiecesLeft.Add(kvp.Key, 0);
                var pieces = kvp.Value.ToList();
                foreach (var piece in pieces)
                {
                    if (piece.GetPieceColor().Equals(PieceColor.Red))
                    {
                        SetGameStatus(GameStatus.BlackWin);
                    }
                    else
                    {
                        SetGameStatus(GameStatus.RedWin);
                    }
                }
            }
            else
            {
                playerPiecesLeft.Add(kvp.Key, GetPlayerPieces(kvp.Key).Count);
            }
        }

        playerPiecesLeft = playerPiecesLeft.OrderBy(c => c.Value).ToDictionary(p => p.Key, c => c.Value);

        if (playerPiecesLeft.Values.First() == 0)
        {
            WinnerEventArgs we = new WinnerEventArgs(playerPiecesLeft.Keys.Last());
            OnWinnerDecided(we);
            logger.Info($"The winner of the checkers game is {playerPiecesLeft.Keys.Last().GetName()}");
            return playerPiecesLeft.Keys.Last();
        }
        logger.Info($"The game is still Ongoing");
        SetGameStatus(GameStatus.Ongoing);
        return null;
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
            logger.Info("A basic piece has been promoted to a king piece!. Now it can move backward");
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