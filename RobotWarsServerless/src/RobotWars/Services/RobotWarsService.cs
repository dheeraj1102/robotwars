using System.Text;
using RobotWars.Domain.Models;
using RobotWars.Interfaces;

namespace RobotWars.Services;

public class RobotWarsService : IRobotsWarsService
{
    private readonly IInputParser _inputParser;
    
    public RobotWarsService(IInputParser inputParser)
    {
        _inputParser = inputParser;
    }

    public string Execute(string input)
    {
        var (arena, commandSets) = _inputParser.ParseInput(input);
        var output = new StringBuilder();

        foreach (var set in commandSets)
        {
            var robot = new Robot(set.X, set.Y, set.Heading, arena);
            robot.ProcessCommand(set.Commands);
            output.AppendLine(robot.ToString());
        }
        
        return output.ToString().TrimEnd();
    }

}