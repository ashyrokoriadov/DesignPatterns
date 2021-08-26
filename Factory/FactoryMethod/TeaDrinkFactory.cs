using Factory.Drinks;

namespace Factory.FactoryMethod
{
    class TeaDrinkFactory : DrinksFactory
    {
        protected override void CreateDrink()
        {
            Drink = new Tea();
        }
    }
}
