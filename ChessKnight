using System;
using System.Collections.Generic;
using NUnit.Framework;

public class ChessKnight
{
    public static List<(int, int)> GetPossibleMoves(int currentX, int currentY)
    {
        List<(int, int)> possibleMoves = new List<(int, int)>();

        // Possible relative moves for a knight in chess
        int[] xOffset = { 1, 2, 2, 1, -1, -2, -2, -1 };
        int[] yOffset = { -2, -1, 1, 2, 2, 1, -1, -2 };

        for (int i = 0; i < xOffset.Length; i++)
        {
            int newX = currentX + xOffset[i];
            int newY = currentY + yOffset[i];

            // Check if the new position is within the chessboard (assuming an 8x8 board)
            if (IsValidPosition(newX, newY))
            {
                possibleMoves.Add((newX, newY));
            }
        }

        return possibleMoves;
    }

    private static bool IsValidPosition(int x, int y)
    {
        return x >= 0 && x < 8 && y >= 0 && y < 8;
    }
}

[TestFixture]
public class ChessKnightTests
{
    [Test]
    public void TestPossibleMoves_CornerPosition_ReturnsCorrectMoves()
    {
        var moves = ChessKnight.GetPossibleMoves(0, 0);
        Assert.That(moves, Is.EquivalentTo(new List<(int, int)> { (1, 2), (2, 1) }));
    }

    [Test]
    public void TestPossibleMoves_CenterPosition_ReturnsCorrectMoves()
    {
        var moves = ChessKnight.GetPossibleMoves(3, 3);
        Assert.That(moves, Is.EquivalentTo(new List<(int, int)> { (1, 2), (2, 1), (4, 2), (5, 1), (5, 4), (4, 5), (2, 5), (1, 4) }));
    }

    [Test]
    public void TestPossibleMoves_EdgePosition_ReturnsCorrectMoves()
    {
        var moves = ChessKnight.GetPossibleMoves(7, 3);
        Assert.That(moves, Is.EquivalentTo(new List<(int, int)> { (5, 2), (6, 1), (5, 4), (6, 5) }));
    }
}
