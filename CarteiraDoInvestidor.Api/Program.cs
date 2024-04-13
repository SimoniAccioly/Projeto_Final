using CarteiraDoInvestidor.Application.Conta;
using CarteiraDoInvestidor.Application.Conta.Profile;
using CarteiraDoInvestidor.Application.Investimentos;
using CarteiraDoInvestidor.Repository;
using CarteiraDoInvestidor.Repository.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CarteiraDoInvestidorContext>(c =>
{
    c.UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("CarteiraDoInvestidorConnection"));
});

builder.Services.AddAutoMapper(typeof(UsuarioProfile).Assembly);

//Repositories
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<PlanoRepository>();
builder.Services.AddScoped<CarteiraRepository>();

//Services
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<CarteiraService>();

var app = builder.Build();

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
