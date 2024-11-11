using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrandAPI.Models;
using BrandWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrandAPI_Seeding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly BrandDbContext dbContext;

        public BrandController(BrandDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/brand
        [HttpGet]
        public IActionResult GetAllBrands()
        {
            var brandList = dbContext.Brands.ToList();

            // Map Brand to BrandDTO
            var brandDTOs = brandList.Select(b => new AddDTO
            {
                Name = b.Name,
                Model = b.Model
            }).ToList();

            return Ok(brandDTOs);
        }

        // GET: api/brand/{id}
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetBrandById(int id)
        {
            var brand = dbContext.Brands.Find(id);
            if (brand == null)
            {
                return NotFound();
            }

            // Map Brand to BrandDTO
            var brandDTO = new AddDTO
            {
                Name = brand.Name,
                Model = brand.Model
            };

            return Ok(brandDTO);
        }

        // POST: api/brand
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

            // Map Brand to BrandDTO for response
            var brandDTO = new AddDTO
            {
                Name = brandEntity.Name,
                Model = brandEntity.Model
            };

            return Ok(brandDTO);
        }

        // PUT: api/brand/{id}
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateBrand(int id, UpdateDTO updateDTO)
        {
            var brand = dbContext.Brands.Find(id);
            if (brand == null)
            {
                return NotFound();
            }

            brand.Name = updateDTO.Name;
            brand.Model = updateDTO.Model;
            dbContext.SaveChanges();

            // Map updated Brand to BrandDTO
            var brandDTO = new UpdateDTO
            {
                Name = brand.Name,
                Model = brand.Model
            };

            return Ok(brandDTO);
        }

        // DELETE: api/brand/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteBrand(int id)
        {
            var brand = dbContext.Brands.Find(id);
            if (brand == null)
            {
                return NotFound();
            }

            dbContext.Brands.Remove(brand);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
