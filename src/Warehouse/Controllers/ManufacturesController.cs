using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Controllers
{
    [Route("manufactures")]
    [ApiController]
    public class ManufacturesController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturesController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _manufacturerService.GetAsync(id);
            if (model == null)
            {
                NotFound();
            }
            return Ok(model);
        }

        [HttpGet]
        public async Task<List<ManufacturerEntity>> List()
        {
            return await _manufacturerService.ListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ManufacturerEntity manufacturerEntity)
        {
            await _manufacturerService.AddAsync(manufacturerEntity);
            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(ManufacturerEntity manufacturerEntity)
        {
            await _manufacturerService.UpdateAsync(manufacturerEntity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _manufacturerService.DeleteAsync(id);
            return Ok();
        }
    }
}
