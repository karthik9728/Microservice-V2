using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);


#region Authentication and Authorization

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    //Where the token is coming from? 
    options.Authority = "https://localhost:44395";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
    };

});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "mango");
    });
});

#endregion

#region Ocelot 

//builder.Services.AddOcelot();

#endregion

//Json Configure File for Ocelot API Gateway
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

//Ocelot Config
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

await app.UseOcelot();

//app.MapGet("/", () => "Hello World!");

app.Run();
