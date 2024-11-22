using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using Proj_ProspEco.Data;

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao container
builder.Services.AddControllersWithViews();

// Registrar o DbContext com a connection string
var connectionString = builder.Configuration.GetConnectionString("OracleFIAP");
builder.Services.AddDbContext<ProspEcoDbContext>(options =>
{
    // Verifica se a string de conex�o n�o est� nula
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("A string de conex�o 'OracleFIAP' n�o est� configurada.");
    }

    options.UseOracle(connectionString);
});

// Registrar o servi�o de Swagger (se necess�rio para documentar a API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura��o do pipeline de requisi��es HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Middleware de redirecionamento para HTTPS
app.UseHttpsRedirection();
app.UseStaticFiles();

// Configura��o de roteamento
app.UseRouting();
app.UseAuthorization();

// Configura��o de Swagger (apenas em desenvolvimento)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Proj_ProspEco API V1");
    });
}

// Configura��o da rota padr�o
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Iniciar o aplicativo
app.Run();
