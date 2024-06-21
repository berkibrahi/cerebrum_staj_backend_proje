using Contracts;
using Service;
using Entities.Models;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using ServiceContracts;

namespace WebMenagement_2.Extensions
{
	public static class SeviceExtensions
	{
		public static void ConfigureCors(this IServiceCollection services)
		{
			services.AddCors(options =>
			options.AddPolicy("CorsPolicy",builder =>
			builder.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader()
			)
			);

		}
		public static void ConfigureLoggerManager(this IServiceCollection services)
		{
			services.AddSingleton<ILoggerMenager, LoggerManager>();
		}
		public static void ConfigureSqlServer(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddDbContext<RepositoryContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("SqlConnection"),
			project=>project.MigrationsAssembly("WebMenagement_2"))
				);
				
		}
		public static void ConfigureRepositoryManager(this IServiceCollection services)
		{
			services.AddScoped<IRepositorMenager, RepositoryMenagercs>();
		}
		public static void ConfigureServiceManager(this IServiceCollection services)
		{
			services.AddScoped<IServiceManager, ServiceManager>();
		}
	}
}
