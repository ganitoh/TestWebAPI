using Microsoft.AspNetCore.Authentication.Cookies;
using TestWebAPI.Persistance.Implementation;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSQLiteRepository(builder.Configuration["Data:ConnectionString:SQLite"]);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
    AddCookie(options => options.LoginPath = "/login");
builder.Services.AddAuthorization();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseStatusCodePages();
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapGet("/login", async context =>
{
    context.Response.ContentType = "text/html; charset=utf-8";

    await context.Response.SendFileAsync("/html/login.html");
});



app.Map("/",() => "Hello World");

app.Run();
