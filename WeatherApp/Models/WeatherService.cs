//WeatherService class encapsulates the logic for retrieving weather data from weather APIs to pass into Weather class flexibly.
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace WeatherApp.Models
{
    public static class WeatherService
    {
        public static async Task<Weather?> GetWeatherAsync(string location)
        {
            var client = new HttpClient();
            var apiKey = System.Environment.GetEnvironmentVariable("WEATHER_API_KEY");
            try
            {
                var response = await client.GetAsync($"https://api.weatherapi.com/v1/forecast.json?key={apiKey}&q={location}&days=1&aqi=no&alerts=no");
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var parsedResponse = JObject.Parse(body);

                string weatherConditions;
                int? dailyWillitSnow = (int?)parsedResponse["forecast"]?["forecastday"]?[0]?["day"]?["daily_will_it_snow"];
                int? dailyWillitRain = (int?)parsedResponse["forecast"]?["forecastday"]?[0]?["day"]?["daily_will_it_rain"];
                int? cloud = (int?)parsedResponse["current"]?["cloud"];

                weatherConditions = dailyWillitSnow == 1 ? "Snow"
                    : dailyWillitRain == 1 ? "Rain"
                    : cloud > 50 ? "Cloudy"
                    : "Sunny";

                var locationName = (string?)parsedResponse["location"]?["name"];
                var currentTemp = (double?)parsedResponse["current"]?["temp_c"];
                var feelsLikeTemp = (double?)parsedResponse["current"]?["feelslike_c"];
                var humidity = (double?)parsedResponse["current"]?["humidity"];
                var highTemp = (double?)parsedResponse["forecast"]?["forecastday"]?[0]?["day"]?["maxtemp_c"];
                var lowTemp = (double?)parsedResponse["forecast"]?["forecastday"]?[0]?["day"]?["mintemp_c"];

                if (locationName == null || currentTemp == null || feelsLikeTemp == null || humidity == null || highTemp == null || lowTemp == null)
                {
                    return null;
                }

                return new Weather(locationName, currentTemp.Value, feelsLikeTemp.Value, humidity.Value, highTemp.Value, lowTemp.Value, weatherConditions);
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("\nUnable to fetch weather data. Please input a valid city or postal code.");
                return null;
            }
        }
    }
}
