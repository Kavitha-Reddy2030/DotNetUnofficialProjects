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
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        // GET: api/package
        [HttpGet]
        public async Task<IActionResult> GetPackages()
        {
            var packages = await _packageService.GetAllPackagesAsync();
            return Ok(packages);
        }

        // GET: api/package/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPackageById(int id)
        {
            var package = await _packageService.GetPackageByIdAsync(id);
            if (package == null)
            {
                return NotFound();
            }
            return Ok(package);
        }

        // POST: api/package
        [HttpPost]
        public async Task<IActionResult> CreatePackage([FromBody] Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdPackage = await _packageService.CreatePackageAsync(package);
            return CreatedAtAction(nameof(GetPackageById), new { id = createdPackage.Id }, createdPackage);
        }

        // PUT: api/package/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePackage(int id, [FromBody] Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedPackage = await _packageService.UpdatePackageAsync(id, package);
            if (updatedPackage == null)
            {
                return NotFound();
            }
            return Ok(updatedPackage);
        }

        // DELETE: api/package/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackage(int id)
        {
            var result = await _packageService.DeletePackageAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
   
}
