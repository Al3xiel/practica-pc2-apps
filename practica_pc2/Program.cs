using Microsoft.EntityFrameworkCore;
using practica_pc2.Shared.Domain.Repositories;
using practica_pc2.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using practica_pc2.Shared.Infrastructure.Persistence.EFC.Configuration;
using practica_pc2.Shared.Infrastructure.Persistence.EFC.Repositories;
using practica_pc2.Work.Application.Internal.CommandServices;
using practica_pc2.Work.Application.Internal.QueryServices;
using practica_pc2.Work.Domain.Repositories;
using practica_pc2.Work.Domain.Services;
using practica_pc2.Work.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString is null)
    throw new Exception("Connection string is null.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString);
});

// OpenAPI/Swagger Configuration
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

//Dependency Injection Configuration

//Shared Bounded Context Dependency Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Work Bounded Context Dependency Injection Configuration
//TO-DO: Add Dependency Injection Configuration Here Repositories, and Services commands and queries
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();

var app = builder.Build();

// Verify Database Objects are Created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
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