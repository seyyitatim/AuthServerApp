using AuthServer.Shared.Configurations;
using AuthServer.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<CustomTokenOption>();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCustomTokenAuth(tokenOptions);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
