using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using Proj_ProspEco.Data;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao container
builder.Services.AddControllersWithViews();

// Registrar o DbContext com a connection string
var connectionString = builder.Configuration.GetConnectionString("OracleFIAP");
builder.Services.AddDbContext<ProspEcoDbContext>(options =>
{
    // Verifica se a string de conexão não está nula
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("A string de conexão 'OracleFIAP' não está configurada.");
    }

    options.UseOracle(connectionString);
});

// Registrar o serviço de Swagger (se necessário para documentar a API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline de requisições HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Middleware de redirecionamento para HTTPS
app.UseHttpsRedirection();
app.UseStaticFiles();

// Configuração de roteamento
app.UseRouting();
app.UseAuthorization();

// Configuração de Swagger (apenas em desenvolvimento)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Proj_ProspEco API V1");
    });
}

// Configuração da rota padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Iniciar o aplicativo
app.Run();