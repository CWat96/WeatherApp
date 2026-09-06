namespace WeatherApp.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string? _apiKey;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

            _apiKey = _configuration["OpenWeatherMap:ApiKey"];
        }

        public async Task<string> GetWeatherAsync(string city)
        {

        }
    }
}
