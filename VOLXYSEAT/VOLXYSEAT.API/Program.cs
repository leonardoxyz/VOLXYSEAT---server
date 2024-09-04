using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Text;
using VOLXYSEAT.DOMAIN.Core;
using VOLXYSEAT.DOMAIN.Models;
using VOLXYSEAT.DOMAIN.Repositories;
using VOLXYSEAT.INFRASTRUCTURE.Data;
using VOLXYSEAT.INFRASTRUCTURE.Repositories;
using VOLXYSEAT.INFRASTRUCTURE.Services;

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

builder.Services.AddIdentityCore<User>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

    options.SignIn.RequireConfirmedEmail = true;
})
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddEntityFrameworkStores<DataContext>()
    .AddSignInManager<SignInManager<User>>()
    .AddUserManager<UserManager<User>>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<JWTService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateIssuer = true,
        ValidateAudience = true,
    });


builder.Services.AddSingleton<IDbConnection>(provider =>
{
 var connection = new SqlConnection(builder.Configuration.GetConnectionString("Homologation"));
    connection.Open();
    return connection;
});

// Register repositories
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();

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
