using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactProject_WebAPI.Data;
using ReactProject_WebAPI.Models;

namespace ReactProject_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("employeeGetAll")]
        public async Task<ActionResult<IEnumerable<Employee>>> employeeGetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        [HttpGet("employeeGetById")]
        public async Task<ActionResult<Employee>> employeeGetById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPost("employeePost")]
        public async Task<ActionResult<Employee>> employeePost(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(employeeGetById), new { id = employee.EmployeeId }, employee);
        }
    }
}
