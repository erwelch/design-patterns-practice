using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            WeatherData weatherData = new WeatherData();

            DisplayOne display_one = new DisplayOne(weatherData);
            DisplayTwo display_two = new DisplayTwo(weatherData);

            WeatherState weatherState = new WeatherState();
            weatherState.Humidity = 0.0f;
            weatherState.Temperature = 65.3f;

            weatherData.updateWeatherState(weatherState);

        }
    }
    
    public interface IDataState {}
    public interface ISubject {
        void registerObserver(IObserver o);
        void removeObserver(IObserver o);

        void notifyObservers(); 
    }

    public interface IObserver {
        void update(ISubject subject);
    }

    public class WeatherState: IDataState {
        public float Temperature;
        public float Humidity;
    }

    public class WeatherData : ISubject {
        private List<IObserver> Subscribers;
        public WeatherState WeatherState = new WeatherState();

        public WeatherData(){
            this.Subscribers = new List<IObserver>();
            this.WeatherState.Temperature = 60.0f;
            this.WeatherState.Humidity = 50.5f;
        }
        public void registerObserver(IObserver o) {
            this.Subscribers.Add(o);
        }
        public void removeObserver(IObserver o) {
            Console.WriteLine("Remove someone");
        }

        public void updateWeatherState(WeatherState weatherState) {
            this.WeatherState = weatherState;
            this.notifyObservers();
        }

        public void notifyObservers() {
            foreach (var observer in this.Subscribers) {
                observer.update(this);
            }
        }
    }

    public class DisplayOne: IObserver {
        public WeatherData Subject;
        public DisplayOne(ISubject subject) {
            this.Subject = (WeatherData)subject;
            this.Subject.registerObserver(this);
        }
        public void update(ISubject subject) {
            if (subject is WeatherData) {
                this.Subject = (WeatherData)subject;
                Console.WriteLine("I am Display One and received updates!");
                Console.WriteLine("Displaying Temperature: {0}", this.Subject.WeatherState.Temperature);
            }
        }
    }

    public class DisplayTwo: IObserver {
        public WeatherData Subject;
        public DisplayTwo(ISubject subject) {
            this.Subject = (WeatherData)subject;
            this.Subject.registerObserver(this);
        }
        public void update(ISubject subject) {
            if (subject is WeatherData) {
                this.Subject = (WeatherData)subject;
                Console.WriteLine("I am Display TWO and received updates!");
                Console.WriteLine("Displaying Humidity: {0}", this.Subject.WeatherState.Humidity);
            }
        }
    }
}
