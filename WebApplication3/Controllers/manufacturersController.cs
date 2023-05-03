using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Database;
using WebApplication3.Models;

namespace WebApplication3.Controllers

    
{
    //http://localhost:7049

    [Route("api/[controller]")]
    [ApiController]
    public class manufacturersController : ControllerBase
    {
        //Variable
        private readonly DataDbcontext _dbContext;

        //Contructure Method

        public manufacturersController(DataDbcontext DbContext)
        {
            _dbContext = DbContext;
        }

        // get post put delete
        //Async Await
        [HttpGet]

        public async Task<ActionResult<List<manufacturers>>> getManufacturers()
        {
            var manufactruers = await _dbContext.manufacturers.ToListAsync();

            if (manufactruers.Count == 0)
            {
                return NotFound();
            }
            return Ok(manufactruers);
        }


        //get by id
        [HttpGet("id")]
        public async Task<ActionResult<manufacturers>> getManufacturer(int id)
        {
            var manufacturer1 = await _dbContext.manufacturers.FindAsync(id);

            if (manufacturer1 == null)
            {
                return NotFound();
            }
            return Ok(manufacturer1);
        }


        // Post Method
        [HttpPost]
        public async Task<ActionResult<manufacturers>> postManufacturer(manufacturers manufacturers)
        {
            try
            {
                _dbContext.manufacturers.Add(manufacturers);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();            
            }

            return Ok(manufacturers);
        }

        //Put 
        [HttpPut]
        public async Task<ActionResult<manufacturers>> putManufacturer(int id, manufacturers manufacturers)
        {
            var manufacturer = await _dbContext.manufacturers.FindAsync(id);

            if (manufacturer == null)
            {
                return NotFound();

            }
            manufacturer.id = manufacturers.id;
            manufacturer.Title = manufacturers.Title;

            await _dbContext.SaveChangesAsync();

            return Ok(manufacturer);
        }

        //Delete
        [HttpDelete]
        public async Task<ActionResult<manufacturers>> deleteManufacurer(int id)
        {
            var manufacturer2 = await _dbContext.manufacturers.FindAsync(id);

            if (manufacturer2 == null)
            {
                return NotFound();
            }

            _dbContext.manufacturers.Remove(manufacturer2);

            return Ok(manufacturer2);
        }

    }
}
