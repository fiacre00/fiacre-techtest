using PdfDocs.Api.Models;
using PdfDocs.Api.Transformers;
using PdfDocs.Domain;
using PdfDocs.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;


namespace PdfDocs.Api.Controllers
{
    [Route("api/v1/commands")]
    public class CommandsController : ControllerBase
    {
        private readonly IPdfFileTransformerService _pdfTransformerService;
        private readonly IPdfFileRepository _pdfFileRepository;
        private readonly IDecodeValidateService _decodeValidateService;

       
        public CommandsController(
             IPdfFileTransformerService pdfFileTransformerService,
             IPdfFileRepository pdfFileRepository,
             IDecodeValidateService decodeValidateService)
        {
            _pdfTransformerService = pdfFileTransformerService ?? throw new ArgumentNullException(nameof(pdfFileTransformerService));
            _pdfFileRepository = pdfFileRepository ?? throw new ArgumentNullException(nameof(pdfFileRepository));
            _decodeValidateService = decodeValidateService ?? throw new ArgumentNullException(nameof(decodeValidateService));

        }

        [HttpPost]
        [Route("upload")]
        public async Task<ActionResult<object>> Upload([FromBody]PdfFileDto pdfFile)
        {
            //TODO validation service
            try
            {
                var response = _decodeValidateService.DecodeValidate(pdfFile.FileContent);
                if(response.IsValidPdf)
                {
                    await _pdfFileRepository.UploadPdfFile(pdfFile.FileName, response.Decoded);
                }
                           
                return (response.IsValidPdf) ? StatusCode(StatusCodes.Status201Created,""): 
                    StatusCode(StatusCodes.Status406NotAcceptable,response.ValidationError);
            }
            catch(Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{location:guid}/delete")]
        public async Task<int> Delete([FromRoute]Guid location)
        {
            return StatusCodes.Status200OK;
        }

        [HttpPatch]
        [Route("rearrange")]
        public async Task<int> Rearrange([FromBody]FileListDto fileList)
        {
            return StatusCodes.Status200OK;
        }



    }
}
