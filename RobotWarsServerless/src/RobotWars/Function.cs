using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using RobotWars.Interfaces;
using RobotWars.Services;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace RobotWars
{

    public class Function
    {

        private readonly IRobotsWarsService _robotsWarsService;
        
        public Function()
        {
            // Initialize the service here
            _robotsWarsService = new RobotWarsService(new RobotWarsInputParser());
        }
        public string FunctionHandler(string input, ILambdaContext context)
        {
            return _robotsWarsService.Execute(input);
        }
    }
}
