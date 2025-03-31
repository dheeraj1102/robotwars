namespace RobotWars.Domain.Models;

public class Arena
{
    public int MaxXCoordinate { get; }
    public int MaxYCoordinate { get; }

    public Arena(int maxXCoordinate, int maxYCoordinate)
    {
        MaxXCoordinate = maxXCoordinate;
        MaxYCoordinate = maxYCoordinate;
    }

    public bool IsWithinBounds(int x, int y)
    {
        return x >= 0 && x <= MaxXCoordinate && y >= 0 && y <= MaxYCoordinate;
    }
}