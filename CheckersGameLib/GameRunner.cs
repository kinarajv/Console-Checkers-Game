namespace CheckersGameLib;

public class GameRunner
{
    private Dictionary<IPlayer, List<Piece>> _playerPieces = new();
    private IBoard _board;
    // private PieceColor _pieceColor;
    // private Position _position;
    private GameStatus _gameStatus;
    private string _name = "";
    private int _id = 0;

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
        string playerName = "";
        while (playerName.Equals("") || playerName.Equals(_name))
        {
            Console.WriteLine($"Enter Player {_playerPieces.Count + 1} Name: ");
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
            int playerTotal = _playerPieces.Count;
            if (playerTotal == 0)
            {
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
            else
            {
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

    public void InitBoard()
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
                System.Console.WriteLine($"row: {row} & column: {column}");
            }
        }
        // System.Console.WriteLine(posList.Count);

        int posIndex = 0;
        for (int i = 0; i < _board.GetSize(); i++)
        {
            if (i == 0)
            {
                System.Console.WriteLine("+---+---+---+---+---+---+---+---+");
            }
            for (int j = 0; j <= _board.GetSize(); j++)
            {
                if (j == _board.GetSize())
                {
                    System.Console.Write($"|");
                }
                else
                {
                    if (posIndex == posList.Count)
                    {
                        System.Console.Write($"|   ");
                    }
                    else if (posList[posIndex].GetRow() == i && posList[posIndex].GetColumn() == j)
                    {
                        if (i <= 2)
                        {
                            System.Console.Write($"| R ");
                            posIndex++;
                        }
                        else if (i >= 5)
                        {
                            System.Console.Write($"| B ");
                            posIndex++;
                        }
                    }
                    else
                    {
                        System.Console.Write($"|   ");
                    }
                }
            }
            System.Console.WriteLine();
            System.Console.WriteLine("+---+---+---+---+---+---+---+---+");
        }
    }
}