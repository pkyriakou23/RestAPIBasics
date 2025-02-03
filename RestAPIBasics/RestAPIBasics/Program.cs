using Microsoft.EntityFrameworkCore;
using RestAPIBasics.Models;
using RestAPIBasics.Provider;
using RestAPIBasics.Provider.Implementation;
using RestAPIBasics.Service;
using RestAPIBasics.Service.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddScoped<INumbersService, NumbersServiceImpl>();
builder.Services.AddScoped<ICountryService, CountryServiceImpl>();
builder.Services.AddHttpClient<ICountryProvider, CountryProviderImpl>();
builder.Services.AddMemoryCache();
builder.Services.AddDbContext<CountryContext>(options =>
{
    options.UseSqlServer("Server=localhost;Database=CountriesDB;Trusted_Connection=True;TrustServerCertificate=True;");
});


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
