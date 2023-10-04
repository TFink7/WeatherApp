//WeatherService class encapsulates the logic for retrieving weather data from weather APIs to pass into Weather class flexibly.
using Newtonsoft.Json;
using WeatherApp.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
    public static class WeatherService
    {
        public static async Task<Weather?> GetWeatherAsync(string location)
        {
            using var client = new HttpClient();
            var apiKey = System.Environment.GetEnvironmentVariable("WEATHER_API_KEY");
            string body;

            try
            {
                var response = await client.GetAsync($"https://api.weatherapi.com/v1/forecast.json?key={apiKey}&q={location}&days=1&aqi=no&alerts=no");
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("\nUnable to fetch weather data. Please input a valid city or postal code.");
                return null;
            }

            // Deserialize JSON directly to WeatherData
            WeatherData? data = JsonConvert.DeserializeObject<WeatherData>(body);
            if (data == null)
            {
                Console.WriteLine("\nFailed to deserialize the weather data.");
                return null;
            }

            string weatherConditions = DetermineWeatherConditions(data);

            if (data.Location.Name == null ||
                data.Current.TempC == null ||
                data.Current.FeelsLikeC == null ||
                data.Current.Humidity == null ||
                data.Forecast.Forecastday[0].Day.MaxTempC == null ||
                data.Forecast.Forecastday[0].Day.MinTempC == null)
            {
                Console.WriteLine("\nSome weather data was missing.");
                return null;
            }

            return new Weather(data.Location.Name,
                               data.Current.TempC.Value,
                               data.Current.FeelsLikeC.Value,
                               data.Current.Humidity.Value,
                               data.Forecast.Forecastday[0].Day.MaxTempC.Value,
                               data.Forecast.Forecastday[0].Day.MinTempC.Value,
                               weatherConditions);
        }

        private static string DetermineWeatherConditions(WeatherData data)
        {
            int? dailyWillitSnow = data.Forecast.Forecastday[0].Day.DailyWillItSnow;
            int? dailyWillitRain = data.Forecast.Forecastday[0].Day.DailyWillItRain;
            int? cloud = data.Current.Cloud;

            return dailyWillitSnow == 1 ? "Snow" :
                   dailyWillitRain == 1 ? "Rain" :
                   cloud > 50 ? "Cloudy" : "Sunny";
        }
    }
}
