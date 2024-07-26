using Exo.WebApi.Contexts;
using Exo.WebApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura o DbContext com SQL Server
builder.Services.AddDbContext<ExoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona serviços de controllers
builder.Services.AddControllers();

// Configura o repositório
builder.Services.AddTransient<ProjetoRepository>();

var app = builder.Build();

// Configure o pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Usando rotas de nível superior
app.MapControllers();

app.Run();
