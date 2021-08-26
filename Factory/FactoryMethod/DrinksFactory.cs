using Factory.Drinks;

namespace Factory.FactoryMethod
{
    abstract class DrinksFactory
    {
        protected IDrink Drink;
        
        protected abstract void CreateDrink();

        public void Prepare()
        {
            if (Drink == null) CreateDrink();
            Drink.Prepare();
        }

        public void Serve()
        {
            if (Drink == null) CreateDrink();
            Drink.Serve();
        }
    }
}
