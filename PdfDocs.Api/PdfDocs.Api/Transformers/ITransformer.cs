using System.Collections.Generic;

namespace PdfDocs.Api.Transformers
{
    public interface ITransformer<TSource, TDestination>
    {
        TDestination Transform(TSource source);
    }

    public interface IEnumerableTransformer<TSource, TDestination> :
        ITransformer<TSource, TDestination>
    {
        IEnumerable<TDestination> Transform(IEnumerable<TSource> sources);
    }
}
