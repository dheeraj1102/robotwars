using System.Collections.Generic;
using RobotWars.Domain.Models;
using RobotWars.Enums;

namespace RobotWars.Interfaces;

public interface IInputParser
{
    (Arena arena, IEnumerable<RobotCommandSet> commandSets) ParseInput(string input);
    
    public record RobotCommandSet(int X, int Y,Direction Heading,string Commands);
}