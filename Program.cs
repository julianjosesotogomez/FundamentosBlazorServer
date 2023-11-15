using FundamentosBlazorServer.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;


/*
 * Trace: Informaci�n detallada y especifica, util para depuraci�n intensiva. 
   Debug: Informaci�n de depuraci�n que puede ser �til durante el desarrollo. 
   Information: Mensajes informativos sobre el funcionamiento normal de la aplicaci�n. 
   Warning: Advertencias sobre situaciones que podrian llevar a problemas en el futuro.
   Error: Errores no cr�ticos que no impiden el funcionamiento normal de la aplicaci�n.
 * Critical: Errores cr�ticos que pueden provocar la interrupci�n de la aplicaci�n. 
 */

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Inyecci�n de dependencias 
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<WeatherForecastService>();

// Agregar inyeccion de dependencias 

// .AddSingleton -> crea una unica instancia
//builder.Services.AddSingleton<IDatosDemo, DatosDemo>();
// .AddScoped -> crea una instancia para cada sesi�n
//builder.Services.AddScoped<IDatosDemo, DatosDemo>();
// .AddTransient -> siempre se genera una instancia nueva
builder.Services.AddTransient<IDatosDemo, DatosDemo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Manejo de errores y excepciones
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Redireccionamiento de las solicitudes Http a Https (seguridad)
app.UseHttpsRedirection();

// Habilita el servidor para archivo estaticos
app.UseStaticFiles();

// Responsable de la comunicaci�n de los componenetes 
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
