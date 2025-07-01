using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Tournament.Api.Extensions;
using Tournament.Api.Mappings;
using Tournament.Core.Repositories;
using Tournament.Data.Data;
using Tournament.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TournamentDbContext>(options =>
//   options.UseInMemoryDatabase("TournamentDb"));

builder.Services.AddDbContext<TournamentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddScoped<IUoW, UoW>();
builder.Services.AddControllers()
    .AddNewtonsoftJson();
builder.Services.AddAutoMapper(typeof(TournamentMappings));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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

app.SeedData();

app.Run();
