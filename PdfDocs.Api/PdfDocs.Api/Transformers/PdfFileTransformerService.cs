using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PdfDocs.Api.Models;
using PdfDocs.Domain.Entities;

namespace PdfDocs.Api.Transformers
{
    #region Interface

    public interface IPdfFileTransformerService
    {
        PdfFileDto Transform(PdfFile source);
    }

    #endregion
    public class PdfFileTransformerService: IPdfFileTransformerService
    {
        private readonly ITransformer<PdfFile, PdfFileDto> _pdfFileTransformer;

        public PdfFileTransformerService(ITransformer<PdfFile, PdfFileDto> pdfTransformer)
        {
            _pdfFileTransformer = pdfTransformer ?? throw new ArgumentNullException(nameof(pdfTransformer));
        }

        public PdfFileDto Transform(PdfFile source)
        {
            return _pdfFileTransformer.Transform(source);
        }

    }
}
