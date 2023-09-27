using Microsoft.AspNetCore.Mvc;
using CRM.Core._DbContext;
using CRM.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefershController : Controller
    {
        private readonly CoreDbContext _context;

        public RefershController(CoreDbContext context) {
            _context = context;
        }
        // Get : api/refresh/5
        [HttpGet("{deviceid}")]
        public async Task<ActionResult<Device>> GetEmployee(long deviceid)
        {
            var device = await _context.Devices.FindAsync(deviceid);
            if (device == null)
            {
                return NotFound();
            }
            return device;
        }
        // Get : api/refresh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {

            return await _context.Devices.ToListAsync();
        }
        // Save
        [HttpPost]
        public async Task<ActionResult<Device>> NewDevice(Device obj) { 
            _context.Devices.Add(obj);
            var x = await _context.SaveChangesAsync();
            return CreatedAtAction("Successfully Saved", new { id = "Successfully Saved" });
        }
        //Delete
        [HttpDelete("{deviceid}")]
        public async Task<IActionResult> DeleteDeviceId(long deviceid) {
            var device = await _context.Devices.FindAsync(deviceid);
            if (device == null)
            {
                return NotFound();
            }
            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool DeviceExists(long deviceid)
        {
            return _context.Devices.Any(e => e.deviceid == deviceid);
        }
        // updating : api/refresh/5
        [HttpPut("{deviceid}")]
        public async Task<IActionResult> updateEmployee(long deviceid, Device device)
        {
            if (deviceid != device.deviceid)
            {
                return BadRequest();
            }
            _context.Entry(device).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(deviceid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

    }
}
