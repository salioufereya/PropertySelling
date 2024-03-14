using Data;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Data.Repo;
using WebApi.Interfaces;
using WebApi.Helpers;
using WebApi.Extensions;
using WebApi.Middleware;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#pragma warning disable CS8604 // Existence possible d'un argument de référence null.
builder.Services.AddDbContext<DataContext>(options=>options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork,unitOfWork>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKeyResolver = (string token, SecurityToken securityToken, string kid, TokenValidationParameters validationParameters) =>
            {
                var secretKey = Encoding.UTF8.GetBytes("shhh.. this is my top secret secret secret");
                var key = new SymmetricSecurityKey(secretKey);
                return new List<SecurityKey> { key };
            }
        };
    });
// Activer le middleware d'exception


#pragma warning restore CS8604 // Existence possible d'un argument de référence null.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();









var app = builder.Build();
app.MapControllers();
//app.UseAuthentication();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options=>{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});



app.ConfigureExceptionHandler(app.Environment);




app.Run();


