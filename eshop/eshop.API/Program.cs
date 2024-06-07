using eshop.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddNecessariesForApp(connectionString);
builder.Services.AddCors(option => option.AddPolicy("allow", builder =>
{
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.AllowAnyOrigin();
    /*
     * http://www.isbank.com.tr/
     * https://www.isbank.com.tr
     * https://customers.isbank.com.tr
     * https://www.isbank.com.tr:8585
     * 
     * 
     */
}));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option => option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = "api.softtech",

                    ValidateAudience = true,
                    ValidAudience = "client.softtech",

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu-cumle-kritik-bir-cumledir-ona-gore"))

                }); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("allow");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
