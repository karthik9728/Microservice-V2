using Mango.Web;
using Mango.Web.Services;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//HttpClient Service
builder.Services.AddHttpClient<IProductService, ProductService>();
builder.Services.AddHttpClient<ICartService, CartService>();


#region SD Url

var connectionStringProductAPI = builder.Configuration["ServiceUrls:ProductAPI"];
var connectionStringIdenitytAPI = builder.Configuration["ServiceUrls:IdentityAPI"];
var connectionStringShoppingCartAPI = builder.Configuration["ServiceUrls:ShoppingCartAPI"];
//SD.ProductAPIBase = builder.Configuration["ServiceUrl:ProductAPI"];
SD.ProductAPIBase = connectionStringProductAPI;
SD.ShoppingCartAPIBase = connectionStringShoppingCartAPI;

#endregion

#region DI Service

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();

#endregion

#region 

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";

}).AddCookie("Cookies", x => x.ExpireTimeSpan = TimeSpan.FromMinutes(10))
  .AddOpenIdConnect("oidc", options =>
  {
      options.Authority = connectionStringIdenitytAPI;
      options.GetClaimsFromUserInfoEndpoint = true;
      options.ClientId = "mango";
      options.ClientSecret = "secret";
      options.ResponseType = "code";
      options.ClaimActions.MapJsonKey("role", "role", "role");
      options.ClaimActions.MapJsonKey("sub", "sub", "sub");
      options.TokenValidationParameters.NameClaimType = "name";
      options.TokenValidationParameters.RoleClaimType = "role";
      options.Scope.Add("mango");
      options.SaveTokens = true;
  });

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
