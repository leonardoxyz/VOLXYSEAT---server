using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using VOLXYSEAT.DOMAIN.Core;
using VOLXYSEAT.DOMAIN.Repositories;
using VOLXYSEAT.INFRASTRUCTURE.Data;
using VOLXYSEAT.INFRASTRUCTURE.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.IncludeFields = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Entity Framework
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Homologation"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    )
);

builder.Services.AddSingleton<IDbConnection>(provider =>
{
 var connection = new SqlConnection(builder.Configuration.GetConnectionString("Homologation"));
    connection.Open();
    return connection;
});

// Register repositories
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Register UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Register MediatR and specify the assembly to scan for handlers
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Build and configure the app
var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
