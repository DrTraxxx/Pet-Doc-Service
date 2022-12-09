using Pet_Doc_BE_Application;
using Pet_Doc_BE_Application.Contracts;
using Pet_Doc_BE_Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddDomain()
    .AddInfrasctructure(builder.Configuration)
    .AddApplicationComponents(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using var scope = app.Services.CreateScope();
var initializer = scope.ServiceProvider.GetRequiredService<IInitializer>();
initializer.Initialize();

app.MapGet("/docs", async (string city,string speciality,IDoctorFeature doctorFeature) 
    => await doctorFeature.FindDoctors(city,speciality));

app.MapGet("/doc/{name}",async (string name,IDoctorFeature doctorFeature) 
    => await doctorFeature.GetDoctorDetails(name));

app.MapGet("doc/{name}/schadule", async (string name, IDoctorFeature doctorFeature)
    => await doctorFeature.GetDoctorAppointments(name));

app.Run();
