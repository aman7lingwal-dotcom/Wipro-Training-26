using System.Collections.Generic;
using SolidPrinciplesDemo.Interfaces;

namespace SolidPrinciplesDemo.Services
{
    public class WeatherStation
    {
        private List<IObserver> observers = new List<IObserver>();

        public void Register(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Unregister(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify(string data)
        {
            foreach (var observer in observers)
            {
                observer.Update(data);
            }
        }
    }
}
