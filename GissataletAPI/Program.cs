using Microsoft.Extensions.Options;
using MongoDB.Driver;
using User_Information_API.Models;
using User_Information_API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<UserDbSettings>(builder.Configuration.GetSection(nameof(UserDbSettings)));
builder.Services.AddSingleton<IUserDbSettings>(ud =>ud.GetRequiredService<IOptions<UserDbSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s =>new MongoClient(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
