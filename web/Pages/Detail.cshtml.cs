using Microsoft.AspNetCore.Mvc.RazorPages;

namespace web.Pages;

public class DetailModel : PageModel
{
    public List<WeatherForecast> Forecast;
    private readonly IConfiguration _config;
    private readonly ILogger<IndexModel> _logger;

    public DetailModel(IConfiguration config, ILogger<IndexModel> logger)
    {
        _config = config;
        _logger = logger;
    }

    public void OnGet()
    {
        Forecast = GetWeatherForecast();
    }

    private List<WeatherForecast> GetWeatherForecast()
    {
        IEnumerable<WeatherForecast> result = null;

        // get api base url from config
        var url = _config.GetValue<string>("Custom:apiurl"); 
        if(url == null){
            throw new NullReferenceException("apiurl");
        }

        // create an http client to call the api
        var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
        );

        // make a call to the api /WeatherForecast
        var response = client.GetAsync("/WeatherForecast").Result;
        if(response.IsSuccessStatusCode)
        {
            result = response.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>().Result;
        }
        else
        {
            _logger.LogError("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }

        // return the results
        return result.ToList();
    }
}