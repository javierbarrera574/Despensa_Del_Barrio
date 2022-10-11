using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Prueba.BD.Datos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AplicacionDbContext>(opciones => opciones.UseSqlServer(conn));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Despensa Barrial", Version = "v1" });
});




// Add services to the container.
//.NET3.1
//Instala la librería: Microsoft.AspNetCore.Mvc.NewtonsoftJson
//services.AddControllers().AddNewtonsoftJson(x =>
//    x.SerializerSettings.ReferenceLoopHandling =
//    Newtonsoft.Json.ReferenceLoopHandling.Ignore);
//.NET5
//services.AddControllersWithViews().AddJsonOptions(x =>
//    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
//.NET6

builder.Services.AddControllersWithViews()
                .AddJsonOptions(x => x.JsonSerializerOptions
                                      .ReferenceHandler = ReferenceHandler
                                      .IgnoreCycles);

builder.Services.AddRazorPages();



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
                                        "Despensa Barrial vFinal"));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();