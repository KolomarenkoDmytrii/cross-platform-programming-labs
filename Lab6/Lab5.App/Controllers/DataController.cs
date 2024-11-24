namespace Lab5.App.Controllers;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using DatabaseApp.Models;
using Lab5.App.Models;
using DatabaseAppErrorViewModel = DatabaseApp.Models.ErrorViewModel;
using ErrorViewModel = Lab5.App.Models.ErrorViewModel;

[Authorize]
public class DataController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly string _apiBaseUrl;
    private readonly JsonSerializerOptions _jsonOptions;

    public DataController(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;

        _apiBaseUrl = _configuration.GetValue<string>("ApiSettings:BaseUrl");

        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<IActionResult> ListStatuses()
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/Status");

            if (!response.IsSuccessStatusCode)
            {
                return HandleApiError(response.StatusCode);
            }

            var content = await response.Content.ReadAsStringAsync();
            var statuses = JsonSerializer.Deserialize<List<RefStatus>>(content, _jsonOptions);

            return View(statuses ?? new List<RefStatus>());
        }
        catch (HttpRequestException error)
        {
            return View("Error", new ErrorViewModel
            {
                Message = $"API Connection Error: {error.Message}",
                RequestId = HttpContext.TraceIdentifier
            });
        }
    }

    public async Task<IActionResult> ListLocations()
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/Location");

            if (!response.IsSuccessStatusCode)
            {
                return HandleApiError(response.StatusCode);
            }

            var content = await response.Content.ReadAsStringAsync();
            var locations = JsonSerializer.Deserialize<List<Location>>(content, _jsonOptions);

            return View(locations ?? new List<Location>());
        }
        catch (HttpRequestException error)
        {
            return View("Error", new ErrorViewModel
            {
                Message = $"API Connection Error: {error.Message}",
                RequestId = HttpContext.TraceIdentifier
            });
        }
    }

    public async Task<IActionResult> ListSizes()
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/Size");

            if (!response.IsSuccessStatusCode)
            {
                return HandleApiError(response.StatusCode);
            }

            var content = await response.Content.ReadAsStringAsync();
            var sizes = JsonSerializer.Deserialize<List<RefSize>>(content, _jsonOptions);

            return View(sizes ?? new List<RefSize>());
        }
        catch (HttpRequestException error)
        {
            return View("Error", new ErrorViewModel
            {
                Message = $"API Connection Error: {error.Message}",
                RequestId = HttpContext.TraceIdentifier
            });
        }
    }

    private IActionResult HandleApiError(System.Net.HttpStatusCode statusCode)
    {
        var errorMessage = statusCode switch
        {
            System.Net.HttpStatusCode.NotFound => "Resource not found",
            System.Net.HttpStatusCode.Unauthorized => "Unauthorized access",
            System.Net.HttpStatusCode.BadRequest => "Invalid request",
            _ => "An error occurred while processing your request"
        };

        return View("Error", new ErrorViewModel
        {
            Message = errorMessage,
            RequestId = HttpContext.TraceIdentifier
        });
    }
}
