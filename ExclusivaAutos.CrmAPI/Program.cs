using ExclusivaAutos.Application;
using ExclusivaAutos.Domain;
using ExclusivaAutos.Infrastructure;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen; // 👈 Este using es clave
using Swashbuckle.AspNetCore.SwaggerUI; // 👈 Opcional, pero bueno tenerlo

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Learn more: https://aka.ms/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // 👈 Esto requiere Swashbuckle

// Configuración OAuth
builder.Services.Configure<OAuthSettings>(builder.Configuration.GetSection(OAuthSettings.SectionName));

// HttpClient con timeout y base address
builder.Services.AddHttpClient<IExternalCustomerClient, ExternalCustomerClient>(client =>
{
    client.BaseAddress = new Uri("https://powerautomate.ejerciciosenior.prueba.api.powerplatform.com:100/");
    client.Timeout = TimeSpan.FromSeconds(30);
});

// Servicios de aplicación
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // 👈 Requiere Swashbuckle
    app.UseSwaggerUI(); // 👈 Requiere Swashbuckle
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();