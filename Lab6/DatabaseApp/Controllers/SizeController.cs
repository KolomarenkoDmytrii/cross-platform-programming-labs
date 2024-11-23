namespace DatabaseApp.Controllers;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

using DatabaseApp.Data;
using DatabaseApp.Models;

[Route("dbapi/[controller]")]
[ApiController]
public class SizeController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SizeController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Action to list all locations, returning data as JSON
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var sizes = await _context.RefSizes.ToListAsync(); // Await completion of the query
        return Ok(sizes); // Return sizes as JSON
    }

    // Action to view a single location by ID, returning data as JSON
    [HttpGet("{id}")]
    public async Task<IActionResult> DetailsDB(string id)
    {
        var size = await _context.RefSizes
            .FirstOrDefaultAsync(p => p.SizeCode == id); // Await completion of the query
        return Ok(size); // Return size as JSON
    }
}
