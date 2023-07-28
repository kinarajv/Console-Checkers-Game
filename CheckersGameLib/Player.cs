namespace CheckersGameLib;

public class Player : IPlayer
{
    private string name;
    private int id;

    public string GetName()
    {
        return name;
    }

    public bool SetName(string name)
    {
        if (name != null)
        {
            this.name = name;
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetID()
    {
        return id;
    }

    public bool SetID(int id)
    {
        if (id != 0)
        {
            this.id = id;
            return true;
        }
        else
        {
            return false;
        }
    }
}