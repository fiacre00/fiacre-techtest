using PdfDocs.Api.Models;
using PdfDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdfDocs.Api.Transformers
{
    #region Interface

    public interface IFileListTransformerService
    {
        FileListDto Transform(FileList source);
    }

    #endregion
    public class FileListTransformerService : IFileListTransformerService
    {
        private readonly ITransformer<FileList, FileListDto> _fileListTransformer;

        public FileListTransformerService(ITransformer<FileList, FileListDto> fileListTransformer)
        {
            _fileListTransformer = fileListTransformer ?? throw new ArgumentNullException(nameof(fileListTransformer));
        }

        public FileListDto Transform(FileList source)
        {
            return _fileListTransformer.Transform(source);
        }
    }
}
