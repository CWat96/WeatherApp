using System.Text.Json;
using WeatherApp.Models;
    

namespace WeatherApp.Services
{
    public class WeatherService //How to get weather
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string? _apiKey;
        private readonly string? _baseUrl;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient; 
            _configuration = configuration;

            _apiKey = _configuration["OpenWeatherMap:ApiKey"];
            _baseUrl = _configuration["OpenWeatherMap:BaseUrl"];
        }

        public async Task<WeatherResponse?> GetWeatherAsync(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}";

            var response = await _httpClient.GetAsync(url); //Send an HTTP GET request to our URL

            //response.EnsureSuccessStatusCode();
            // EnsureSuccessStatusCode(); stopped method from completing whenever OpenWeatherMap returned an error status

            var errorBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(errorBody);

            var json = await response.Content.ReadAsStringAsync();

            var weather = JsonSerializer.Deserialize<WeatherResponse>(
                json,
                new JsonSerializerOptions
                {PropertyNameCaseInsensitive = true
                });

            return weather;

        }
    }


}
