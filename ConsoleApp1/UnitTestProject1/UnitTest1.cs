using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TicTacToeSpace;

[TestFixture]
public class TicTacToeTests
{
    private TicTacToe game;

    [SetUp]
    public void SetUp()
    {
        game = new TicTacToe();
    }

    [Test]
    public void MakeMove_ValidMove_UpdatesBoard()
    {
        Assert.IsTrue(game.MakeMove(1));
        Assert.AreEqual('X', game.GetBoardValue(1));
    }

    [Test]
    public void MakeMove_InvalidMove_ReturnsFalse()
    {
        game.MakeMove(1);
        Assert.IsFalse(game.MakeMove(1)); // Position already taken
        Assert.IsFalse(game.MakeMove(10)); // Invalid position
    }

    [Test]
    public void CheckWin_HorizontalWin_ReturnsTrue()
    {
        game.MakeMove(1);
        game.SwitchPlayer();
        game.MakeMove(4);
        game.SwitchPlayer();
        game.MakeMove(2);
        game.SwitchPlayer();
        game.MakeMove(5);
        game.SwitchPlayer();
        game.MakeMove(3);
        Assert.IsTrue(game.CheckWin());
    }

    [Test]
    public void CheckWin_VerticalWin_ReturnsTrue()
    {
        game.MakeMove(1);
        game.SwitchPlayer();
        game.MakeMove(2);
        game.SwitchPlayer();
        game.MakeMove(4);
        game.SwitchPlayer();
        game.MakeMove(5);
        game.SwitchPlayer();
        game.MakeMove(7);
        Assert.IsTrue(game.CheckWin());
    }

    [Test]
    public void IsBoardFull_FullBoard_ReturnsTrue()
    {
        for (int i = 1; i <= 9; i++)
        {
            game.MakeMove(i);
            game.SwitchPlayer();
        }
        Assert.IsTrue(game.IsBoardFull());
    }

    [Test]
    public void ResetGame_ResetsBoardAndPlayer()
    {
        game.MakeMove(1);
        game.ResetGame();
        Assert.AreEqual(' ', game.GetBoardValue(1));
        Assert.AreEqual('X', game.CurrentPlayer);
    }
}
