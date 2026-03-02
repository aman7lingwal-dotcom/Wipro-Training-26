using SolidPrinciplesDemo.Interfaces;

namespace SolidPrinciplesDemo.Services
{
    public class WeatherDisplay : IObserver
    {
        public void Update(string data)
        {
            System.Console.WriteLine("Weather update: " + data);
        }
    }
}
