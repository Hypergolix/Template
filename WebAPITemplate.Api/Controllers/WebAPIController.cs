using Microsoft.AspNetCore.Mvc;
using WebAPITemplate.Api.Models;
using WebAPITemplate.Api.Services;

namespace WebAPITemplate.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class WebAPIController : ControllerBase
    {
        private readonly IWebAPIClient _client;

        public WebAPIController(IWebAPIClient client)
        {
            _client = client;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _client.Get();
            if (result is null) return BadRequest();
            return Ok(result);
        }

        [HttpGet("all/item")]
        public async Task<IActionResult> GetOne(int id)
        {
            var result = await _client.Get(id);
            if (result is null) return BadRequest();
            return Ok(result);
        }

        [HttpPost("all")]
        public async Task<IActionResult> Post(InputWebAPIClass model)
        {
            int newId;
            try
            {
                newId = await _client.Post(model);
            }   
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(newId);
        }

        [HttpDelete("all/item")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _client.Delete(id)) return BadRequest();
            return Ok();
        }

        [HttpPatch("all/item")]
        public async Task<IActionResult> Update(int id, InputWebAPIClass model)
        {
            if (!await _client.Update(id, model)) return BadRequest();
            return Ok();
        }
    }
}
