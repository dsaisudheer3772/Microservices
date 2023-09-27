using Microsoft.AspNetCore.Mvc;
using CRM.Users._DbContext;
using CRM.Users.Models;
using Microsoft.EntityFrameworkCore;


namespace CRM.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly UserContext _context;

        public RegisterController(UserContext context)
        {
            _context = context;
        }
        // Get : api/register/5
        [HttpGet("{registerid}")]
        public async Task<ActionResult<RegisterUser>> GetRegister(long registerid)
        {
            var register = await _context.RegisterUsers.FindAsync(registerid);
            if (register == null)
            {
                return NotFound();
            }
            return register;
        }
        // Get : api/register            get all records
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterUser>>> GetRegisters()
        {
            var data = await _context.RegisterUsers.ToListAsync();
            return await _context.RegisterUsers.ToListAsync();
        }
        // Post : api/register          Save Record
        [HttpPost]
        public async Task<ActionResult<RegisterUser>> NewRegister(RegisterUser obj)
        {
            try
            {
                _context.RegisterUsers.Add(obj);
                await _context.SaveChangesAsync();

                // Return JSON data with a 201 Created status
                return Ok(new { message = "Successfully Saved", status = 200 });
            }
            catch (Exception ex)
            {
                // Log the exception and return an error response
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        //Delete : api/register/5       Delete
        [HttpDelete("{registerid}")]
        public async Task<IActionResult> DeleteRegisterId(long registerid)
        {
            var register = await _context.RegisterUsers.FindAsync(registerid);
            if (register == null)
            {
                return NotFound();
            }
            _context.RegisterUsers.Remove(register);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool RegisterExists(long registerid)
        {
            return _context.RegisterUsers.Any(e => e.regesterid == registerid);
        }
        // Put : api/refresh/5          Updating records
        [HttpPut("{registerid}")]
        public async Task<IActionResult> updateEmployee(long registerid, RegisterUser registerusers)
        {
            if (registerid != registerusers.regesterid)
            {
                return BadRequest();
            }
            _context.Entry(registerusers).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterExists(registerid))
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

        // Post : api/login          Save Record
        [HttpPost]
        [Route("login")]
        public IActionResult Login(RegisterUser obj)
        {
            try
            {
                if (obj.phonenumber != null && obj.email != null)
                {
                    // Check if a user with the provided phone number exists
                    var userWithPhoneNumber = _context.RegisterUsers.FirstOrDefault(e => e.phonenumber == obj.phonenumber);

                    // Check if a user with the provided email exists
                    var userWithEmail = _context.RegisterUsers.FirstOrDefault(e => e.email == obj.email);

                    if (userWithPhoneNumber != null || userWithEmail != null)
                    {
                        // Check if the provided password matches the user's password
                        if (userWithPhoneNumber != null && userWithPhoneNumber.password == obj.password)
                        {
                            // Successfully logged in with phone number
                            var response = new { Message = "Successfully logged in with phone number" };
                            return Json(response);
                        }
                        else if (userWithEmail != null && userWithEmail.password == obj.password)
                        {
                            // Successfully logged in with email
                            var response = new { Message = "Successfully logged in with email" };
                            return Json(response);
                        }
                        else
                        {
                            // Password is incorrect
                            var response = new { Message = "Incorrect password" };
                            return Json(response);
                        }
                    }
                    else
                    {
                        // User with provided phone number or email not found
                        var response = new { Message = "User not found" };
                        return Json(response);
                    }
                }
                else
                {
                    // Invalid input (phone number or email is missing)
                    var response = new { Message = "Invalid input" };
                    return Json(response);
                }
            }
            catch (Exception) {
                var response = new { Message = "Any Error occur in method" };
                return Json(response);
            }
        }
    }
}
