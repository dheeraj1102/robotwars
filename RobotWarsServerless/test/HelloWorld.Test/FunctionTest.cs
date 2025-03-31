using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using Xunit;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

namespace RobotWars.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void FunctionHandler_ValidInput_ReturnsExpectedOutput()
        {
            // Arrange: Create an instance of the function and a test Lambda context.
            var function = new Function();
            ILambdaContext context = new TestLambdaContext();
            string input = "5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM";
            string expectedOutput = "1 3 N\n5 1 E";

            // Act: Invoke the function handler.
            var result = function.FunctionHandler(input, context);

            // Assert: Verify that the output matches the expected result.
            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void FunctionHandler_InvalidInput_ThrowsArgumentException()
        {
            // Arrange: Use an invalid input string.
            var function = new Function();
            ILambdaContext context = new TestLambdaContext();
            string invalidInput = "Invalid Input";

            // Act & Assert: The handler should throw an ArgumentException.
            Assert.Throws<ArgumentException>(() => function.FunctionHandler(invalidInput, context));
        }
    }
    }