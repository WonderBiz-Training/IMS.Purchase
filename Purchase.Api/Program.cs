using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Purchase.Application.Commands.PurchaseProductsCommands.CreatePurchaseProductsCommand;
using Purchase.Application.Commands.PurchaseProductsCommands.DeletePurchaseProductsCommand;
using Purchase.Application.Commands.PurchaseProductsCommands.UpdatePurchaseProductsCommand;
using Purchase.Application.Commands.PurchasesCommands.CreatePurchasesCommand;
using Purchase.Application.Commands.PurchasesCommands.DeletePurchasesCommand;
using Purchase.Application.Commands.PurchasesCommands.UpdatePurcahsesCommand;
using Purchase.Application.Interfaces;
using Purchase.Application.Queries.PurchaseProductsQueries.GetPurchaseProductByIdQuery;
using Purchase.Application.Queries.PurchaseProductsQueries.GetPurchaseProductsQuery;
using Purchase.Application.Queries.PurchasesQueries.GetPurchaseByIdQuery;
using Purchase.Application.Queries.PurchasesQueries.GetPurchasesQuery;
using Purchase.Application.Services;
using Purchase.Infrastructure.Data;
using Purchase.Infrastructure.Interfaces;
using Purchase.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

Env.Load();

builder.Services.AddDbContext<PurchaseDbContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_URL"), b => b.MigrationsAssembly("Purchase.Api")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreatePurchaseProductsCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdatePurchaseProductsCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeletePurchaseProductsCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetPurchaseProductsQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetPurchaseProductByIdQueryHandler).Assembly));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreatePurchasesCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdatePurchasesCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeletePurchasesCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetPurchasesQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetPurchaseByIdQueryHandler).Assembly));

builder.Services.AddScoped<IPurchaseProductsRepositories, PurchaseProductsRepositories>();
builder.Services.AddScoped<IPurchaseProductsServices, PurchaseProductsServices>();

builder.Services.AddScoped<IPurchasesRepositories, PurchasesRepositories>();
builder.Services.AddScoped<IPurchasesServices, PurchasesServices>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
