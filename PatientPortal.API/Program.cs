using Microsoft.EntityFrameworkCore;
using PatientPortal.API.Repositories;
using PatientPortal.API.Services;
using SharedModels.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>(); 


// Load configuration from appsettings.json
IConfiguration configuration = builder.Configuration;

// Configure services using configuration
builder.Services.AddDbContext<PatientsContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("PatientPortalContext"));
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
