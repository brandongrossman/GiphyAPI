using GiphyAPI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<DataContext>();

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("policies",
                      policy =>
                      {
                          policy.WithOrigins("http://127.0.0.1:5500")
                            .AllowAnyMethod()
                            .AllowAnyHeader()                 
                            .AllowCredentials();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//CORS
app.UseCors("policies");

app.Use(async(request, next) =>
{
    request.Response.Headers["Access-Control-Allow-Origin"] = "http://127.0.0.1:5500";
  
    if (HttpMethods.IsOptions(request.Request.Method))
    {
        request.Response.Headers["Access-Control-Allow-Methods"] = "POST, GET, PUT, DELETE, OPTIONS";
        request.Response.Headers["Access-Control-Allow-Headers"] = "Content-Type";
        request.Response.Headers["Access-Control-Allow-Credentials"] = "true";
        await request.Response.CompleteAsync();
        return;
    }

    await next();
});

app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
