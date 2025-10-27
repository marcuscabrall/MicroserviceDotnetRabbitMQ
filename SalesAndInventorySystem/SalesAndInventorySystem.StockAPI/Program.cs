using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesAndInventorySystem.InventoryAPI.Config;
using SalesAndInventorySystem.InventoryAPI.Model.Context;
using SalesAndInventorySystem.InventoryAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Início - Postgres
builder.Services.AddDbContext<PostgresContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnectionString")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Fim - Postgres

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
