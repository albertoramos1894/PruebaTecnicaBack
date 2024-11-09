using Api.Core.Dtos;
using Api.Core.Interfaces;
using Api.Data.Models;
using Api.Services.Modulos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<AgenciaVuelosContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyeccion de dependencias
builder.Services.AddTransient<IVuelosServices, VuelosServices>();
builder.Services.AddTransient<IItinerarioServices, ItinerarioServices>();
builder.Services.AddTransient<ICatalogosServices, CatalogoServices>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMappingProfile));

//Configuracion CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        policy => policy.WithOrigins("http://localhost:4307")
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
