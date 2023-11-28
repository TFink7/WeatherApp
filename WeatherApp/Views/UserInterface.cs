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
            while (true)
            {
                Console.WriteLine("Enter a city or postal code to get the current weather (or type 'exit' to quit):");
                var location = Console.ReadLine();

                if (string.IsNullOrEmpty(location))
                {
                    DisplayError("No location entered. Please try again.");
                    continue;
                }

                if (location.ToLower() == "exit")
                {
                    break;
                }

                var weather = await WeatherService.GetWeatherAsync(location);
                if (weather == null)
                {
                    DisplayError("No weather data found. Please try again.");
                    continue;
                }

                Console.WriteLine($"Location: {weather.Location}");
                Console.WriteLine($"Current Temperature: {weather.LocalTemperature}°C, Feels Like: {weather.FeelsLike}°C");
                Console.WriteLine($"Humidity: {weather.Humidity}%");
                Console.WriteLine($"High: {weather.High}°C, Low: {weather.Low}°C");
                Console.WriteLine($"Weather Conditions: {weather.WeatherConditions}");


                Console.WriteLine("\nType 'exit' to quit or press Enter to check another location.");
                var command = Console.ReadLine();
                if (command.ToLower() == "exit")
                {
                    break;
                }
            }
        }

        public static void DisplayError(string message)
        {
            Console.WriteLine($"Error: {message}\n");
        }
    }
}
