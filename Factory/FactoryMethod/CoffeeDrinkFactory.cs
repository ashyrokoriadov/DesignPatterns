using Factory.Drinks;

namespace Factory.FactoryMethod
{
    class CoffeeDrinkFactory : DrinksFactory
    {
        protected override void CreateDrink()
        {
            Drink = new Coffee();
        }
    }
}
