using Microsoft.EntityFrameworkCore;
using Universidade.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Universidade.Presentation") // Especifica o assembly das migrações
    ));

var app = builder.Build();

app.Run();