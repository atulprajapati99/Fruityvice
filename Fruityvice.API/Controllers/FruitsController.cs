using Fruityvice.API.Requests;
using Fruityvice.Services.Interface;
using Fruityvice.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fruityvice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        private readonly IFruitService _fruitService;
        public FruitsController(IFruitService fruitService)
        {
            _fruitService = fruitService;
        }

        [HttpGet("GetAllFruitsAsync")]
        [ProducesResponseType(typeof(IEnumerable<Fruit>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Fruit>>> GetAllFruitsAsync()
        {
            var fruits = await _fruitService.GetAllFruitsAsync();

            return Ok(fruits);
        }

        [HttpPost("GetFruitsByFamilyAsync")]
        [ProducesResponseType(typeof(IEnumerable<Fruit>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Fruit>>> GetFruitsByFamilyAsync([FromBody] FruiteRequest fruiteRequest)
        {
            var fruits = await _fruitService.GetFruitsByFamilyAsync(fruiteRequest.FruiteFamily);

            if (fruits is null)
                return NotFound();

            return Ok(fruits);
        }
    }
}
