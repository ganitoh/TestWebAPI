using TestWebAPI.Persistance.Implementation;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSQLiteRepository(builder.Configuration["Data:ConnectionString:SQLite"]);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseStatusCodePages();
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.Map("/reg", appBuilder => 
{
    appBuilder.MapWhen(context => context.Request.Method == "POST", async appB =>
    {
        appB.Run(async context =>
        {
            var response = context.Response;
            var request = context.Request;

            var form = request.Form;

            if (!form.ContainsKey("login") || !form.ContainsKey("password") ||  !form.ContainsKey("passwordRepeat"))
            {
                response.StatusCode = 400;
                await response.WriteAsJsonAsync(new { mwssage = "некорректные данные" });
            }
            else if (form["password"] != form["passwordRepeat"])
            {
                response.StatusCode = 400;
                await response.WriteAsJsonAsync(new { mwssage = "пароли не совпадают" });
            }


            var repository = app.Services.GetService<ApplicationContext>();




        });
    });

    appBuilder.MapWhen(context => context.Request.Method == "GET", async appB =>
    {
        appB.Run(async context =>
        {
            var response = context.Response;

            response.StatusCode = 200;
            response.ContentType = "text/html; charset=utf-8";

            await response.SendFileAsync("html/registration.html");
        });
    });
});


app.Run(async context =>
{
    context.Response.ContentType = "text/html";

    await context.Response.WriteAsync("main page");
});


app.Run();