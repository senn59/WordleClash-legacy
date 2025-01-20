using Lib.AspNetCore.ServerSentEvents;
using WordleClash.Core.Interfaces;
using WordleClash.Core.Services;
using WordleClash.Data;
using WordleClash.Web.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddServerSentEvents();

builder.Services.AddScoped<IWordRepository, WordRepository>();
builder.Services.AddScoped<GameService>();
builder.Services.AddScoped<LobbyService>();

builder.Services.AddTransient<SessionManager>();
builder.Services.AddTransient<ServerEvents>();

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

app.UseAuthorization();

app.UseSession();
app.UseMiddleware<LobbyMiddleware>();
app.UseMiddleware<GameMiddleware>();

app.MapServerSentEvents("/updates");
app.MapRazorPages();

app.Run();