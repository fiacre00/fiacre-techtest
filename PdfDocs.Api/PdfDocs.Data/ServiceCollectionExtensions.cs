using PdfDocs.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace PdfDocs.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services, string connection)
        {
            
            return services
                .AddScoped<IPdfFileRepository, PdfFileRepository>()
                .AddScoped<IPdfFileDb>(s=> new PdfFileDb(connection));
        }
    }
}
