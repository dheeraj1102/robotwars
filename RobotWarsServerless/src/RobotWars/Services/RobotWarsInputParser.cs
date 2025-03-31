using System;
using System.Collections.Generic;
using RobotWars.Domain.Models;
using RobotWars.Enums;
using RobotWars.Interfaces;

namespace RobotWars.Services;

public class RobotWarsInputParser: IInputParser
{
    public (Arena arena, IEnumerable<IInputParser.RobotCommandSet> commandSets) ParseInput(string input)
    {
        var lines = input.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
        if (lines.Length < 3)
            throw new ArgumentException("Invalid input format.");
        
        // Parse the arena dimensions from the first line
        var arenaDimensions = lines[0].Split(' ');
        
        var maxX = int.Parse(arenaDimensions[0]);
        var maxY = int.Parse(arenaDimensions[1]);
        
        var arena = new Arena(maxX, maxY);
        
        var commandSets = new List<IInputParser.RobotCommandSet>();

        for (int i = 1; i < lines.Length; i += 2)
        {
            var robotPosition = lines[i].Split(' ');
            var commands = lines[i + 1].Trim();
            
            var x = int.Parse(robotPosition[0]);
            var y = int.Parse(robotPosition[1]);
            var heading = (Direction)Enum.Parse(typeof(Direction), robotPosition[2], true);
            
            
            commandSets.Add(new IInputParser.RobotCommandSet(x, y, heading, commands));
        }

        return (arena, commandSets);
    }
    
}