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

        public async Task<string> GetWeatherAsync(string city)
        {
            var url = $"https://api.openweathermap.org/data/4.0/onecall/current?lat={{lat}}&lon={{lon}}&appid={{API key}}";
            
            var response = await _httpClient.GetAsync(url); //Send an HTTP GET request to our URL

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return json;

        }
    }
}
