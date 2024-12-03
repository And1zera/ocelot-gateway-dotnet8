using ocelot_writer_dotnet8.Repository;
using ocelot_writer_dotnet8.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IWriterRepository, WriterRepository>();

Console.WriteLine($"Iniciando aplica��o...");
Console.WriteLine($"Nome da aplica��o: {AppDomain.CurrentDomain.FriendlyName}");
Console.WriteLine($"Configura��o AppSettings: {builder.Environment.EnvironmentName}");

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
