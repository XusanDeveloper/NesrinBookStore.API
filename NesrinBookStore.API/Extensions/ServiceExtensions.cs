using NesrinBookStore.Services.Interfaces;
using NesrinBookStore.Services.Services;

namespace NesrinBookStore.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) =>
            builder.AddMvcOptions(config => config.OutputFormatters.Add(new CsvOutputFormatter()));

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();
    }
}
