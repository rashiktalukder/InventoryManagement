using InventoryManagement.API.Models;
using InventoryManagement.API.Repositories.Interface;
using InventoryManagement.API.Repositories.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseRepository warehouseRepository;

        public WarehouseController(IWarehouseRepository warehouseRepository)
        {
            this.warehouseRepository = warehouseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var warehouses = await warehouseRepository.GetAllAsync();
            return Ok(warehouses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var warehouse = await warehouseRepository.GetByIdAsync(id);
            return Ok(warehouse);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Warehouse warehouse)
        {
            await warehouseRepository.AddAsync(warehouse);
            return Ok(warehouse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Warehouse warehouse)
        {
            if (id != warehouse.Id)
            {
                return BadRequest();
            }
            await warehouseRepository.UpdateAsync(warehouse);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await warehouseRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
