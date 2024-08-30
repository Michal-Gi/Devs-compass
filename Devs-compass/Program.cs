using Devs_compass.DBConnection;
using Devs_compass.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:3000") // Allow requests from this origin
                          .AllowAnyHeader() 
                          .AllowAnyMethod());
});

builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<GameJamService>();
builder.Services.AddTransient<GroupService>();
builder.Services.AddTransient<TagService>();
builder.Services.AddTransient<SoftwareService>();
builder.Services.AddTransient<OpinionService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiDbContext>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
