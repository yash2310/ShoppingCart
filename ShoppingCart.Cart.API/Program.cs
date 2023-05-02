using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Application.Authentication;
using ShoppingCart.Application.Interfaces.Repositories;
using ShoppingCart.Application.Interfaces.Services;
using ShoppingCart.Application.Services;
using ShoppingCart.Cart.Infra.Data;
using ShoppingCart.Cart.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#region Data service

builder.Services.AddScoped(typeof(ICartRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ITokenService, TokenService>();

#endregion

#region JWT Authentication

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken= true;
        options.TokenValidationParameters = JwtHandler.GetValidationParameter(configuration);
    });

#endregion

#region DB Context

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
