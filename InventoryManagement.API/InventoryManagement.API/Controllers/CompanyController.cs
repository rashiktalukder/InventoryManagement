using InventoryManagement.API.DataAccess;
using InventoryManagement.API.Models;
using InventoryManagement.API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly InventoryDBContext context;

        public CompanyController(InventoryDBContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var companyObj = context.Company.FindAsync(id).Result;
            if(companyObj == null)
            {
                return NotFound();
            }

            var response = new CompanyResponseDto
            {
                Id = companyObj.Id,
                Name = companyObj.Name,
                Address = companyObj.Address,
                CreatedAt = companyObj.CreatedAt
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = context.Company.Select(c => new CompanyResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                CreatedAt = c.CreatedAt
            }).ToList();

            return Ok(companies);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyCreateDto createDto)
        {
            if (string.IsNullOrEmpty(createDto.Name))
            {
                return BadRequest("Company Name is empty");
            }

            var companyObj = new Company
            {
                Name = createDto.Name,
                Address = createDto.Address
            };

            context.Company.Add(companyObj);
            await context.SaveChangesAsync();

            var response = new CompanyResponseDto
            {
                Id = companyObj.Id,
                Name = companyObj.Name,
                Address = companyObj.Address,
                CreatedAt = companyObj.CreatedAt
            };

            return CreatedAtAction(nameof(GetCompany), new { id = companyObj.Id }, response);
        }
    }
}
