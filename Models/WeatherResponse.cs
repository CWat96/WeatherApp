namespace WeatherApp.Models
{
    public class WeatherResponse
    {
        public string? Name { get; set; }
        public MainWeather? Main {  get; set; }
        public List<WeatherCondition> Weather {  get; set; }
    }
}
