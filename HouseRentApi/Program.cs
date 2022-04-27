using System.Text;
using HouseRentApi.DbContext;
using HouseRentApi.Models.Repository;
using HouseRentApi.Models.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "RealEstate API",
        Description = ".NET Core Web API for managing RealEstate Agency",
    });
    var XMLPath = AppDomain.CurrentDomain.BaseDirectory + nameof(HouseRentApi) + ".xml";
    if (File.Exists(XMLPath))
    {
        options.IncludeXmlComments(XMLPath);
    }
});

var connectionString = "workstation id=realestatespain.mssql.somee.com;packet size=4096;user id=habcerga3_SQLLogin_1;pwd=2o1rdonipd;data source=realestatespain.mssql.somee.com;persist security info=False;initial catalog=realestatespain";

builder.Services.AddDbContext<AppDbContext>(o 
    => o.UseSqlServer(connectionString));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.
        AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.
        AuthenticationScheme;
    o.DefaultScheme = JwtBearerDefaults.
        AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


builder.Services.AddAuthorization();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();