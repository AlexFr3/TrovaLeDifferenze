using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DbTrovaLeDifferenze>(options =>options.UseSqlite(builder.Configuration.GetConnectionString("DbTrovaLeDifferenzeContext")));

builder.Services.AddCors(options => {
    options.AddPolicy("MyPolicy", builder => {
        builder.WithOrigins("*")
        .AllowAnyHeader()
        .AllowAnyMethod(); 
    });
});



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
