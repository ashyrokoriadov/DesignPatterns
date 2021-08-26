using Factory.Ingridients.BaseComponents;
using Factory.Ingridients.Liquids;
using Factory.Ingridients.Sweeteners;

namespace Factory.Ingridients.IngridientsFactory
{
    interface IDrinkIngridientsFactory
    {
        IDrinkBaseComponent OrderBaseComponent();

        ILiquid OrderLiquid();

        ISweetener OrderSweetener();
    }
}
