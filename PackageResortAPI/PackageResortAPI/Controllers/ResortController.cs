using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackageResortAPI.Models.Domain;
using PackageResortAPI.Services;

namespace PackageResortAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResortController : ControllerBase
    {
        private readonly IResortService _resortService;

        public ResortController(IResortService resortService)
        {
            _resortService = resortService;
        }

        [HttpGet]
        public async Task<IActionResult> GetResorts()
        {
            var resorts = await _resortService.GetAllResortsAsync();
            return Ok(resorts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResortById(int id)
        {
            var resort = await _resortService.GetResortByIdAsync(id);
            if (resort == null)
            {
                return NotFound();
            }
            return Ok(resort);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResort([FromBody] Resort resort)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdResort = await _resortService.CreateResortAsync(resort);
            return CreatedAtAction(nameof(GetResortById), new { id = createdResort.Id }, createdResort);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResort(int id, [FromBody] Resort resort)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedResort = await _resortService.UpdateResortAsync(id, resort);
            if (updatedResort == null)
            {
                return NotFound();
            }
            return Ok(updatedResort);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResort(int id)
        {
            var result = await _resortService.DeleteResortAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
