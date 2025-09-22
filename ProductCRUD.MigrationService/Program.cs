using ProductCRUD.MigrationService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductCRUD.ApiModels;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<ApiDbInitializer>();

builder.AddServiceDefaults();

builder.Services.AddDbContextPool<ProductDbContext>(options =>
                                                        options.UseNpgsql(
                                                            builder.Configuration.GetConnectionString("productDb"),
                                                            sqlOptions =>
                                                                sqlOptions.MigrationsAssembly(
                                                                    "ProductCRUD.MigrationService")
                                                        ));

var app = builder.Build();

app.Run();