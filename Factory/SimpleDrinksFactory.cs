using Factory.Drinks;
using Factory.Drinks.Enum;

namespace Factory
{
    class SimpleDrinksFactory
    {
        public IDrink Order(DrinkType drinkType)
        {
            switch(drinkType)
            {
                case DrinkType.TEA:
                    return new Tea();
                case DrinkType.COFFEE:
                    return new Coffee();
                default:
                    return new Tea();
            }
        }
    }
}
