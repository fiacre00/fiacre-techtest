using PdfDocs.Api.Models;
using PdfDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdfDocs.Api.Transformers
{
    public class FileListTransformer:ITransformer<FileList, FileListDto>
    {
        private readonly ITransformer<PdfFile, PdfFileDto> _pdfFileTransformer;

        public FileListTransformer(ITransformer<PdfFile, PdfFileDto> pdfTransformer)
        {
            _pdfFileTransformer = pdfTransformer ?? throw new ArgumentNullException(nameof(pdfTransformer));
        }

        public FileListDto Transform(FileList source)
        {
            var pdfFilesDto = new List<PdfFileDto>();
            foreach(var pdfFile in source.PdfFiles)
            {
                pdfFilesDto.Add(_pdfFileTransformer.Transform(pdfFile));
            }

            return new FileListDto
            {
                PdfFiles = pdfFilesDto
            };

        }
    }
}
