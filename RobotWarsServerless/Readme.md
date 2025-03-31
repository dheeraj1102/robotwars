# RobotWarsServerless

A serverless solution for the annual Robot Wars competition. This project simulates a robot navigation system in a grid-based battle arena using AWS Lambda, AWS SAM, and .NET.

## Project Overview

RobotWarsServerless processes movement commands for robots deployed in a rectangular battle arena. The application:
- Reads input describing the arena dimensions and each robot’s initial position and command sequence.
- Processes the commands for each robot sequentially.
- Returns the final coordinates and orientation for each robot.

## Project Structure
~~~~
RobotWarsServerless/
├── .gitignore
├── omnisharp.json
├── samconfig.toml
├── template.yaml
├── RobotWars/
│   ├── Dependencies/
│   ├── Domain/
│   ├── Interfaces/
│   ├── Services/
│   ├── aws-lambda-tools-defaults.json
│   ├── Function.cs
│   └── Readme.md
├── RobotWars.Tests/
│   ├── Dependencies/
│   ├── FunctionTest.cs
│   └── RobotWarsServiceTest.cs
└── Scratches and Consoles
~~~~
## Prerequisites

- **AWS SAM CLI:** [Installation Instructions](https://docs.aws.amazon.com/serverless-application-model/latest/developerguide/install-sam-cli.html)
- **Docker:** For local Lambda emulation.
- **.NET 8 SDK:** [Download .NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- AWS credentials configured (via AWS CLI or your IDE).

## Building the Project

From the project root (where `template.yaml` is located), run:

```bash
sam build
```
This command compiles your .NET project located in the src/RobotWars directory and prepares it for deployment.

## Running Tests

Run  unit tests using the .NET CLI. From the project root or the test/RobotWars.Tests folder, execute:
```bash
dotnet test
```

## Local API Testing

You can test your Lambda function locally before deploying it to AWS. There are two primary approaches:

### 1. API Gateway Emulation

SAM can emulate an API Gateway locally so that you can interact with your function via HTTP requests.

- **Start the Local API:**  
  From the project root (where `template.yaml` is located), run:
  ```bash
  sam local start-api
  ```

- This command starts a local server (by default at http://127.0.0.1:3000) that emulates API Gateway.
- Test the API Endpoint:
With the API running, open your browser or use a tool like curl or Postman to test the endpoint. For example:
- ```bash
  curl http://127.0.0.1:3000/robotwars
  ```
  
### 2. Direct Function Invocation

If you prefer to test your function without the API Gateway layer, you can invoke it directly.
•	Create an Event File:
Create a JSON file (e.g., event.json) that simulates the input your function expects. For example:
```json
{
  "input": "5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM"
}
```
•	Invoke the Function:
Run the following command to invoke your function with the event file:
```bash
sam local invoke RobotWarsFunction --event event.json
```

This command will execute the Lambda function locally, passing the contents of event.json as input. The output will be displayed in your terminal.

## Deploying to AWS (Optional)
To deploy your application to AWS, run the following command from the project root (where `template.yaml` is located):
```bash
sam deploy --guided
```
This command will prompt you for various parameters, including:
During this guided deployment, you’ll be prompted for:
- Stack Name: Provide a name for your CloudFormation stack.
- AWS Region: Choose the AWS region where you want to deploy your function.
- Confirm Changes: Review and confirm the configuration settings.
- Capabilities: Approve IAM capabilities if prompted (usually “CAPABILITY_IAM” or “CAPABILITY_NAMED_IAM”).

## Note:
For the purpose of project SAM has been used to create the Lambda function. The SAM CLI is a command-line tool that helps you develop, test, and deploy serverless applications. It provides a simplified way to manage AWS Lambda functions and their associated resources.

- The template.yaml file defines the AWS resources for your application, including the Lambda function, API Gateway, and IAM roles, this file has been configured, and validated using the sam validate and verified using the sam build commands, though it has been configured, because of absence of an actual evinronment, the deployment can't be verified. Though if required to deploy
there might be some changes that might be required. 

### The function and the code has been tested using Xunit tests. Feel free to run the test project, and also add any additional test cases if required. 


## Author
- **Name:** Dheeraj Sandeep


