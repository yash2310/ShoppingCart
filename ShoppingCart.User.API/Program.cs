using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart.Application.Authentication;
using ShoppingCart.Application.Interfaces.Repositories;
using ShoppingCart.Application.Interfaces.Services;
using ShoppingCart.Application.Services;
using ShoppingCart.User.Infra.Data;
using ShoppingCart.User.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();

#region JWT Authentication

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = JwtHandler.GetValidationParameter(configuration);
    });

#endregion

#region DB Context

builder.Services.AddDbContext<AppDbContext>(option =>
{
    ILogger logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();
    try
    {
        option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }
    catch(Exception ex)
    {
        logger.LogInformation("Program File - Connection string : " + configuration.GetConnectionString("DefaultConnection"));
        logger.LogInformation("Options value : " + option);

        logger.LogInformation(ex.Message);
    }
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
