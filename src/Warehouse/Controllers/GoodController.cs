using System.Collections.Generic;
using System.Threading.Tasks;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services;

namespace Warehouse.Controllers
{
    [Route("goods")]
    [ApiController]
    public class GoodController : ControllerBase
    {
        private readonly IGoodService _goodService;

        public GoodController(IGoodService goodService) 
        {
            _goodService = goodService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _goodService.GetAsync(id);
            if (model == null)
            {
                NotFound();
            }
            return Ok(model);
        }

        [HttpGet]
        public async Task<List<GoodEntity>> List()
        {
            var result = await _goodService.ListAsync();
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Add(GoodEntity goodEntity)
        {
            await _goodService.AddAsync(goodEntity);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(GoodEntity goodEntity)
        {
            await _goodService.UpdateAsync(goodEntity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _goodService.DeleteAsync(id);
            return Ok();
        }
    }
}
