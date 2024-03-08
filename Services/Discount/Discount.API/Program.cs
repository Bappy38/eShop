using Discount.API.Extensions;
using Discount.Application.Extensions;
using Discount.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPresentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MigrateDatabase<Program>();
}

app.UseHttpsRedirection();

app.Run();