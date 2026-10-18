using BlazorApp1.Components;
using BlazorApp1.servicios;
using BlazorApp1.modelos;

var builder = WebApplication.CreateBuilder(args);

// Agregar los servicios base de Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// AQUÍ REGISTRAMOS TU SERVICIO DE INVENTARIO (Siempre antes del Build)
builder.Services.AddSingleton<InventarioService>();

var app = builder.Build();

// Configuración del entorno web
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

// Manejo de archivos estáticos (CSS, imágenes)
app.MapStaticAssets(); 

// Mapeo de la aplicación
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run(); 