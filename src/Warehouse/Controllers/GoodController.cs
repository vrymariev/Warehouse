using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
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
            return await _goodService.ListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Add(GoodEntity goodEntity)
        {
            return Ok(await _goodService.AddAsync(goodEntity));
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
