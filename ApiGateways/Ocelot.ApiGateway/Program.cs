var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

builder.Configuration.AddJsonFile($"ocelot.{app.Environment.EnvironmentName}.json", true, true);

app.UseHttpsRedirection();
app.UseRouting();

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Hello Ocelot");
});


app.Run();