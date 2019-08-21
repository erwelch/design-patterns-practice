using System;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface Subject {
        void registerObserver(Observer o);
        void removeObserver(Observer o);

        void notifyObservers(); 
    }

    public interface Observer {
        void update();
    }
}
