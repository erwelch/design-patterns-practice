using System;

namespace DecoratorPattern
{
    public class Program
    {
        public static void Main() 
        {
            Console.WriteLine("Cart: ");

            Beverage first = new Mocha(new DarkRoast());
            Beverage second = new SteamedMilk(new HouseBlend());

            Console.WriteLine($"Order 1: {first.Description}\t\t{first.Cost}");
            Console.WriteLine($"Order 2: {second.Description}\t\t{second.Cost}");
        }
    }

    public abstract class Beverage 
    {
        public abstract string Description { get; }

        public abstract double Cost { get; }
    }

    public class HouseBlend : Beverage
    {
        public override double Cost { get; } = 0.89;

        public override string Description { get; } = "Our home roasted coffee";
    }

    public class DarkRoast : Beverage
    {
        public override double Cost { get; } = 0.99;

        public override string Description { get; } = "Our dark roasted coffee";
    }

    public abstract class CondimentDecorator : Beverage
    {
        public Beverage Beverage { get; }
        
        public CondimentDecorator(Beverage beverage)
        {
            Beverage = beverage;
        }
    }

    public class SteamedMilk : CondimentDecorator
    {
        public SteamedMilk(Beverage beverage) : base(beverage)
        {
        }

        public override string Description => Beverage.Description + ", Steamed Milk";

        public override double Cost => Beverage.Cost + 0.10;
    }

    public class Mocha : CondimentDecorator
    {
        public Mocha(Beverage beverage) : base(beverage)
        {
        }

        public override string Description => Beverage.Description + ", Mocha";

        public override double Cost => Beverage.Cost + 0.20;
    }
}
