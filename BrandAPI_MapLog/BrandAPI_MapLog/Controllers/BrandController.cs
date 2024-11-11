using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BrandAPI.Models;
using BrandAPI_MapLog.DTO;
using BrandWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BrandAPI_MapLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly BrandDbContext dbContext;
        private readonly IMapper mapper;
        private readonly ILogger<BrandController> logger;

        public BrandController(BrandDbContext dbContext, IMapper mapper, ILogger<BrandController> logger)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.logger = logger;
        }

        // GET: api/brand
        [HttpGet]
        public IActionResult GetAllBrands()
        {
            logger.LogInformation("Fetching all brands from the database.");

            var brandList = dbContext.Brands.ToList();

            var brandDTOs = mapper.Map<List<BrandDTO>>(brandList);

            logger.LogInformation("Successfully fetched {Count} brands.", brandDTOs.Count);

            return Ok(brandDTOs);
        }

        // GET: api/brand/{id}
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetBrandById(int id)
        {
            logger.LogInformation("Fetching brand with id {Id}", id);

            var brand = dbContext.Brands.Find(id);
            if (brand == null)
            {
                logger.LogWarning("Brand with id {Id} not found.", id);
                return NotFound();
            }

            var brandDTO = mapper.Map<BrandDTO>(brand);
            return Ok(brandDTO);
        }

        // POST: api/brand
        [HttpPost]
        public IActionResult AddBrand(AddDTO addDTO)
        {
            logger.LogInformation("Adding a new brand with name {Name}.", addDTO.Name);

            var brandEntity = mapper.Map<Brand>(addDTO);
            dbContext.Brands.Add(brandEntity);
            dbContext.SaveChanges();

            var brandDTO = mapper.Map<BrandDTO>(brandEntity);

            logger.LogInformation("Successfully added a new brand with id {Id}.", brandEntity.Id);

            return Ok(brandDTO);
        }

        // PUT: api/brand/{id}
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateBrand(int id, UpdateDTO updateDTO)
        {
            logger.LogInformation("Updating brand with id {Id}.", id);

            var brand = dbContext.Brands.Find(id);
            if (brand == null)
            {
                logger.LogWarning("Brand with id {Id} not found.", id);
                return NotFound();
            }

            mapper.Map(updateDTO, brand);
            dbContext.SaveChanges();

            var brandDTO = mapper.Map<BrandDTO>(brand);

            logger.LogInformation("Successfully updated brand with id {Id}.", id);

            return Ok(brandDTO);
        }

        // DELETE: api/brand/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteBrand(int id)
        {
            logger.LogInformation("Deleting brand with id {Id}.", id);

            var brand = dbContext.Brands.Find(id);
            if (brand == null)
            {
                logger.LogWarning("Brand with id {Id} not found.", id);
                return NotFound();
            }

            dbContext.Brands.Remove(brand);
            dbContext.SaveChanges();

            logger.LogInformation("Successfully deleted brand with id {Id}.", id);

            return Ok();
        }
    }
}
