using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackageResortAPI.Models.Domain;
using PackageResortAPI.Models.DTO;
using PackageResortAPI.Services;

namespace PackageResortAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetCity(int id)
        {
            var cityDto = await _cityService.GetCityAsync(id);

            if (cityDto == null)
            {
                return NotFound();
            }

            return Ok(cityDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCities()
        {
            var cities = await _cityService.GetAllCitiesAsync();
            return Ok(cities);
        }
        [HttpPost]
        public async Task<ActionResult<CityDto>> CreateCity(CityDto cityDto)
        {
            var createdCity = await _cityService.CreateCityAsync(cityDto);
            return CreatedAtAction(nameof(GetCity), new { id = createdCity.Id }, createdCity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CityDto>> UpdateCity(int id, CityDto cityDto)
        {
            var updatedCity = await _cityService.UpdateCityAsync(id, cityDto);

            if (updatedCity == null)
            {
                return NotFound();
            }

            return Ok(updatedCity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var result = await _cityService.DeleteCityAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
