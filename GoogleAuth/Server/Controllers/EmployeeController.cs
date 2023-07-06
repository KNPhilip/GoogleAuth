using GoogleAuth.Server.Data;
using GoogleAuth.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GoogleAuth.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var user = await _context.Users
                .Include(u => u.Employees)
                .FirstOrDefaultAsync(u => u.Id == User
                .FindFirstValue(ClaimTypes.NameIdentifier));

            if (user is null)
                return NotFound();
            return Ok(user.Employees);
        }
    }
}