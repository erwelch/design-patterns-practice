using System;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Duck mallardDuck = new MallardDuck();
            mallardDuck.Display();
            mallardDuck.flyBehavior.DoFly();
            mallardDuck.quackBehavior.DoQuack();

            Console.WriteLine();
            
            Duck rubberDuck = new RubberDuck();
            rubberDuck.Display();
            rubberDuck.flyBehavior.DoFly();
            rubberDuck.quackBehavior.DoQuack();
        }
    }

    public abstract class Duck
    {
        public QuackBehavior quackBehavior;
        public FlyBehavior flyBehavior;
        public abstract void Display();
    }

    public class MallardDuck: Duck
    {
        public MallardDuck()
        {
            quackBehavior = new Quack();
            flyBehavior = new Fly();
        }
        public override void Display() {
            Console.WriteLine("I look like a mallard duck");
        }
    }

    public class RubberDuck: Duck
    {
        public RubberDuck()
        {
            quackBehavior = new Squeak();
            flyBehavior = new NoFly();
        }
        public override void Display() {
            Console.WriteLine("I look like a rubber duckie");
        }
    }

    public interface QuackBehavior
    {
        void DoQuack();
    }

    public class Quack: QuackBehavior 
    {
        public void DoQuack()
        {
            Console.WriteLine("Quack!!");
        }
    }

    public class Squeak: QuackBehavior 
    {
        public void DoQuack()
        {
            Console.WriteLine("Squeak!!");
        }
    }

    public interface FlyBehavior
    {
        void DoFly();
    }

    public class Fly: FlyBehavior
    {
        public void DoFly()
        {
            Console.WriteLine("I'm flying!");
        }
    }

    public class NoFly: FlyBehavior
    {
        public void DoFly()
        {
            Console.WriteLine("I'm NOT flying!");
        }
    }
}
