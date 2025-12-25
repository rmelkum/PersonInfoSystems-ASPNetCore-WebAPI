using Microsoft.EntityFrameworkCore;
using PersonInfoSystems.Contexts;
using PersonInfoSystems.Models;
using PersonInfoSystems.Repositories;
using PersonInfoSystems.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PersonInfoSystemsDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<ICRUDRepository<CountryEntity>, CountryRepository>();
builder.Services.AddScoped<ICRUDRepository<CityEntity>, CityRepository>();
builder.Services.AddScoped<ICRUDRepository<AddressEntity>, AddressRepository>();
builder.Services.AddScoped<ICRUDRepository<PersonEntity>, PersonRepository>();
builder.Services.AddScoped<PersonAddressRepository>();

builder.Services.AddScoped<ICRUDService<AddressEntity>, AddressService>();
builder.Services.AddScoped<ICRUDService<CityEntity>, CityService>();
builder.Services.AddScoped<ICRUDService<CountryEntity>, CountryService>();
builder.Services.AddScoped<ICRUDService<PersonEntity>, PersonService>();
builder.Services.AddScoped<PersonAddressService>();




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.MapControllers();
app.Run();



