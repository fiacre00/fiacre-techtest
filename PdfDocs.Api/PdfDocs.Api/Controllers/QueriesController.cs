using PdfDocs.Api.Models;
using PdfDocs.Api.Transformers;
using PdfDocs.Domain;
using PdfDocs.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PdfDocs.Api.Controllers
{
    [Route("api/v1/queries")]
    public class QueriesController : ControllerBase
    {
       
        private readonly IPdfFileTransformerService _pdfTransformerService;
        private readonly IPdfFileRepository _pdfFileRepository;
        private readonly IFileListTransformerService _fileListTransformerService;

        public QueriesController(
             IPdfFileTransformerService pdfFileTransformerService,
             IPdfFileRepository pdfFileRepository,
             IFileListTransformerService fileListTransformerService)
        {
            
            _pdfTransformerService = pdfFileTransformerService ?? throw new ArgumentNullException(nameof(pdfFileTransformerService));
            _pdfFileRepository = pdfFileRepository ?? throw new ArgumentNullException(nameof(pdfFileRepository));
            _fileListTransformerService = fileListTransformerService ?? throw new ArgumentNullException(nameof(fileListTransformerService));
        }

        [HttpGet]
        [Route("filelist")]
        public async Task<ActionResult<FileListDto>> GetFileList()
        {
            try
            {
                var result = await _pdfFileRepository.GetPdfFileList();
                var fileListDto = _fileListTransformerService.Transform(result);
                return Ok(fileListDto);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{location:guid}/getfile")]
        public async Task<ActionResult<PdfFileDto>> GetFile([FromRoute]Guid location)
        {
            try
            {
                var result = await _pdfFileRepository.GetPdfFile(location);
                return Ok(_pdfTransformerService.Transform(result));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
