using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VSM.Application.Models.Request;
using VSM.Application.Services.Interfaces;

namespace VSMVsMISL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VsmController : ControllerBase
    {
        private readonly IVsmServices _vsmServices;
        public VsmController(IVsmServices vsmServices)
        {
            _vsmServices = vsmServices;
        }
        [HttpGet("GenerateToken")]
        public async Task<IActionResult> GenerateToken()
        {
            try
            {
                var encryptedData = await _vsmServices.GenerateToken();
                return Ok(encryptedData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("GetSequenceData")]
        public async Task<IActionResult> GetSequenceData([FromQuery] SequenceDataRequest request)
        {
            try
            {
                var SequenceData = await _vsmServices.GetSequenceData(request);
                return Ok(SequenceData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
