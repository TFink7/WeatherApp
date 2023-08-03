//Weather class encapsulates weather data for specific locations to simplify data management.
using Newtonsoft.Json;
namespace WeatherApp.Models
{
    public class Weather
    {
        public string Location { get; set; }
        public double LocalTemperature { get; set; }
        public double FeelsLike { get; set; }
        public double Humidity { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public string WeatherConditions { get; set; }

        public Weather(string location, double localTemperature, double feelsLike, double humidity, double high, double low, string weatherConditions)
        {
            Location = location;
            LocalTemperature = localTemperature;
            FeelsLike = feelsLike;
            Humidity = humidity;
            High = high;
            Low = low;
            WeatherConditions = weatherConditions;
        }
    }
}
