using IncomeTaxCalculator.Api;

namespace IncomeTaxCalculator
{
	public static class Names 
	{
		public const string CORS_POLICY = "AllowAllHeaders";
	}

	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddCors(options =>
			{
				options.AddPolicy(Names.CORS_POLICY,
					builder =>
					{
						builder
							.AllowAnyOrigin()
							.AllowAnyHeader()
							.AllowAnyMethod();
					});
			});
			builder.Services.AddControllers();
			builder.Services.AddSingleton<ITaxBands, TaxBands_UK>();
			builder.Services.AddSingleton<ITaxCalculator, TaxCalculator>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.

			app.UseAuthorization();
			app.UseCors(Names.CORS_POLICY);

			app.MapControllers();

			app.Run();
		}
	}
}
