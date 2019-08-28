
interface Beverage {
    description: string;
    getCost(): number;
}

abstract class CondimentDecorator implements Beverage {
    abstract description: string;
    beverage: Beverage;

    constructor(beverage: Beverage) {
        this.beverage = beverage;
    }
    
    abstract getCost(): number;
}

const houseBlend: Beverage = {
    description: "Our house coffee",
    getCost: () => 0.89,
};

const darkRoast: Beverage = {
    description: "Our dark roast coffee",
    getCost: () => 0.99,
};

class Mocha extends CondimentDecorator {
    description: string = this.beverage.description + ", Mocha";

    getCost(): number {
        return this.beverage.getCost() + 0.20;
    }
}

class SteamedMilk extends CondimentDecorator {
    description: string = this.beverage.description + ", Steamed Milk";

    getCost(): number {
        return this.beverage.getCost() + 0.10;
    }
}


const drink: Beverage = new Mocha(new Mocha(new SteamedMilk(darkRoast)));

console.log(`Description: ${drink.description}`);
console.log(`Cost: ${drink.getCost()}`);
