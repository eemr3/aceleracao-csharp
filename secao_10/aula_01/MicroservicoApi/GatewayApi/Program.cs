using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//adicionando o arquivo ocelot.json ao projeto
builder.Configuration.AddJsonFile("ocelot.json");

//adicionando o conteúdo do arquivo às configurações do Ocelot
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

//espera até a inicialização do Ocelot
await app.UseOcelot();

app.Run();
