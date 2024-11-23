namespace DatabaseApp.Controllers;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

using DatabaseApp.Data;
using DatabaseApp.Models;

[Route("dbapi/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public LocationController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Action to list all locations, returning data as JSON
    // [HttpGet("Location")]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var locations = await _context.Locations.ToListAsync(); // Await completion of the query
        return Ok(locations); // Return locations as JSON
    }

    // Action to view a single location by ID, returning data as JSON
    // [HttpGet("Location/{id}")]
    [HttpGet("{id}")]
    public async Task<IActionResult> DetailsDB(int id)
    {
        var location = await _context.Locations
            .FirstOrDefaultAsync(p => p.LocationID == id); // Await completion of the query
        return Ok(location); // Return location as JSON
    }
}
