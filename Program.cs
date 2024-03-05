using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MyPersonalWebsite.Data;
using MudBlazor.Services;
using System.Configuration.Assemblies;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using MyPersonalWebsite.Models;
using MyPersonalWebsite.Services;

var builder = WebApplication.CreateBuilder(args);

//appsettings

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddMudServices();
builder.Services.AddSingleton(builder.Configuration.GetSection("MailSettings").Get<MailSettings>());
builder.Services.AddScoped<IMailService, MailService>();
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
