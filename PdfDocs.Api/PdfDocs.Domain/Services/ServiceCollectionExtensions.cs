using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PdfDocs.Domain.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            return services
                .AddSingleton<IDecodeValidateService, DecodeValidateService>();
        }
    }
}
