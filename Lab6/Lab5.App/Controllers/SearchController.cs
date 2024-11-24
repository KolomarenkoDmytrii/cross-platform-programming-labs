namespace Lab5.App.Controllers;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
public class SearchController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly string _apiBaseUrl;
    private readonly JsonSerializerOptions _jsonOptions;

    public SearchController(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;

        _apiBaseUrl = _configuration.GetValue<string>("ApiSettings:BaseUrl");

        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    [HttpGet]
    public IActionResult Search()
    {
        return View(new List<SearchResult>());
    }

    [HttpPost]
    public async Task<IActionResult> Search(SearchViewModel searchModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                // If search model is valid, send it to the API
                var jsonContent = JsonSerializer.Serialize(searchModel, _jsonOptions);
                // var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var content = new StringContent(jsonContent, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));

                var response = await _httpClient.PostAsync($"{_apiBaseUrl}/SearchDB", content);

                if (!response.IsSuccessStatusCode)
                {
                    return HandleApiError(response.StatusCode);
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                var results = JsonSerializer.Deserialize<List<SearchResult>>(responseContent, _jsonOptions);

                // Return search results
                return View(results ?? new List<SearchResult>());
            }
            catch (HttpRequestException error)
            {
                return View("Error", new ErrorViewModel
                {
                    Message = $"API Connection Error: {error.Message}",
                    RequestId = HttpContext.TraceIdentifier
                });
            }
            catch (JsonException error)
            {
                return View("Error", new ErrorViewModel
                {
                    Message = $"Data processing error: {error.Message}",
                    RequestId = HttpContext.TraceIdentifier
                });
            }
        }

        // If search model is not valid, return empty list of orders
        return View(new List<SearchResult>());
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
