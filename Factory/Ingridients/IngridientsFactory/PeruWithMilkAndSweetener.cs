using Factory.Ingridients.BaseComponents;
using Factory.Ingridients.Liquids;
using Factory.Ingridients.Sweeteners;

namespace Factory.Ingridients.IngridientsFactory
{
    class PeruWithMilkAndSweetener : IDrinkIngridientsFactory
    {
        public IDrinkBaseComponent OrderBaseComponent() => new CoffeePeru();

        public ILiquid OrderLiquid() => new Milk();

        public ISweetener OrderSweetener() => new Sorbitol();
    }
}
