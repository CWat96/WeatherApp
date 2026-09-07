namespace WeatherApp.Models
{
    public class WeatherResponse
    {
        public string? Name { get; set; }
        public MainWeather? Main {  get; set; } //null-conditional operator allows Main to be null. Prevents a NullReferenceException.
        public List<WeatherCondition> Weather {  get; set; }
    }
}
