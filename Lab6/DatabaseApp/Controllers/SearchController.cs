namespace DatabaseApp.Controllers;

using System.Threading.Tasks;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

using DatabaseApp.Data;
using DatabaseApp.Models;

[Route("dbapi/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SearchController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Search(SearchViewModel searchModel)
    {
        var query = from alc in _context.AssetLifeCycleEvents
            join a in _context.Assets on alc.AssetID equals a.AssetID
            join lc in _context.LifeCyclePhases on alc.LifeCycleCode equals lc.LifeCycleCode
            join l in _context.Locations on alc.LocationID equals l.LocationID
            join r in _context.ResponsibleParties on alc.PartyID equals r.PartyID
            where alc.DateFrom >= searchModel.StartDate?.ToUniversalTime()
                  && alc.DateTo <= searchModel.EndDate?.ToUniversalTime()
                  && alc.LifeCycleCode in searchModel.Statuses
                  && a.AssetName.StartsWith(searchModel.AssetNameStart)
                  && a.AssetName.StartsWith(searchModel.AssetNameEnd)
            select new
            {
                a.AssetID,
                a.AssetName,
                a.OtherDetails,
                alc.AssetLifeCycleEventID,
                alc.DateFrom,
                alc.DateTo,
                alc.LifeCycleCode,
                alc.StatusCode,
                lc.LifeCycleName,
                l.LocationDetails,
                r.PartyDetails
            };

        var result = await query.ToListAsync();

        TimeZoneInfo ukraineTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Kyiv");

        foreach (var order in result)
        {
            order.DateFrom = TimeZoneInfo.ConvertTimeFromUtc(order.DateFrom, ukraineTimeZone);
            order.DateTo = TimeZoneInfo.ConvertTimeFromUtc(order.DateTo, ukraineTimeZone);
        }

        return Ok(result);
    }
}
