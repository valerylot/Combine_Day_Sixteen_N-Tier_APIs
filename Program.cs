using Combine_Day_Sixteen_N_Tier_APIs.Data;
using Combine_Day_Sixteen_N_Tier_APIs.Repositories;
using Combine_Day_Sixteen_N_Tier_APIs.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//registering our AppDbContext with our dependency injection -> we use SQLite -> we're letting ef core know we are using SQLite -> 
//Getting our connection string location -> and that tells ef core where our database is
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//whenever anyone asks for an ISupplyRepository, give them SupplyRepository
builder.Services.AddScoped<ISupplyRepository, SupplyRepository>();

//whenever anyone asks for an ISupplyService, give them SupplyService
builder.Services.AddScoped<ISupplyService, SupplyService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
