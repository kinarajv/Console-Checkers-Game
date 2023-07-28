namespace CheckersGameLib;

public class GameRunner
{
    private Dictionary<IPlayer, List<Piece>> _playerPieces = new();
    private IBoard _board;
    // private PieceColor _pieceColor;
    // private Position _position;
    private GameStatus _gameStatus;
    private string _name = "";
    private int _p = 0;
    private int _id = 0;

    public GameRunner()
    {
    }

    public GameRunner(IBoard board)
    {
        _board = board;
        for (int i = 0; i < board.GetSize(); i++)
        {
            if (i == 0)
            {
                System.Console.WriteLine("+---+---+---+---+---+---+---+---+");
            }
            for (int j = 0; j <= board.GetSize(); j++)
            {
                if (j == board.GetSize())
                {
                    System.Console.Write("|");
                }
                else
                {
                    System.Console.Write("|   ");
                }
            }
            System.Console.WriteLine();
            System.Console.WriteLine("+---+---+---+---+---+---+---+---+");
        }
    }

    public bool AddPlayer(IPlayer player)
    {
        List<Piece> pieces = new();
        Position position = new();
        Random random = new Random();
        string playerName = "";
        while (playerName.Equals("") || playerName.Equals(_name))
        {
            Console.WriteLine($"Enter Player {_p + 1} Name: ");
            playerName = Console.ReadLine();
        }
        _name = playerName;
        player.SetName(_name);
        int id = random.Next(20000, 29999);
        while (id == _id)
        {
            id = random.Next(20000, 29999);
        }
        player.SetID(id);
        _id = id;

        if (!_playerPieces.ContainsKey(player))
        {
            for (int i = 0; i < 12; i++)
            {
                pieces.Add(new Piece());
                pieces[i].SetRank(Rank.Basic);
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        if ((j + k) % 2 == 0)
                        {
                            position.SetRow(j);
                            position.SetColumn(k);
                        }
                    }
                }
                pieces[i].SetPosition(position);
                pieces[i].SetPieceColor((PieceColor)_p);
            }
            _p++;
            _playerPieces.Add(player, pieces);
            return true;
        }
        return false;
    }
}