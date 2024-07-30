using DATAACCESS;
using DATAACCESS.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SERVICES.Implementations;
using SERVICES.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

if (builder.Environment.IsProduction())
{
    Console.WriteLine("--> USING PRODUCTION DB...");
}
else
{
    Console.WriteLine("--> USING DEV DB...");
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IChaveMovelDigitalManager, ChaveMovelDigitalManager>();
builder.Services.AddScoped<ICreditManager, CreditManager>();
builder.Services.AddScoped<ICofidisRepo, CofidisRepo>();

builder.Services.AddDbContext<CofidisDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMemoryCache();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
