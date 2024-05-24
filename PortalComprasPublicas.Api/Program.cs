/// <summary>
/// Classe de inicialização da api web
/// </summary>

using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using PortalComprasPublicas.Api.Configuration;
using PortalComprasPublicas.Application.Configuration;
using PortalComprasPublicas.Infrastructure.Data;
using PortalComprasPublicas.Infrastructure.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {

        Title = "Microserviço WebApi RestFul",
        Version = "v1",
        Description = "Microserviços desenvolvido pra cadastro de clientes e produtos, com log de alterações. O LogSec está usando uma base SqlLite. Inclusão, atualização e exclusão de clientes e produtos serão registros no LogSec.",
        Contact = new OpenApiContact()
        {
            Name = "Fabrício Souza Moreira",
            Url = new Uri("https://fabriciosouzamr.com.br/"),
            Email = "fabriciosouzamr@yahoo.com.br",
        }
    });
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});

builder.AddAutoMapperConfig();
builder.AddDependencyInjectionConfig();

builder.Services.AddDbContext<SqlLiteDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("SqlLiteConnection"));
});
builder.Services.AddDbContext<MySqlDbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnectionString"), new MySqlServerVersion(new Version(8, 0, 21)));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Meu Projeto API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
