//Weather class encapsulates weather data for specific locations to simplify data management.
using Newtonsoft.Json;
namespace WeatherApp.Models
{
    public class Weather
    {
        public string Location { get; private set; }
        public double LocalTemperature { get; private set; }
        public double FeelsLike { get; private set; }
        public double Humidity { get; private set; }
        public double High { get; private set; }
        public double Low { get; private set; }
        public string WeatherConditions { get; private set; }

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
