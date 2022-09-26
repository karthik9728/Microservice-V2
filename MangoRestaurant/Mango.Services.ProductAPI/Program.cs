using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Mapping;
using Mango.Services.ProductAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

#region Database Configuration

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(connectionString));

#endregion

#region AutoMapper Configuration

builder.Services.AddAutoMapper(typeof(MappingProfile));

#endregion


#region Repository Configuration

builder.Services.AddScoped<IProductRepository, ProductRepository>();    

#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
