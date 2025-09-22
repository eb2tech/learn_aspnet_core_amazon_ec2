var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
                      .WithPgAdmin()
                      .WithLifetime(ContainerLifetime.Persistent);

if (builder.ExecutionContext.IsRunMode)
{
    // Data volumes don't work on ACA for Postgres so only add when running
    postgres.WithDataVolume();
}

var productDb = postgres.AddDatabase("productDb");

var migrationService = builder.AddProject<Projects.ProductCRUD_MigrationService>("migration")
                              .WithReference(productDb)
                              .WaitFor(productDb);

var apiService = builder.AddProject<Projects.ProductCRUD_ApiService>("apiService")
                        .WithHttpHealthCheck("/health")
                        .WithReference(productDb)
                        .WaitForCompletion(migrationService);

builder.AddProject<Projects.ProductCRUD_Web>("webFrontend")
       .WithExternalHttpEndpoints()
       .WithHttpHealthCheck("/health")
       .WithReference(apiService)
       .WaitFor(apiService);

builder.Build().Run();