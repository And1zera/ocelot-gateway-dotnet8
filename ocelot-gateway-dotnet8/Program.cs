using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Console.WriteLine($"Iniciando aplica��o...");
Console.WriteLine($"Nome da aplica��o: {AppDomain.CurrentDomain.FriendlyName}");
Console.WriteLine($"Configura��o AppSettings: {builder.Environment.EnvironmentName}");


// Adiciona o arquivo de configura��o "ocelot.json" ao objeto de configura��o do aplicativo.
// O par�metro 'optional: false' indica que o arquivo � obrigat�rio.
// O par�metro 'reloadOnChange: true' permite que o aplicativo recarregue as configura��es se o arquivo for alterado.
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Adiciona os servi�os do Ocelot ao cont�iner de servi�os do aplicativo, utilizando as configura��es definidas.
// Ocelot � uma biblioteca de API Gateway para .NET.
builder.Services.AddOcelot(builder.Configuration)
    // Adiciona o CacheManager ao Ocelot, que � usado para gerenciar o cache.
    // O m�todo 'WithDictionaryHandle' configura o CacheManager para usar um dicion�rio em mem�ria como armazenamento de cache.
    .AddCacheManager(x =>
    {
        x.WithDictionaryHandle();
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

await app.UseOcelot();

app.Run();
