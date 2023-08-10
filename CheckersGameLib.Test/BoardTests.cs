namespace CheckersGameLib.Test;

public class BoardTests
{
    private IBoard _board;

    [SetUp]
    public void Setup()
    {
        _board = new Board();
    }

    [TestCase(8)]
    [TestCase(9)]
    [TestCase(11)]
    public void GetSizeTest(int expected)
    {
        _board.SetSize(expected);
        int actual = _board.GetSize();
        Assert.That(expected, Is.EqualTo(actual));
    }
    
    [TestCase(7, false)]
    [TestCase(8, true)]
    [TestCase(9, true)]
    public void SetSizeTest(int size, bool expected)
    {
        bool actual = _board.SetSize(size);
        Assert.That(expected, Is.EqualTo(actual));
    }
}