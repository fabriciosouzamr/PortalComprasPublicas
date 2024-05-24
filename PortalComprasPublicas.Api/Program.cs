using Microsoft.EntityFrameworkCore;

using PortalComprasPublicas.Api.Configuration;
using PortalComprasPublicas.Application.Configuration;
using PortalComprasPublicas.Infrastructure.Data;
using PortalComprasPublicas.Infrastructure.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
        c.RoutePrefix = string.Empty; // Abre o Swagger na raiz do aplicativo
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
