using ocelot_article_dotnet8.Repository;
using ocelot_article_dotnet8.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IArticleRepository, ArticleRepository>();

Console.WriteLine($"Iniciando aplicação...");
Console.WriteLine($"Nome da aplicação: {AppDomain.CurrentDomain.FriendlyName}");
Console.WriteLine($"Configuração AppSettings: {builder.Environment.EnvironmentName}");

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
