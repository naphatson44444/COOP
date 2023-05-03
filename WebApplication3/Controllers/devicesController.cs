using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Database;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class devicesController : ControllerBase
    {
        //Variable
        private readonly DataDbcontext _dbContext;


        //Contructure Method

        public devicesController(DataDbcontext DbContext)
        {
            _dbContext = DbContext;
        }

        // get post put delete
        //Async Await
        [HttpGet]

        public async Task<ActionResult<List<devices>>> getDevices()
        {
            var devices = await _dbContext.devices.ToListAsync();

            if (devices.Count == 0)
            {
                return NotFound();
            }
            return Ok(devices);
        }


        //get by id
        [HttpGet("id")]
        public async Task<ActionResult<devices>> getDevices(int id)
        {
            var device1 = await _dbContext.devices.FindAsync(id);

            if (device1 == null)
            {
                return NotFound();
            }
            return Ok(device1);
        }


        // Post Method
        [HttpPost]
        public async Task<ActionResult<devices>> postDevices(devices devices)
        {
            try
            {
                _dbContext.devices.Add(devices);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return Ok(devices);
        }

        //Put 
        [HttpPut]
        public async Task<ActionResult<devices>> putDevices(int id, devices devices)
        {
            var device = await _dbContext.devices.FindAsync(id);

            if (device == null)
            {
                return NotFound();

            }
            device.id = devices.id;
            device.Title = devices.Title;
            device.Processor = devices.Processor;
            device.Price = devices.Price;
            device.Manufacturer_id = devices.Manufacturer_id;

            await _dbContext.SaveChangesAsync();

            return Ok(device);
        }

        //Delete
        [HttpDelete]
        public async Task<ActionResult<devices>> deleteDevices(int id)
        {
            var device2 = await _dbContext.devices.FindAsync(id);

            if (device2 == null)
            {
                return NotFound();
            }

            _dbContext.devices.Remove(device2);

            return Ok(device2);
        }

        //get by manufacturer
        [HttpGet("manufacturer/(id)")]
        public async Task<ActionResult<List<devices>>> getDevicesByManufacturerId(int id)
        {
            var devices = await _dbContext.devices.Where(e=> e.Manufacturer_id == id).ToListAsync();
            if (devices.Count == 0)
            {
                return NotFound();
            }
            return Ok(devices);        }


    }
}
