using System;
using RobotWars.Interfaces;
using RobotWars.Services;
using Xunit;

namespace RobotWars.Tests;

public class RobotWarsServiceTest
{
    private readonly IRobotsWarsService _robotWarsService;

    public RobotWarsServiceTest()
    {
        // Instantiate the service using the concrete input parser.
        _robotWarsService = new RobotWarsService(new RobotWarsInputParser());
    }

    [Fact]
    public void Execute_ValidInput_ReturnsExpectedOutput()
    {
        // Arrange
        string input = "5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM";
        string expectedOutput = "1 3 N\n5 1 E";

        // Act
        string actualOutput = _robotWarsService.Execute(input);

        // Assert
        Assert.Equal(expectedOutput, actualOutput);
    }

    [Fact]
    public void Execute_InvalidInput_ThrowsArgumentException()
    {
        // Arrange: An input string that does not conform to expected format.
        string invalidInput = "Invalid Input";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _robotWarsService.Execute(invalidInput));
    }

}