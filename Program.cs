using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using LP3.Data;
using LP3.Data.Context;
using LP3.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSqlite<LP3DbContext>("Data Source=.//Data//Context//localDB.db");
builder.Services.AddScoped<ILP3DbContext,LP3DbContext>();
builder.Services.AddScoped<IProductoService,ProductoService>();
builder.Services.AddSingleton<WeatherForecastService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LP3DbContext>();
    if (db.Database.EnsureCreated())
    {
        
    }
}

app.Run();
