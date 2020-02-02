using PdfDocs.Api.Models;
using PdfDocs.Api.Transformers;
using PdfDocs.Domain;
using PdfDocs.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    StatusCode(StatusCodes.Status400BadRequest, response.ValidationError);
            }
            catch(Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{location:guid}/delete")]
        public async Task<ActionResult<object>> Delete([FromRoute]Guid location)
        {
           
            try
            {
                var result = await _pdfFileRepository.DeletePdfFile(location);
                return (result) ? StatusCode(StatusCodes.Status200OK, "") :
                    StatusCode(StatusCodes.Status400BadRequest, "File not found");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPatch]
        [Route("rearrange")]
        public async Task<ActionResult<object>> Rearrange([FromBody]FileListDto fileList)
        {
            try
            {
                var locations = from pdfFile in fileList.PdfFiles
                           select pdfFile.Location;

            await _pdfFileRepository.RearrangePdfFileList(locations);

                return StatusCode(StatusCodes.Status200OK,"");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



    }
}
