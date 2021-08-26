using Factory.Ingridients.BaseComponents;
using Factory.Ingridients.Liquids;
using Factory.Ingridients.Sweeteners;

namespace Factory.Ingridients.IngridientsFactory
{
    class BlackTeaWithWaterAndSugar : IDrinkIngridientsFactory
    {
        public IDrinkBaseComponent OrderBaseComponent() => new BlackTea();

        public ILiquid OrderLiquid() => new Water();

        public ISweetener OrderSweetener() => new Sugar();      
    }
}
