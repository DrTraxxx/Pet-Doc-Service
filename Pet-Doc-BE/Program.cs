using Pet_Doc_BE.Endpoints;
using Pet_Doc_BE_Application;
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

app.MapDoctorEndpoints();

app.Run();
