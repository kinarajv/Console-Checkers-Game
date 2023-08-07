namespace CheckersGameLib;

public class Player : IPlayer
{
    private string _name;
    private int _id;

    public Player()
    {
    }

    public Player(string name)
    {
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }

    public bool SetName(string name)
    {
        if (name != null)
        {
            _name = name;
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetID()
    {
        return _id;
    }

    public bool SetID(int id)
    {
        if (id != 20000)
        {
            _id = id;
            return true;
        }
        else
        {
            return false;
        }
    }
}