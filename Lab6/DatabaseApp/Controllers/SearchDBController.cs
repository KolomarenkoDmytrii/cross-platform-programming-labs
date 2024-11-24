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
public class SearchDBController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SearchDBController(ApplicationDbContext context)
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
            where alc.DateFrom >= searchModel.StartDate.ToUniversalTime()
                  && alc.DateTo <= searchModel.EndDate.ToUniversalTime()
                  && searchModel.LifeCycleCodes.Contains(alc.LifeCycleCode)
                  && a.AssetName.StartsWith(searchModel.AssetNameStart)
                  && a.AssetName.EndsWith(searchModel.AssetNameEnd)
            select new SearchResult
            {
                AssetID = a.AssetID,
                AssetName = a.AssetName,
                OtherDetails = a.OtherDetails,
                AssetLifeCycleEventID = alc.AssetLifeCycleEventID,
                DateFrom = alc.DateFrom,
                DateTo = alc.DateTo,
                LifeCycleCode = alc.LifeCycleCode,
                StatusCode = alc.StatusCode,
                LifeCycleName = lc.LifeCycleName,
                LocationDetails = l.LocationDetails,
                PartyDetails = r.PartyDetails
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
