using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Console.WriteLine($"Iniciando aplicação...");
Console.WriteLine($"Nome da aplicação: {AppDomain.CurrentDomain.FriendlyName}");
Console.WriteLine($"Configuração AppSettings: {builder.Environment.EnvironmentName}");


// Adiciona o arquivo de configuração "ocelot.json" ao objeto de configuração do aplicativo.
// O parâmetro 'optional: false' indica que o arquivo é obrigatório.
// O parâmetro 'reloadOnChange: true' permite que o aplicativo recarregue as configurações se o arquivo for alterado.
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Adiciona os serviços do Ocelot ao contêiner de serviços do aplicativo, utilizando as configurações definidas.
// Ocelot é uma biblioteca de API Gateway para .NET.
builder.Services.AddOcelot(builder.Configuration)
    // Adiciona o CacheManager ao Ocelot, que é usado para gerenciar o cache.
    // O método 'WithDictionaryHandle' configura o CacheManager para usar um dicionário em memória como armazenamento de cache.
    .AddCacheManager(x =>
    {
        x.WithDictionaryHandle();
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

await app.UseOcelot();

app.Run();
