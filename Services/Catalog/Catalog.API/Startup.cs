using Catalog.API.Extensions;
using Catalog.Application.Extensions;
using Catalog.Infrastructure.Extensions;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Catalog.API;

public class Startup
{
    private readonly IConfiguration configuration;

	public Startup(IConfiguration configuration)
	{
		this.configuration = configuration;
	}

	public void ConfigureServices(IServiceCollection services)
	{
		services
			.AddInfrastructure()
			.AddApplication()
			.AddPresentation(configuration);
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
			app.UseSwagger();
			app.UseSwaggerUI((cfg => cfg.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1")));
		}

		app.UseRouting();
		app.UseStaticFiles();
		app.UseAuthorization();
		app.UseEndpoints(endpoints =>
		{
			endpoints.MapControllers();
			endpoints.MapHealthChecks("/health", new HealthCheckOptions
			{
				Predicate = _ => true,
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
			});
		});
	}
}
