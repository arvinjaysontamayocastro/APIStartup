using System.Text;
using TodoApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TodoApp.Configuration;
using TodoApp.Data;
using TodoApp.Models;

var builder = WebApplication.CreateBuilder(args);

// var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:Secret"]);
// var tokenValidationParameters = new TokenValidationParameters
// {
//     ValidateIssuerSigningKey = true,
//     IssuerSigningKey = new SymmetricSecurityKey(key),
//     ValidateIssuer = false,
//     ValidateAudience = false,
//     ValidateLifetime = true,
//     RequireExpirationTime = false,
//     // Allow to use seconds for expiration of token
//     // Required only when token lifetime less than 5 minutes
//     // THIS ONE
//     ClockSkew = TimeSpan.Zero
// };
// builder.Services.AddSingleton(tokenValidationParameters);

// builder.Services
//     .AddAuthentication(options =>
//     {
//         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//         options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//     })
//     .AddJwtBearer(jwt =>
//     {
//         jwt.SaveToken = true;
//         jwt.TokenValidationParameters = tokenValidationParameters;
//     });

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// builder.Services.AddDbContext<ApiDbContext>(options =>
//                 options.UseSqlite(
//                     connectionString));


// Add services to the container.
builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("BookStoreDatabase")
);

builder.Services.AddSingleton<BooksService>();

// builder.Services.AddDbContext<EmployeeDbContext>(x => x.UseSqlServer(connectionString));

var jwtConfig = builder.Configuration.GetSection("JwtConfig");
builder.Services.Configure<JwtConfig>(jwtConfig);

// builder.Services
//     .AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//     .AddEntityFrameworkStores<ApiDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthentication();

// app.UseAuthorization();

app.MapControllers();

app.Run();
