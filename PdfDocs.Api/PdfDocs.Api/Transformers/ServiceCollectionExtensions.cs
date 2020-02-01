using PdfDocs.Api.Models;
using PdfDocs.Domain;
using PdfDocs.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace PdfDocs.Api.Transformers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTransformers(this IServiceCollection services)
        {
            return services
                .AddSingleton<IPdfFileTransformerService, PdfFileTransformerService>()
                .AddSingleton<ITransformer<PdfFile, PdfFileDto>, PdfFileTransformer>()
                ;
        }
    }
}