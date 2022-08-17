using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
//using ProjectRoseOfSharon.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSingleton<ProjectRoseOfSharon.Business.TerrainConfig>();
builder.Services.AddSingleton<ProjectRoseOfSharon.Business.Terrain>();
builder.Services.AddSingleton<ProjectRoseOfSharon.Business.CowConfig>();
builder.Services.AddSingleton<ProjectRoseOfSharon.Business.GoatConfig>();
builder.Services.AddSingleton<ProjectRoseOfSharon.Business.DesertConfig>();
builder.Services.AddSingleton<ProjectRoseOfSharon.Business.GrassConfig>();
builder.Services.AddSingleton<ProjectRoseOfSharon.Business.ForestConfig>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
