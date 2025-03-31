using System;
using RobotWars.Enums;

namespace RobotWars.Domain.Models;

public class Robot
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Direction Heading { get; private set; }
    private readonly Arena _arena;

    public Robot(int x, int y, Direction heading, Arena arena)
    {
        X = x;
        Y = y;
        Heading = heading;
        _arena = arena;
    }

    //process the command string by character
    public void ProcessCommand(string command)
    {
        foreach (var c in command)
        {
            switch (c)
            {
                case 'L':
                    TurnLeft();
                    break;
                case 'R':
                    TurnRight();
                    break;
                case 'M':
                    Move();
                    break;
                default:
                    throw new InvalidOperationException($"Invalid command: {c}");
            }
            DebugState(c); 
        }
    }

    // rotate 90 degrees to the left
    private void TurnLeft()
    {
        Heading = (Direction)(((int)Heading + 3) % 4);
    }

    //rotate 90 degrees to the right
    private void TurnRight()
    {
        Heading = (Direction)(((int)Heading + 1) % 4);
    }

    // for debugging purposes
    private void DebugState(char command)
    {
        Console.WriteLine($"After command {command}: X = {X}, Y = {Y}, Heading = {Heading}");
    }

    // moves the robot one step in the direction, if it is within the arena bounds
    private void Move()
    {
        var newX = X;
        var newY = Y;

        switch (Heading)
        {
            case Direction.N:
                newY++;
                break;
            case Direction.E:
                newX++;
                break;
            case Direction.S:
                newY--;
                break;
            case Direction.W:
                newX--;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        if (!_arena.IsWithinBounds(newX, newY)) return;
        X = newX;
        Y = newY;
    }

    public override string ToString()
    {
        return $"{X} {Y} {Heading}";
    }
}