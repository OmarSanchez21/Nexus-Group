using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NexusGroup.Admin.Data;
using NexusGroup.Admin.Data.ApiServices;
using MudBlazor.Services;
using NexusGroup.Admin.Data.Token;
using NexusGroup.Admin.Data.ApiServices.Auth;
using NexusGroup.Admin.Data.ApiServices.Position;
using Blazored.LocalStorage;
using NexusGroup.Admin.Data.ApiServices.AccessLevels;
using NexusGroup.Admin.Data.ApiServices.Employees;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddHttpClient();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IAccessLevelsApiService, AccessLevelsApiService>();
builder.Services.AddScoped<IAuthApiService, AuthApiService>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<TokenHelper>();
builder.Services.AddScoped<IPositionApiService, PositionApiService>();
builder.Services.AddScoped<IEmployeesApiService, EmployeesApiService>();
builder.Services.AddMudServices();


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
