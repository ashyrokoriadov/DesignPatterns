using System;
using Factory.Drinks;
using Factory.Drinks.Enum;
using Factory.FactoryMethod;
using Factory.Ingridients.IngridientsFactory;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            //ShowExampleOne();
            //ShowExampleTwo();
            ShowExampleThree();

            Console.ReadKey();
        }

        static void ShowExampleOne()
        {
            Console.WriteLine("Простая фабрика.");
            Console.WriteLine();

            var simpleFactory = new SimpleDrinksFactory();
            var drink = simpleFactory.Order(DrinkType.COFFEE);
            drink.Prepare();
            drink.Serve();

            Console.WriteLine();
            Console.WriteLine("Простая фабрика - конец примера.");
        }

        static void ShowExampleTwo()
        {
            Console.WriteLine("Фабричный метод.");
            Console.WriteLine();

            DrinksFactory drink = new TeaDrinkFactory();
            drink.Prepare();
            drink.Serve();

            Console.WriteLine();
            Console.WriteLine("Фабричный метод - конец примера.");
        }

        static void ShowExampleThree()
        {
            Console.WriteLine("Абстрактная фабрика.");
            Console.WriteLine();

            //var blackTeaIngridients = new BlackTeaWithWaterAndSugar();
            //var blackTea = new Drink(blackTeaIngridients);
            //blackTea.Prepare();
            //blackTea.Serve();

            var coffeeIngridients = new PeruWithMilkAndSweetener();
            var coffee = new Drink(coffeeIngridients);
            coffee.Prepare();
            coffee.Serve();

            Console.WriteLine();
            Console.WriteLine("Абстрактная фабрика - конец примера.");
        }
    }
}
