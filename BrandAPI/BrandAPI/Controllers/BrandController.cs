using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrandAPI.Models;
using BrandWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace BrandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly BrandDbContext dbContext;
        private readonly SieveProcessor sieveProcessor;
        public BrandController(BrandDbContext dbContext, SieveProcessor sieveProcessor)
        {
            this.dbContext = dbContext;
            this.sieveProcessor = sieveProcessor;
        }

        [HttpGet("sieve")]
        public async Task<IActionResult> GetAllBrands([FromQuery] SieveModel sieveModel)
        {
            var brands = dbContext.Brands.AsQueryable();

            // Apply filtering and sorting using Sieve
            var filteredBrands = await sieveProcessor.Apply(sieveModel, brands).ToListAsync();

            var totalCount = await dbContext.Brands.CountAsync();

            return Ok(new
            {
                TotalCount = totalCount,
                Brands = filteredBrands
            });
        }


        [HttpGet]
        public IActionResult GetAllBrands()
        {
            var brandList = dbContext.Brands.ToList();
            return Ok(brandList);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetBrandById(int id)
        {
            var brand = dbContext.Brands.Find(id);
            if (brand is null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        [HttpPost]
        public IActionResult AddBrand(AddDTO addDTO)
        {
            var brandEntity = new Brand()
            {
                Name = addDTO.Name,
                Model = addDTO.Model
            };
            dbContext.Brands.Add(brandEntity);
            dbContext.SaveChanges();
            return Ok(brandEntity);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateBrand(int id, UpdateDTO updateDTO)
        {
            var brand = dbContext.Brands.Find(id);
            if (brand is null)
            {
                return NotFound();
            }
            brand.Name = updateDTO.Name;
            brand.Model = updateDTO.Model;
            dbContext.SaveChanges();
            return Ok(brand);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteBrand(Guid id)
        {
            var brand = dbContext.Brands.Find(id);
            if (brand is null)
            {
                return NotFound();
            }
            dbContext.Brands.Remove(brand);
            dbContext.SaveChanges();
            return Ok();
        }

    }
}
