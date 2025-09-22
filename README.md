# learn_aspnet_core_amazon_ec2
Based on samples from [aspire-samples](https://github.com/dotnet/aspire-samples/tree/f2b267b921dba75e5f292bf1dcdc7f4997d8b0fe/samples/DatabaseMigrations) and [codewithmukesh](https://github.com/iammukeshm/hosting-aspnet-core-webapi-on-amazon-ec2).

Demonstrates
- ASP.NET Core Web API
- Using Aspire with PostgreSQL
- Using Aspire with Migrations using the technique of a startup service

## Prerequisites

To run this project, you will need:
- .NET 9 SDK installed
- Aspire.CLI installed

You can install the Aspire CLI as a .NET global tool:

```bash
# Install Aspire CLI
dotnet tool install -g Aspire.Cli

# Verify installation
aspire --version
```

## To Run
- Clone the repository
- Navigate to the project directory
- Run the application using the command: `aspire run`