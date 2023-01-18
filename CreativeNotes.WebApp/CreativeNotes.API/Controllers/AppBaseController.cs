using CreativeNotes.Common;
using CreativeNotes.Common.Dtos;
using CreativeNotes.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CreativeNotes.API.Controllers
{
    [ApiController]
    public abstract class AppBaseController : ControllerBase
    {
        private readonly ILogger _logger;

        protected AppBaseController(ILogger logger)
        {
            _logger = logger;
        }

        protected async Task<IActionResult> HandleAsync<TResult>(Func<Task<TResult>> resultFunc)
        {
            try
            {
                var result = await resultFunc();
                return Ok(new ResponseDto<TResult> { Succeeded = true, Result = result });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new ResponseDto<object> { ErrorMessage = ex.Message, Succeeded = false });
            }
            catch (Exception ex)
            {
                return GeneralExceptionResult(ex);
            }
        }

        protected async Task<IActionResult> HandleAsync(Func<Task> resultFunc)
        {
            try
            {
                await resultFunc();
                return Ok(new ResponseDto<object> { Succeeded = true });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new ResponseDto<object> { ErrorMessage = ex.Message, Succeeded = false });
            }
            catch (Exception ex)
            {
                return GeneralExceptionResult(ex);
            }
        }

        private IActionResult GeneralExceptionResult(Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, ErrorMessages.GenericError);
        }     
    }
}
  
