using WeatherApp.Models;
using System;
using System.Threading.Tasks;
using WeatherApp.Services;

namespace WeatherApp.Views
{
    public static class UserInterface
    {
        public static async Task DisplayWeather()
        {
            Console.WriteLine("Enter a city or postal code to get the current weather:");
            var location = Console.ReadLine();
            if (location == null)
            {
                DisplayError("No location entered.");
                return;
            }
            var weather = await WeatherService.GetWeatherAsync(location);
            if (weather == null)
            {
                DisplayError("No weather data found.");
                return;
            }
            Console.WriteLine($"Location: {weather.Location}");
            Console.WriteLine($"Current Temperature: {weather.LocalTemperature}°C, Feels Like: {weather.FeelsLike}°C");
            Console.WriteLine($"Humidity: {weather.Humidity}%");
            Console.WriteLine($"High: {weather.High}°C, Low: {weather.Low}°C");
            Console.WriteLine($"Weather Conditions: {weather.WeatherConditions}");
        }

        public static void DisplayError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }
}