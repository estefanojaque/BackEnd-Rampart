using catch_up_platform.Dishes;
using catch_up_platform.Dishes.Application.Internal.CommandServices; // Asegúrate de tener las referencias correctas
using catch_up_platform.Dishes.Application.Internal.QueryServices;
using catch_up_platform.Dishes.Domain.Services;
using catch_up_platform.Shared.Domain.Repositories;
using catch_up_platform.Shared.Infrastructure;
using catch_up_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using catch_up_platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using catch_up_platform.UserProfile;
using catch_up_platform.UserProfile.Application.Internal.QueryServices;
using catch_up_platform.UserProfile.Application.Internal.CommandServices;
using catch_up_platform.UserProfile.Domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

/////////////////////////Begin Database Configuration/////////////////////////
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Verify Database Connection string
if (string.IsNullOrWhiteSpace(connectionString))
    throw new Exception("Database connection string is not set");

// Configure Database Context and Logging Levels
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySQL(connectionString)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    });
}
else if (builder.Environment.IsProduction())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error)
            .EnableDetailedErrors();
    });
}

// Configure Dependency Injection for UserProfile
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<IUserProfileQueryService, UserProfileQueryService>();
builder.Services.AddScoped<IUserProfileCommandService, UserProfileCommandService>();

// Configure Dependency Injection for Dishes
builder.Services.AddScoped<IDishRepository, DishRepository>(); // Asegúrate de que el repositorio esté implementado
builder.Services.AddScoped<IDishQueryService, DishQueryService>();
builder.Services.AddScoped<IDishCommandService, DishCommandService>();

/////////////////////////End Database Configuration/////////////////////////
var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.Migrate(); // Handle migrations
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
