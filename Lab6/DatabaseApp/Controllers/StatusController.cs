namespace DatabaseApp.Controllers;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

using DatabaseApp.Data;
using DatabaseApp.Models;

[Route("dbapi/[controller]")]
[ApiController]
public class StatusController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public StatusController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Action to list all locations, returning data as JSON
    // [HttpGet("Location")]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var statuses = await _context.RefStatuses.ToListAsync(); // Await completion of the query
        return Ok(statuses); // Return statuses as JSON
    }

    // Action to view a single location by ID, returning data as JSON
    // [HttpGet("Location/{id}")]
    [HttpGet("{id}")]
    public async Task<IActionResult> DetailsDB(string id)
    {
        var status = await _context.RefStatuses
            .FirstOrDefaultAsync(p => p.StatusCode == id); // Await completion of the query
        return Ok(status); // Return status as JSON
    }
}
