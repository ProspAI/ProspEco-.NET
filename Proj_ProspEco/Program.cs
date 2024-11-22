using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Oracle.EntityFrameworkCore;
using Proj_ProspEco.Data;
using Proj_ProspEco.Models;
using Proj_ProspEco.Persistencia.Repositories;
using Proj_ProspEco.Persistencia.Services;

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

// Registrar os Repositórios
builder.Services.AddScoped<IAparelhoRepository, AparelhoRepository>();
builder.Services.AddScoped<IBandeiraTarifariaRepository, BandeiraTarifariaRepository>();
builder.Services.AddScoped<IRegistroConsumoRepository, RegistroConsumoRepository>();
builder.Services.AddScoped<INotificacaoRepository, NotificacaoRepository>();
builder.Services.AddScoped<IMetaRepository, MetaRepository>();
builder.Services.AddScoped<IConquistaRepository, ConquistaRepository>();
builder.Services.AddScoped<IRecomendacaoRepository, RecomendacaoRepository>();
builder.Services.AddScoped<IRepository<Usuario>,  UsuarioRepository>();

// Registrar os serviços necessários
builder.Services.AddScoped<IService<Aparelho>, AparelhoService>();
builder.Services.AddScoped<IService<Usuario>, UsuarioService>();
builder.Services.AddScoped<IBandeiraTarifariaService, BandeiraTarifariaService>();
builder.Services.AddScoped<IService<Meta>, MetaService>();
builder.Services.AddScoped<IService<RegistroConsumo>, RegistroConsumoService>();
builder.Services.AddScoped<IService<Notificacao>, NotificacaoService>();
builder.Services.AddScoped<IService<Conquista>, ConquistaService>();
builder.Services.AddScoped<IRecomendacaoService, RecomendacaoService>();

// Configurar Swagger usando settings do appsettings.json
var swaggerSettings = builder.Configuration.GetSection("SwaggerSettings");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(swaggerSettings["Version"] ?? "v1", new OpenApiInfo
    {
        Title = swaggerSettings["Title"] ?? "ProspEco API",
        Version = swaggerSettings["Version"] ?? "v1",
        Description = swaggerSettings["Description"] ?? "Documentação da API para o sistema ProspEco"
    });
});

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

// Configuração de Swagger para todas as configurações (produção e desenvolvimento)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint(swaggerSettings["Endpoint"] ?? "/swagger/v1/swagger.json", swaggerSettings["Title"] ?? "ProspEco API");
    c.RoutePrefix = string.Empty; // Torna o Swagger acessível na raiz
});

// Redirecionar a rota raiz para o Swagger
app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

// Configuração da rota padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Iniciar o aplicativo
app.Run();